namespace TextBasedRPG;

public class CookingCommand : ICommand
{
    public static string CommandString => "cook";
    public string Description => "Cook some food";
    private int xp;

    public CookingCommand(int xp)
    {
        this.xp = xp;
    }

    public void Execute(Player player)
    {
        player.Cooking.GainExperience(xp);
    }
}