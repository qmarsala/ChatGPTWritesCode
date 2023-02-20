namespace TextBasedRPG;

public class CookingCommand : ICommand
{
    public static string CommandString => "cook";
    public string Description => "Cook some food";

    private IOutputService _outputService;
    private int xp;

    public CookingCommand(IOutputService outputService, int xp)
    {
        _outputService = outputService;
        this.xp = xp;
    }

    public void Execute(Player player)
    {
        player.Cooking.GainExperience(xp);
    }
}