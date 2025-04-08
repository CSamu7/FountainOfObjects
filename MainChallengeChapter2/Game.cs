public class Game
{
    public Map map;
    Player player = new Player();
    public void StartGame()
    {
        string mapSizeUser = ConsoleHelper.GetInputUser("Choose the size of the map (small, medium, large): ");
        MapSize mapSize = mapSizeUser switch
        {
            "small" => MapSize.Small,
            "medium" => MapSize.Medium,
            "large" => MapSize.Large,
            _ => MapSize.Small,
        };

        DisplayIntroduction();
        map = new Map(mapSize);

        while (true)
        {
            DisplayInformation();
            DisplayMessageRoom();

            if (HasPlayerLost()) break;

            if (HasPlayerWon())
            {
                ConsoleHelper.DisplayMessage("The fountain of Objects has been reactivated, and you have escaped with your life!", ConsoleColor.Magenta);
                break;
            }

            map.SendAdjacentMessages(player.Position);

            string userCommand = ConsoleHelper.GetInputUser("What do you want to do? ", ConsoleColor.Cyan);
            IPlayerAction command = player.GetCommand(userCommand);
            command.ExecuteAction(player, map);
        }
    }
    public void DisplayInformation()
    {
        Console.WriteLine("-----------------------------------------");
        Console.Write($"You are in the room at (Row={player.Position.Y}, Column={player.Position.X}).  ");
        ConsoleHelper.DisplayMessage($"Total arrows: {player.Arrows}", ConsoleColor.DarkYellow);
        map.UpdateMonsters(player);
    }

    public void DisplayMessageRoom()
    {
        Room room = map.Rooms[player.Position.Y, player.Position.X];

        if (room is InteractiveRoom fountain)
        {
            Console.Write("[FOUNTAIN]: ");
            fountain.DisplayMessage(map.IsFountainActivated);
        } else if(room.AdjacentMessage != null)
        {
            Console.Write("[ACTUAL ROOM]: ");
            ConsoleHelper.DisplayMessage(room.Message, room.Color);
        }
    }
    public void DisplayIntroduction()
    {
        Console.WriteLine("[INTRODUCTION]");
        Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects");
        Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
        Console.WriteLine("You must navigate the Caverns with you other senses");
        Console.WriteLine("* Look out for pits. You ill feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.");
        Console.WriteLine("* Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location in the caverns. You will" +
            " able to hear their growling and groaning in nearby rooms");
        Console.WriteLine("* Amaroks roam the caverns. Encountering one is certain death, but you can smell their rotten sench in nearby rooms");
        Console.WriteLine("* You carry with you a bow and a quiver of arrows. You can use to shoot monsters in the caverns but be warned: You have limited supply");
        Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance");
    }
    public bool HasPlayerLost()
    {
        Room room = map.Rooms[player.Position.Y, player.Position.X];

        return room is DangerRoom || !player.IsAlive;
    }
    public bool HasPlayerWon()
    {
        return map.IsFountainActivated &&
               player.Position.Y == 0 &&
               player.Position.X == 0;
    }
}
