namespace TextBasedRPG;

public interface ICommand
{
    string CommandString { get; }
    string Description { get; }
    void Execute(Player player);
}

