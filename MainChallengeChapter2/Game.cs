public class Game {
    public Map map;
    Player player = new Player();
    public void StartGame() {
        Console.Write("Choose the size of the map (small, medium, large): ");
        string mapSizeUser = Console.ReadLine();

        map = new Map(mapSizeUser);

        while (true) {
            DisplayInformation();
            string userCommand = GetUserInput();
   
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

    private string GetUserInput() {
        Console.Write("What do you want to do? ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string userCommand = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;

        return userCommand;
    }
    public void DisplayInformation() {
        Console.WriteLine("---------------------------------------");
        Console.WriteLine($"You are in the room at (Row={player.position.X}, Column={player.position.Y})");
        GetRoomMessage();
    }

    private void GetRoomMessage() {
        RoomType room = map.Rooms[player.position.X,player.position.Y];
        RoomType? nearestDanger = FindNearestDanger();

        if (room.Equals(RoomType.FountainOfObjects) && !map.IsFountainActivated) {
            DisplayMessage("You hear water dripping in this room. The fountain of Objects is here!",ConsoleColor.Blue);
        } else if (room.Equals(RoomType.FountainOfObjects) && map.IsFountainActivated) {
            DisplayMessage("You hear the rushing waters from the Fountain of Objects. It has been reactivated",ConsoleColor.Blue);
        } else if (room.Equals(RoomType.Entrance)) {
            DisplayMessage("You see light in this room coming from outside the cavern. This is the entrance",ConsoleColor.Yellow);
        } else if (nearestDanger.Equals(RoomType.Pit)) {
            DisplayMessage("You feel a draft. There is a pit in a nearby room", ConsoleColor.Red);
        }
    }
    private RoomType? FindNearestDanger() {
        for (int x = 0; x<3;x++) {
            for(int y = 0; y<3;y++) {
                if((x < 0 || x >= map.Size) || (y < 0 || y >= map.Size)){
                    continue;
                }

                if (map.Rooms[x + player.position.X,y + player.position.Y].Equals(RoomType.Pit)) {
                    return RoomType.Pit;
                }
            }
        }

        return null;
    }

    public void DisplayMessage(string message,ConsoleColor color) {
        if (message == null) return;

        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
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
