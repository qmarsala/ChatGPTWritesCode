namespace TextBasedRPG;

public class Player
{
    public string Name { get; set; }
    public FishingSkill Fishing { get; set; }
    public WoodcuttingSkill Woodcutting { get; set; }
    public FiremakingSkill Firemaking { get; set; }
    public CookingSkill Cooking { get; set; }
    public CombatSkill Combat { get; set; }

    public Player(string name)
    {
        Name = name;
        Fishing = new FishingSkill();
        Woodcutting = new WoodcuttingSkill();
        Firemaking = new FiremakingSkill();
        Cooking = new CookingSkill();
        Combat = new CombatSkill();
    }
}
