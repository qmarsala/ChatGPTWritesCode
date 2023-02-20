namespace TextBasedRPG;

public class FiremakingCommand : ICommand
{
    public string CommandString => "make fire";
    public string Description => "Make a fire";
    public void Execute(Player player)
    {
        player.Firemaking.LevelUp();
    }
}
