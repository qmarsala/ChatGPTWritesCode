namespace TextBasedRPG;

public class Player
{
    public string Name { get; set; }
    public int Health { get; set; } = 10;

    public FishingSkill Fishing { get; set; } = new FishingSkill();
    public WoodcuttingSkill Woodcutting { get; set; } = new WoodcuttingSkill();
    public FiremakingSkill Firemaking { get; set; } = new FiremakingSkill();
    public CookingSkill Cooking { get; set; } = new CookingSkill();
    public CombatSkill Combat { get; set; } = new CombatSkill();
}
