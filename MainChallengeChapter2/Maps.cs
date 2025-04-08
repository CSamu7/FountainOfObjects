public abstract class MapGeneration
{
    public Room Entrance { get; } = new Room(RoomType.Entrance, "You see light coming from the cavern entrance", ConsoleColor.Yellow);
    public InteractiveRoom Fountain { get; } = new InteractiveRoom(RoomType.FountainOfObjects, "You hear the rushing waters from the Fountain of Objects. It has been reactivated. ",
    "You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.Blue);
    public DangerRoom Pit { get; } = new DangerRoom(RoomType.Pit, "You have fall in the pit!", "You feel a draft. There is a pit in a nearby room", ConsoleColor.Red);
    public abstract Room[,] GenerateMap();
    public abstract Monster[] GenerateMonsters();
}
public class SmallMap : MapGeneration
{
    public override Room[,] GenerateMap()
    {
        Room[,] rooms = new Room[4, 4];

        rooms[0, 0] = Entrance;
        rooms[1, 0] = Pit;
        rooms[0, 1] = Fountain;

        return rooms;
    }
    public override Monster[] GenerateMonsters()
    {
        return [new Maelstrom(new Coordinate(3, 2), 4)];
    }
}
public class MediumMap : MapGeneration
{
    public override Room[,] GenerateMap()
    {
        Room[,] rooms = new Room[6, 6];
        rooms[0, 0] = Entrance;
        rooms[3, 3] = Fountain;

        rooms[1, 0] = Pit;
        rooms[2, 3] = Pit;

        return rooms;
    }
    public override Monster[] GenerateMonsters()
    {
        return [new Maelstrom(new Coordinate(1,1), 6),
                new Maelstrom(new Coordinate(5,5), 6),
                new Amarok(new Coordinate(2,5))];
    }
}
public class LargeMap : MapGeneration
{
    public override Room[,] GenerateMap()
    {
        Room[,] rooms = new Room[8, 8];

        rooms[0, 0] = Entrance;
        rooms[3, 3] = Fountain;

        rooms[1, 0] = Pit;
        rooms[1, 2] = Pit;
        rooms[5, 4] = Pit;
        rooms[3, 0] = Pit;

        return rooms;
    }

    public override Monster[] GenerateMonsters()
    {
        return [new Maelstrom(new Coordinate(1,1), 6),
                new Maelstrom(new Coordinate(5,5), 6),
                new Amarok(new Coordinate(2,5)),
                new Amarok(new Coordinate(6,2)),
                new Amarok(new Coordinate(7,1))
        ];
    }
}
