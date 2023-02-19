namespace TextBasedRPG;

public class FishingSkill : ISkill
{
    public string Name { get; } = "Fishing";
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;

    public void GainExperience(int amount)
    {
        // TODO: Add logic for gaining experience in fishing skill
    }
}