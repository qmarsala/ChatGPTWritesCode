namespace TextBasedRPG;

public class WoodcuttingCommand : ICommand
{
    public string CommandString => "chop";
    public string Description => "Chop some wood";
    public void Execute(Player player)
    {
        player.Woodcutting.LevelUp();
    }
}