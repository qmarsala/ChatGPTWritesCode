
namespace TextBasedRPG;

public enum TileType
{
    Ground,
    Item,
    Enemy,
    Exit
}


public interface ITile
{
    TileType Type { get; }
    char DisplayChar { get; }
    bool IsPassable { get; }
    string Description { get; }
    void Interact(IPlayer player);
}