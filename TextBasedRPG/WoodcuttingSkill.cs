public class WoodcuttingSkill : ISkill
{
    public string Name { get; } = "Woodcutting";
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;

    public void GainExperience(int amount)
    {
        // TODO: Add logic for gaining experience in woodcutting skill
    }
}
