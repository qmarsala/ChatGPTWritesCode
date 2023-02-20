namespace TextBasedRPG;

public class FishingCommand : ICommand
{
    public static string CommandString => "fish";

    public string Description => "Attempt to catch a fish";

    private readonly int _xpAmount;

    public FishingCommand(int xpAmount)
    {
        _xpAmount = xpAmount;
    }

    public void Execute(Player player)
    {
        player.Fishing.GainExperience(_xpAmount);
        Console.WriteLine($"You gained {_xpAmount} experience in Fishing.");
    }
}
