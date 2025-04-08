public static class ConsoleHelper
{
    public static void DisplayMessage(string message, ConsoleColor color)
    {
        if (message == null) return;

        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static string GetInputUser(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.Write(message);
        Console.ForegroundColor = color;
        string userCommand = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;

        return userCommand;
    }
}