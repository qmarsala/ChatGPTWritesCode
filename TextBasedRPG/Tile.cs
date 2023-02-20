
namespace TextBasedRPG;

public class Tile : ITile
{
    public TileType Type { get; set; }
    public bool IsExplored { get; set; }
}