namespace TextBasedRPG;


public class WoodcuttingCommand : ICommand
{
    public static string CommandString => "chop";
    public string Description => "Chop some wood";
    private readonly IOutputService _outputService;


    private int xp;

    public WoodcuttingCommand(IOutputService outputService, int xp)
    {
        _outputService = outputService;
        this.xp = xp;
    }

    public void Execute(Player player)
    {
        player.Woodcutting.GainExperience(xp);
    }
}