public interface IMapGeneration {
    RoomType[,] GenerateMap();
}
public class SmallMap: IMapGeneration {
    public RoomType[,] GenerateMap() {
        RoomType[,] Rooms = new RoomType[4,4];

        Rooms[0,0] = RoomType.Entrance;
        Rooms[0,2] = RoomType.FountainOfObjects;
        Rooms[1,0] = RoomType.Pit;

        return Rooms;
    }
}

public class MediumMap: IMapGeneration {
    public RoomType[,] GenerateMap() {
        RoomType[,] Rooms = new RoomType[6,6];

        Rooms[0,0] = RoomType.Entrance;
        Rooms[3,3] = RoomType.FountainOfObjects;

        Rooms[1,0] = RoomType.Pit;
        Rooms[1,3] = RoomType.Pit;

        return Rooms;
    }
}

public class LargeMap: IMapGeneration {
    public RoomType[,] GenerateMap() {
        RoomType[,] Rooms = new RoomType[8,8];

        Rooms[0,0] = RoomType.Entrance;
        Rooms[3,3] = RoomType.FountainOfObjects;

        Rooms[1,0] = RoomType.Pit;
        Rooms[1,2] = RoomType.Pit;
        Rooms[5,4] = RoomType.Pit;
        Rooms[3,0] = RoomType.Pit;

        return Rooms;
    }
}
