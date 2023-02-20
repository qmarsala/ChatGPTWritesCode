namespace TextBasedRPG;

public class CookingCommand : ICommand
{
    public string CommandString => "cook";
    public string Description => "Cook some food";
    public void Execute(Player player)
    {
        player.Cooking.LevelUp();
    }
}