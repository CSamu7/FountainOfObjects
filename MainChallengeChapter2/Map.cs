public class Map
{
    public Room[,] Rooms { get; private set; }
    public Monster[] Monsters { get; private set; }
    public int Size { get; init; } = 4;
    public bool IsFountainActivated = false;
    public Map(MapSize mapSizeUser)
    {
        MapGeneration command = GetMapGeneration(mapSizeUser);
        Rooms = command.GenerateMap();
        Size = Rooms.GetLength(0);
        FillMap();
        Monsters = command.GenerateMonsters();
    }

    public MapGeneration GetMapGeneration(MapSize mapSize)
    {
        return mapSize switch
        {
            MapSize.Small => new SmallMap(),
            MapSize.Medium => new MediumMap(),
            MapSize.Large => new LargeMap(),
            _ => new SmallMap(),
        };
    }
    public void FillMap()
    {
        for (int row = 0; row < Rooms.GetLength(0); row++)
        {
            for (int column = 0; column < Rooms.GetLength(1); column++)
            {
                if (Rooms[row, column] == null) Rooms[row, column] = new Room(RoomType.Empty);
            }
        }
    }
    public void SendAdjacentMessages(Coordinate player)
    {
        for (int row = player.Y - 1; row <= player.Y + 1; row++)
        {
            for (int column = player.X - 1; column <= player.X + 1; column++)
            {
                //LIMITS
                if (row < 0 || row >= Size - 1 || column < 0 || column >= Size - 1) continue;

                Room room = Rooms[row, column];
                if (room.AdjacentMessage == null || room is InteractiveRoom) continue;

                Console.Write("[NEAR ROOM]: ");
                ConsoleHelper.DisplayMessage(room.AdjacentMessage, room.Color);
            }
        }

        foreach (Monster monster in Monsters)
        {
            monster.DisplayAdjacentMessage(player);
        }
    }
    public void UpdateMonsters(Player player)
    {
        foreach (Monster monster in Monsters)
        {
            monster.Act(player);
        }
    }
}

