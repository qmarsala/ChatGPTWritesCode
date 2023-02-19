namespace TextBasedRPG;

class QuitCommand : ICommand
{
    public void Execute(Player player, string[] args)
    {
        // Exit the game loop
        Environment.Exit(0);
    }
}
