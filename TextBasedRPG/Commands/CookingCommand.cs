namespace TextBasedRPG;

public class CookingCommand : ICommand
{
    public static string CommandString => "cook";
    public string Description => "Cook some food";

    private IOutputService _outputService;
    private int _xpAmount;

    public CookingCommand(IOutputService outputService, int xp)
    {
        _outputService = outputService;
        _xpAmount = xp;
    }

    public void Execute(Player player)
    {
        _outputService.WriteLine($"You cook a meal, gaining {_xpAmount} XP in Cooking!");
        player.Cooking.GainExperience(_xpAmount);
    }
}