
namespace TextBasedRPG;

public class Weapon : IItem
{
    public string Name { get; }
    public int Weight { get; }
    public int Damage { get; }

    public Weapon(string name, int weight, int damage)
    {
        Name = name;
        Weight = weight;
        Damage = damage;
    }

    public void Use(IPlayer player)
    {
        player.EquipItem(this);
    }
}

