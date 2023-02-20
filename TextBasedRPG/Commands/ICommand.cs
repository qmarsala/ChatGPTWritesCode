namespace TextBasedRPG;

public interface ICommand
{
    static string CommandString { get; }
    string Description { get; }
    void Execute(Player player);
}