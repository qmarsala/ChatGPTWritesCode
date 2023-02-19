namespace TextBasedRPG;

public class Player
{
    public string Name { get; set; }
    public int FishingLevel { get; set; }
    public int WoodcuttingLevel { get; set; }
    public int FiremakingLevel { get; set; }
    public int CookingLevel { get; set; }
    public int CombatLevel { get; set; }

    public Player(string name)
    {
        Name = name;
        FishingLevel = 1;
        WoodcuttingLevel = 1;
        FiremakingLevel = 1;
        CookingLevel = 1;
        CombatLevel = 1;
    }
}
