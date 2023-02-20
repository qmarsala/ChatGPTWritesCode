
namespace TextBasedRPG;

public interface IItem
{
    string Name { get; }
    int Weight { get; }
    void Use(IPlayer player);
}
