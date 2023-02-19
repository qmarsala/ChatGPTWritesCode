namespace TextBasedRPG;

interface ICommand
{
    void Execute(Player player, string[] args);
}
