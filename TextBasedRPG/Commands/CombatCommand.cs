namespace TextBasedRPG;

public class CombatCommand : ICommand
{
    public static string CommandString => "fight";
    public string Description => "Fight a monster";

    private readonly IOutputService _outputService;
    private int xp;

    public CombatCommand(IOutputService outputService, int xp)
    {
        _outputService = outputService;
        this.xp = xp;
    }

    public void Execute(Player player)
    {
        player.Combat.GainExperience(xp);
    }
}
