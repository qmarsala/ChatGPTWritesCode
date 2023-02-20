
namespace TextBasedRPG;

public interface IEnemy
{
    int Health { get; set; }
    int Damage { get; }
    int X { get; set; }
    int Y { get; set; }
    bool IsAlive { get; }
    void TakeDamage(int damage);
    void MoveTowards(int x, int y);
}


