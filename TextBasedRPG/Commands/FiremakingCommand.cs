namespace TextBasedRPG;

public class FiremakingCommand : ICommand
{
    public static string CommandString => "fire";
    public string Description => "Make a fire";
    private readonly IOutputService _outputService;
    private int _xpAmount;

    public FiremakingCommand(IOutputService outputService, int xp)
    {
        _outputService = outputService;
        _xpAmount = xp;
    }

    public void Execute(Player player)
    {
        _outputService.WriteLine($"You light a fire, gaining {_xpAmount} XP in Firemaking!");
        player.Firemaking.GainExperience(_xpAmount);
    }
}
