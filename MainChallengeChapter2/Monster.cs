public class Monster : Entity
{
    public string AdjacentMessage { get; init; }
    public string Message { get; init; }
    public ConsoleColor Color { get; init; }
    public void DisplayAdjacentMessage(Coordinate player)
    {
        if (Coordinate.AreCoordinatesAdjacent(player, Position) && this.IsAlive)
        {
            Console.Write("[NEAR ROOM]: ");
            ConsoleHelper.DisplayMessage(AdjacentMessage, Color);
        }
    }
    public void Act(Player player)
    {
        if (Coordinate.AreCoordinatesEqual(player.Position, Position) && this.IsAlive)
        {
            ConsoleHelper.DisplayMessage($"[ATTACK]: {Message}", Color);
            Attack(player);
        }
    }
    public virtual void Attack(Player player) { }
}
public class Maelstrom : Monster
{
    private int Limit { get; init; }
    public void Teleport(Entity entity, int x, int y)
    {
        entity.Position.X += x;
        entity.Position.Y += y;

        if (entity.Position.X >= Limit)
        {
            entity.Position.X = entity.Position.X % Limit;
        }

        if (entity.Position.Y >= Limit)
        {
            entity.Position.Y = entity.Position.Y % Limit;
        }

        if (entity.Position.Y < 0)
        {
            entity.Position.Y = Limit + entity.Position.Y;
        }

        if (entity.Position.X < 0)
        {
            entity.Position.X = Limit + entity.Position.X;
        }
    }
    public Maelstrom(Coordinate coordinate, int mapSize)
    {
        Position = coordinate;
        AdjacentMessage = "You hear the growling and groaning of a maelstrom nearby";
        Message = "You have been teleported by the Maelstrom!!";
        Limit = mapSize;
        Color = ConsoleColor.DarkBlue;
    }
    public override void Attack(Player player)
    {
        Teleport(player, 2, 1);
        Teleport(this, -2, -1);
        Console.WriteLine($"Now you are at the room: (Row={player.Position.Y}, Column={player.Position.X})");
        Console.WriteLine($"The Maelstrom has moved!");
    }
}
public class Amarok : Monster
{
    public Amarok(Coordinate coordinate)
    {
        Position = coordinate;
        AdjacentMessage = "You can smell the rotten stench of an amarok in a nearby room";
        Message = "You have died by the Amarok!";
        Color = ConsoleColor.DarkRed;
    }

    public override void Attack(Player player)
    {
        player.IsAlive = false;
    }
}