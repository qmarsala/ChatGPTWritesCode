
namespace TextBasedRPG;

public class Food : IItem
{
    public string Name { get; } = "Food";
    public int Weight { get; } = 1;
    public int Nutrition { get; }

    public Food(int nutrition)
    {
        Nutrition = nutrition;
    }

    public void Use(IPlayer player)
    {
        player.Hunger += Nutrition;
    }
}