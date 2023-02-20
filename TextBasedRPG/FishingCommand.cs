namespace TextBasedRPG;

public class FishingCommand : ICommand
{
    public string CommandString => "fish";
    public string Description => "Catch some fish";
    public void Execute(Player player)
    {
        player.Fishing.LevelUp();
    }
}
