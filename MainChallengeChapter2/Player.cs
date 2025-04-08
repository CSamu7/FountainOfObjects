public class Player : Entity
{
    public int Arrows { get; set; } = 5;
    public Player()
    {
        Position = new Coordinate(0, 0);
    }
    public IPlayerAction GetCommand(string command)
    {
        return command switch
        {
            "move east" => new EastCommand(),
            "move north" => new NorthCommand(),
            "move south" => new SouthCommand(),
            "move west" => new WestCommand(),
            "enable fountain" => new FountainCommand(),
            "shoot north" => new ShootNorth(),
            "shoot south" => new ShootSouth(),
            "shoot east" => new ShootEast(),
            "shoot west" => new ShootWest(),
            "help" => new HelpCommand(),
            _ => new HelpCommand()
        };
    }
}

