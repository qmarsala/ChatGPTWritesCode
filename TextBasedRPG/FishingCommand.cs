namespace TextBasedRPG;

public class FishingCommand : ICommand
{
    public string CommandString => "fish";
    public string Description => "Starts fishing.";

    private int xp;

    public FishingCommand(int xp)
    {
        this.xp = xp;
    }
    
    public void Execute(Player player)
    {
        player.Fishing.GainExperience(xp);
    }
}
