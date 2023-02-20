
namespace TextBasedRPG;

public interface IPlayer
{
    int X { get; set; }
    int Y { get; set; }
    int Health { get; set; }
    int MaxHealth { get; }
    int Hunger { get; set; }
    int MaxHunger { get; }
    bool IsAlive { get; }
    bool IsHungry { get; }
    void Move(int deltaX, int deltaY);
    void TakeDamage(int damage);
    void Heal(int amount);
    void Eat(IFood food);
}
