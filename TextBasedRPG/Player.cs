
namespace TextBasedRPG;

public class Player
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Health { get; set; }
    public int Hunger { get; set; }
    public int DaySurvived { get; set; }
    public int DistanceTraveled { get; set; }
    public bool HasKey { get; set; }

    public Player(int x, int y)
    {
        X = x;
        Y = y;
        Health = 100;
        Hunger = 100;
        DaySurvived = 0;
        DistanceTraveled = 0;
        HasKey = false;
    }

    public void Move(int x, int y)
    {
        X = x;
        Y = y;
        DistanceTraveled++;
    }

    public void IncrementDaySurvived()
    {
        DaySurvived++;
    }

    public void Eat()
    {
        Hunger = 100;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}