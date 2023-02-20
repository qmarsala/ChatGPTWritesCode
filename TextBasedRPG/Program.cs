
namespace TextBasedRPG;

public interface ISkill
{
    string Name { get; }
    void PerformAction();
}

public interface IPlayer
{
    string Name { get; }
    int Health { get; set; }
    IEnumerable<ISkill> Skills { get; }
}


class Program
{
    static void Main(string[] args)
    {
       
    }
}