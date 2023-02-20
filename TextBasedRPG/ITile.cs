
namespace TextBasedRPG;

public interface ITile
{
    string Symbol { get; set; }
    TileType Type { get; set; }
    bool IsExplored { get; set; }
    bool IsExit { get; set; }
}
