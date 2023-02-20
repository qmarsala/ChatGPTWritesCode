
namespace TextBasedRPG;

public class Player : IPlayer
{
    public string Name { get; }
    public int Health { get; private set; }
    public bool IsAlive => Health > 0;

    public IEnumerable<IItem> Inventory => inventory;
    private List<IItem> inventory = new List<IItem>();

    public Player(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0)
        {
            Health = 0;
        }
    }

    public void Heal(int amount)
    {
        Health += amount;
    }

    public void AddToInventory(IItem item)
    {
        inventory.Add(item);
    }

    public void RemoveFromInventory(IItem item)
    {
        inventory.Remove(item);
    }
}
