
namespace TextBasedRPG;

public class Tile : ITile
{
    public TileType Type { get; }
    public string Description { get; set; }
    public string Name { get; set; }
    public bool IsAccessible { get; set; }

    public Tile(TileType type, string description)
    {
        Type = type;
        Description = description;
    }
}
