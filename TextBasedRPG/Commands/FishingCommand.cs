namespace TextBasedRPG;

public class FishingCommand : ICommand
{
    public static string CommandString => "fish";

    public string Description => "Attempt to catch a fish";

    private readonly int _xpAmount;
    private readonly FishingSkill _skill;

    public FishingCommand(FishingSkill skill, int xpAmount)
    {
        _skill = skill;
        _xpAmount = xpAmount;
    }

    public void Execute(Player player)
    {
        _skill.GainExperience(_xpAmount);
        Console.WriteLine($"You gained {_xpAmount} experience in Fishing.");
    }
}
