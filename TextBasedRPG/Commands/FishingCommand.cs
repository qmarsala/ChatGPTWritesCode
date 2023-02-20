namespace TextBasedRPG;

public class FishingCommand : ICommand
{
    public static string CommandString => "fish";
    public string Description => "Go fishing";
    private readonly IOutputService _outputService;
    private readonly int _xpAmount;

    public FishingCommand(IOutputService outputService, int xpAmount)
    {
        _outputService = outputService;
        _xpAmount = xpAmount;
    }

    public void Execute(Player player)
    {
        player.Fishing.GainExperience(_xpAmount);
        _outputService.WriteLine($"You have gained {_xpAmount} fishing experience!");
    }
}