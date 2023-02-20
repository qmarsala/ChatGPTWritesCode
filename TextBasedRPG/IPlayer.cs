
namespace TextBasedRPG;

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
