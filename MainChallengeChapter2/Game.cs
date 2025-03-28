public class Game {
    public Map map;
    Player player = new Player();
  
    public void StartGame() {
        string mapSizeUser = GetUserInput("Choose the size of the map (small, medium, large): ");
        MapSize mapSize = mapSizeUser switch {
            "small" => MapSize.Small,
            "medium" => MapSize.Medium,
            "large" => MapSize.Large,
            _ => MapSize.Small,
        };

        map = new Map(mapSize);

        while (true) {
            DisplayInformation();
            string userCommand = GetUserInput("What do you want to do? ", ConsoleColor.Cyan);
   
            IPlayerAction command = player.GetCommand(userCommand);
            command.ExecuteAction(player.position,map);

            if (HasPlayerLost()) {
                DisplayMessage("You have lost!",ConsoleColor.Red);
                break;
            }

            if (HasPlayerWon()) {
                DisplayMessage("The fountain of Objects has been reactivated, and you have escaped with your life!", ConsoleColor.Magenta);
                break;
            }
        }
    }
    public void DisplayInformation() {
        Console.WriteLine("---------------------------------------");
        Console.WriteLine($"You are in the room at (Row={player.position.X}, Column={player.position.Y})");
        GetRoomMessage();
    }
    private string GetUserInput(string message, ConsoleColor color = ConsoleColor.White) {
        Console.Write(message);
        Console.ForegroundColor = color;
        string userCommand = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;

        return userCommand;
    }
    public void DisplayMessage(string message,ConsoleColor color) {
        if (message == null) return;

        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    public string? GetRoomMessage() {
        RoomType room = map.Rooms[player.position.X,player.position.Y];
        RoomType? nearestDanger = map.LocateAdjacentDangerRoom(player.position);

        if (room.Equals(RoomType.FountainOfObjects) && !map.IsFountainActivated) {
            DisplayMessage("You hear water dripping in this room. The fountain of Objects is here!", ConsoleColor.Blue);
        } else if (room.Equals(RoomType.FountainOfObjects) && map.IsFountainActivated) {
            DisplayMessage("You hear the rushing waters from the Fountain of Objects. It has been reactivated", ConsoleColor.Blue);
        } else if (room.Equals(RoomType.Entrance)) {
            DisplayMessage("You see light in this room coming from outside the cavern. This is the entrance", ConsoleColor.Yellow);
        } 

        //Nearest dangers
        
        if (nearestDanger.Equals(RoomType.Pit)) {
           DisplayMessage("You feel a draft. There is a pit in a nearby room", ConsoleColor.Red);
        }

        return null;
    }
    public bool HasPlayerLost() {
        RoomType room = map.Rooms[player.position.X,player.position.Y];

        return room.Equals(RoomType.Pit);
    }
    public bool HasPlayerWon() 
    {
        return map.IsFountainActivated &&
               player.position.X == 0 &&
               player.position.Y == 0;
    }
}
