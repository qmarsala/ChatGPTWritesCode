namespace TextBasedRPG;


public class WoodcuttingCommand : ICommand
{
    public static string CommandString => "chop";
    public string Description => "Chop some wood";
    private readonly IOutputService _outputService;


    private int _xpAmount;

    public WoodcuttingCommand(IOutputService outputService, int xp)
    {
        _outputService = outputService;
        _xpAmount = xp;
    }

    public void Execute(Player player)
    {
        _outputService.WriteLine($"You chop down a tree, gaining {_xpAmount} XP in Woodcutting!");
        player.Woodcutting.GainExperience(_xpAmount);
    }
}