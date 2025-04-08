public class Room
{
    public RoomType Type { get; init; } = RoomType.Empty;
    public string? Message { get; }
    public string? AdjacentMessage { get; }
    public ConsoleColor Color { get; init; }
    public Room(RoomType type)
    {
        Type = type;
    }
    public Room(RoomType type, string message, ConsoleColor color)
    {
        Message = message;
        Type = type;
        Color = color;
    }
    public Room(RoomType type, string message, string adjacentMessage, ConsoleColor color) : this(type, message, color)
    {
        AdjacentMessage = adjacentMessage;
    }
}

public class DangerRoom : Room
{
    public DangerRoom(RoomType type, string message, string? adjacentMessage, ConsoleColor color)
                     : base(type, message, adjacentMessage, color) { }
}
public class InteractiveRoom : Room
{
    public InteractiveRoom(RoomType type, string activeMessage, string inactiveMessage, ConsoleColor color)
                 : base(type, activeMessage, inactiveMessage, color) { }

    public void DisplayMessage(bool state)
    {
        if (state)
        {
            ConsoleHelper.DisplayMessage(Message, Color);
        } else
        {
            ConsoleHelper.DisplayMessage(AdjacentMessage, Color);
        }
    }
}