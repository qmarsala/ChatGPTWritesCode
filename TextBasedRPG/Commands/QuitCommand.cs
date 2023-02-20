namespace TextBasedRPG;

class QuitCommand : ICommand
{
    public static string CommandString => "quit";

    public string Description => "Quits the game";

    public void Execute(Player player)
    {
        player.IsAlive = false;
        Console.WriteLine("Goodbye!");
    }
}
