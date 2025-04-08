public interface IPlayerAction
{
    void ExecuteAction(Player player, Map map);
}
public class NorthCommand : IPlayerAction
{
    public void ExecuteAction(Player player, Map map)
    {
        if (player.Position.Y < map.Size - 1)
        {
            player.Position.Y += 1;
        }
    }
}
public class EastCommand : IPlayerAction
{
    public void ExecuteAction(Player player, Map map)
    {
        if (player.Position.X < map.Size - 1 )
        {
            player.Position.X += 1;
        }
    }
}
public class SouthCommand : IPlayerAction
{
    public void ExecuteAction(Player player, Map map)
    {
        if (player.Position.Y > 0)
        {
            player.Position.Y -= 1;
        }
    }
}
public class WestCommand : IPlayerAction
{
    public void ExecuteAction(Player player, Map map)
    {
        if (player.Position.X > 0)
        {
            player.Position.X -= 1;
        }
    }
}
public class FountainCommand : IPlayerAction
{
    public void ExecuteAction(Player player, Map map)
    {
        Room actualRoom = map.Rooms[player.Position.Y, player.Position.X];

        if (actualRoom.Type.Equals(RoomType.FountainOfObjects))
        {
            map.IsFountainActivated = true;
        }
    }
}
public class ShootCommand
{
    public void Shoot(Player player, Map map, Coordinate shootCordinates)
    {
        if (player.Arrows <= 0)
        {
            ConsoleHelper.DisplayMessage("You don't have any arrow left!", ConsoleColor.DarkYellow);
            return;
        }

        foreach (Monster monster in map.Monsters)
        {
            if (Coordinate.AreCoordinatesEqual(monster.Position, shootCordinates))
            {
                ConsoleHelper.DisplayMessage($"You have killed the {monster.ToString()}", ConsoleColor.Green);
                monster.IsAlive = false;
                player.Arrows -= 1;
                return;
            }
        }

        ConsoleHelper.DisplayMessage("You have shot to the nothing", ConsoleColor.DarkYellow);

        player.Arrows -= 1;
    }
}

public class ShootNorth : ShootCommand, IPlayerAction
{
    public void ExecuteAction(Player player, Map map)
    {
      Shoot(player, map, new Coordinate(player.Position.X, player.Position.Y + 1));
    }
}

public class ShootSouth : ShootCommand, IPlayerAction
{
    public void ExecuteAction(Player player, Map map)
    {
        Shoot(player, map, new Coordinate(player.Position.X, player.Position.Y - 1));
    }
}

public class ShootEast : ShootCommand, IPlayerAction
{
    public void ExecuteAction(Player player, Map map)
    {
        Shoot(player, map, new Coordinate(player.Position.X + 1, player.Position.Y));
    }
}
public class ShootWest : ShootCommand, IPlayerAction
{
    public void ExecuteAction(Player player, Map map)
    {
        Shoot(player, map, new Coordinate(player.Position.X - 1, player.Position.Y));
    }
}
public class HelpCommand : IPlayerAction
{
    public void ExecuteAction(Player player, Map map)
    {
        Console.WriteLine("[COMMANDS]: ");
        Console.WriteLine("move north: Move the player to the north");
        Console.WriteLine("move south: Move the player to the south");
        Console.WriteLine("move east: Move the player to the east");
        Console.WriteLine("move west: Move the player to the west");
        Console.WriteLine("enable fountain: Activate the fountain");
        Console.WriteLine("shoot north : Shoot an arrow to the north");
        Console.WriteLine("shoot south : Shoot an arrow to the south");
        Console.WriteLine("shoot east : Shoot an arrow to the east");
        Console.WriteLine("shoot west : Shoot an arrow to the west");
        Console.WriteLine("help: Show the available commands");
    }
}