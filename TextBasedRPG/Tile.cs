
namespace TextBasedRPG;

public class Tile : ITile
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsAccessible { get; set; }
    public IItem Item { get; set; }
}
