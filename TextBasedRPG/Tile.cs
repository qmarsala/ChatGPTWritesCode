
namespace TextBasedRPG;

public class Tile : ITile
{
    public TileType Type { get; set; }
    public bool IsExplored { get; set; }
    public string Symbol { get; set; }
    public bool IsExit { get; set; }
}