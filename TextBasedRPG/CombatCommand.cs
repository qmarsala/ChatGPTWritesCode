namespace TextBasedRPG;

public class CombatCommand : ICommand
{
    public string CommandString => "fight";
    public string Description => "Fight a monster";

    private int xp;

    public CombatCommand(int xp)
    {
        this.xp = xp;
    }

    public void Execute(Player player)
    {
        player.Combat.GainExperience(xp);
    }
}
