
namespace TextBasedRPG;

public interface IItem
{
    string Name { get; }
    int Weight { get; }
    void Use(IPlayer player);
}


public interface IPlayer
{
    string Name { get; }
    int Health { get; }
    bool IsAlive { get; }
    IEnumerable<IItem> Inventory { get; }

    void TakeDamage(int amount);
    void Heal(int amount);
    void AddToInventory(IItem item);
    void RemoveFromInventory(IItem item);
}



class Program
{
    static void Main(string[] args)
    {
       
    }
}