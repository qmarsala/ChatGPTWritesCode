namespace TextBasedRPG;

public class CombatCommand : ICommand
{
    public static string CommandString => "fight";
    public string Description => "Fight a monster";

    private readonly IOutputService _outputService;
    private int _xpAmount;

    public CombatCommand(IOutputService outputService, int xp)
    {
        _outputService = outputService;
        _xpAmount = xp;
    }

    public void Execute(Player player)
    {
        _outputService.WriteLine($"You engage in combat, gaining {_xpAmount} XP in Combat!");
        player.Combat.GainExperience(_xpAmount);
    }
}
