public interface ISkill
{
    string Name { get; }
    int Level { get; set; }
    int Experience { get; set; }
    void GainExperience(int amount);
}

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

public class FiremakingSkill : ISkill
{
    public string Name { get; } = "Firemaking";
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;

    public void GainExperience(int amount)
    {
        // TODO: Add logic for gaining experience in firemaking skill
    }
}

public class CookingSkill : ISkill
{
    public string Name { get; } = "Cooking";
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;

    public void GainExperience(int amount)
    {
        // TODO: Add logic for gaining experience in cooking skill
    }
}

public class CombatSkill : ISkill
{
    public string Name { get; } = "Combat";
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;

    public void GainExperience(int amount)
    {
        // TODO: Add logic for gaining experience in combat skill
    }
}

public class Player
{
    public string Name { get; set; }
    public int HitPoints { get; set; } = 10;

    public FishingSkill Fishing { get; set; } = new FishingSkill();
    public WoodcuttingSkill Woodcutting { get; set; } = new WoodcuttingSkill();
    public FiremakingSkill Firemaking { get; set; } = new FiremakingSkill();
    public CookingSkill Cooking { get; set; } = new CookingSkill();
    public CombatSkill Combat { get; set; } = new CombatSkill();
}