public class Map
{
    public RoomType[,] Rooms { get; private set; }
    public int Size { get; init; } = 4;
    public bool IsFountainActivated = false;

    public Map() 
    {
        GetMapGeneration(MapSize.Small);
    }
    public Map(MapSize mapSizeUser) 
    {
        IMapGeneration command = GetMapGeneration(mapSizeUser);
        Rooms = command.GenerateMap();
        Size = Rooms.Length;
    }

    public IMapGeneration GetMapGeneration(MapSize mapSize) {
        return mapSize switch {
            MapSize.Small => new SmallMap(),
            MapSize.Medium => new MediumMap(),
            MapSize.Large => new LargeMap(),
            _ => new SmallMap(),
        };
    }
    public RoomType? LocateAdjacentDangerRoom(Coordinate coordinates) {
        for(int row =coordinates.X - 1; row <= coordinates.X + 1;row++) {
            for(int column = coordinates.Y - 1; column <= coordinates.Y + 1;column++) {
                if (row < 0 || row > Size - 1 || column < 0 || column > Size - 1) {
                    continue;
                }

                if (Rooms[row,column].Equals(RoomType.Pit)) return RoomType.Pit;
            }
        }

        return null;
    }
}

