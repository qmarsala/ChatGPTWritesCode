namespace TextBasedRPG;

public class CombatCommand : ICommand
{
    public string CommandString => "fight";
    public string Description => "Fight a monster";
    public void Execute(Player player)
    {
        player.Combat.LevelUp();
    }
}
