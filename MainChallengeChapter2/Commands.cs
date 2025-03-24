public interface IPlayerAction 
{
    void ExecuteAction(Coordinate cordinates, Map map);
}
public class NorthCommand: IPlayerAction 
{
    public void ExecuteAction(Coordinate coordinates,Map map) 
    {
        if(map.Size - 1 > coordinates.Y) 
        {
            coordinates.Y += 1;
        }
    }
}
public class EastCommand: IPlayerAction 
{
    public void ExecuteAction(Coordinate coordinates, Map map) 
    {
        if (map.Size > coordinates.X) 
        {
            coordinates.X += 1;
        }
    }
}
public class SouthCommand: IPlayerAction 
{
    public void ExecuteAction(Coordinate coordinates,Map map)
    {
        if (coordinates.Y > 0) 
        {
            coordinates.Y -= 1;
        }
    }
}
public class WestCommand: IPlayerAction 
{
    public void ExecuteAction(Coordinate coordinates,Map map) 
    {
        if (coordinates.X > 0) 
        {
            coordinates.X -= 1;
        }
    }
}

public class FountainCommand : IPlayerAction 
{
    public void ExecuteAction(Coordinate coordinates, Map map) 
    {
        RoomType actualRoom = map.Rooms[coordinates.X,coordinates.Y];

        if (actualRoom.Equals(RoomType.FountainOfObjects)) 
        {
            map.IsFountainActivated = true;
        }
    }
}
