public class Map 
{
    public RoomType[,] Rooms { get; private set; }
    public int Size { get; init; } = 4;
    public bool IsFountainActivated = false;

    public Map() 
    {
        InitializeMap();
    }
    public Map(string mapSizeUser) 
    {
        MapSize mapInt = mapSizeUser.ToLower() switch 
        {
            "small" => MapSize.Small,
            "medium" => MapSize.Medium,
            "large" => MapSize.Large,
            _=> MapSize.Small,
        };

        Size = (int) mapInt;
        
        InitializeMap();
    }

    private void InitializeMap() 
    {
        Rooms = new RoomType[Size,Size];
        GenerateSpecialRooms();
    }
    private void GenerateSpecialRooms()
    {
        Rooms[0,0] = RoomType.Entrance;
        Rooms[0,2] = RoomType.FountainOfObjects;
        Rooms[1,0] = RoomType.Pit;
    }
}

