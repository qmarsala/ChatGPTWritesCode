namespace TextBasedRPG;

public class FiremakingCommand : ICommand
{
    public string CommandString => "make fire";
    public string Description => "Make a fire";

    private int xp;

    public FiremakingCommand(int xp)
    {
        this.xp = xp;
    }

    public void Execute(Player player)
    {
        player.Firemaking.GainExperience(xp);
    }
}
