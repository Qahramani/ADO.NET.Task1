namespace ADO.NET.Task1.Helpers;

public static class Colored
{
    public static void WriteLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public static void Write(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }
}
