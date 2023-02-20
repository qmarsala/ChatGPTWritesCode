namespace TextBasedRPG;

public class FiremakingCommand : ICommand
{
    public static string CommandString => "fire";
    public string Description => "Make a fire";
    private readonly IOutputService _outputService;
    private int xp;

    public FiremakingCommand(IOutputService outputService, int xp)
    {
        _outputService = outputService;
        this.xp = xp;
    }

    public void Execute(Player player)
    {
        player.Firemaking.GainExperience(xp);
    }
}
