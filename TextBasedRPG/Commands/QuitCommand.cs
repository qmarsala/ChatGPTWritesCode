namespace TextBasedRPG;

class QuitCommand : ICommand
{
    private IOutputService _outputService;

    public static string CommandString => "quit";

    public string Description => "Quits the game";

    public QuitCommand(IOutputService outputService)
    {
        _outputService = outputService;
    }

    public void Execute(Player player)
    {
        player.IsAlive = false;
        Console.WriteLine("Goodbye!");
    }
}
