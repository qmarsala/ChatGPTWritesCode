
namespace TextBasedRPG;

public interface IPlayer
{
    string Name { get; }
    int Level { get; }
    int Experience { get; }
    int MaxHealth { get; }
    int CurrentHealth { get; }
    bool IsAlive { get; }
    IDictionary<string, ISkill> Skills { get; }

    void AddExperience(int amount);
    void TakeDamage(int amount);
    void Heal(int amount);
}


class Program
{
    static void Main(string[] args)
    {
       
    }
}