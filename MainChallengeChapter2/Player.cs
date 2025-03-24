public class Player {
    public Coordinate position = new Coordinate(0,0);
    public IPlayerAction GetCommand(string command) {
        return command switch {
            "move east" => new EastCommand(),
            "move north" => new NorthCommand(),
            "move south" => new SouthCommand(),
            "move west" => new WestCommand(),
            "enable fountain" => new FountainCommand()
        };
    }

}

