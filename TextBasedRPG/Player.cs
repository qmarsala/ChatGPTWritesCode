namespace TextBasedRPG;

public class Player
{
    public string Name { get; set; }
    public bool IsAlive { get; set; } = true;
    public int Health { get; set; } = 100;
    public int MaxHealth { get; set; } = 100;
    
    // Constructor
    public Player(string name)
    {
        Name = name;
    }
    
    // Skill properties
    public FishingSkill Fishing { get; set; } = new FishingSkill();
    public WoodcuttingSkill Woodcutting { get; set; } = new WoodcuttingSkill();
    public FiremakingSkill Firemaking { get; set; } = new FiremakingSkill();
    public CookingSkill Cooking { get; set; } = new CookingSkill();
    public CombatSkill Combat { get; set; } = new CombatSkill();
}

