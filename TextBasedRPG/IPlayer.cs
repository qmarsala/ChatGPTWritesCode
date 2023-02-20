
namespace TextBasedRPG;

public interface IPlayer
{
    int X { get; }
    int Y { get; }
    int Health { get; }
    int MaxHealth { get; }
    int Hunger { get; }
    int MaxHunger { get; }
    bool IsAlive { get; }
    ITile CurrentTile { get; }
    IItem EquippedItem { get; }

    void Move(int deltaX, int deltaY);
    void Damage(int amount);
    void Heal(int amount);
    void IncreaseHunger(int amount);
    void Eat(IItem item);
    void EquipItem(IItem item);
}