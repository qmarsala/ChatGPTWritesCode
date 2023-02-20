
namespace TextBasedRPG;

public interface ITile
{
    TileType Type { get; set; }
    bool IsExplored { get; set; }
}
