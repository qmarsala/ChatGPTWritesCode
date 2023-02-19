namespace TextBasedRPG;

public interface ISkill
{
    string Name { get; }
    int Level { get; set; }
    int Experience { get; set; }
    void GainExperience(int amount);
}