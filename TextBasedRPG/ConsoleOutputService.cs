namespace TextBasedRPG;

public class ConsoleOutputService : IOutputService
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}