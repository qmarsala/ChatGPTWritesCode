namespace TextBasedRPG;

public class WoodcuttingCommand : ICommand
{
    public string CommandString => "chop";
    public string Description => "Chop some wood";

    private int xp;
    
    public WoodcuttingCommand(int xp)
    {
        this.xp = xp;
    }

    public void Execute(Player player)
    {
        player.Woodcutting.GainExperience(xp);
    }
}