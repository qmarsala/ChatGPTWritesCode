
namespace TextBasedRPG;

public class ItemTile : ITile
{
    public bool IsAccessible => true;
    public string Description { get; }
    public char Character { get; } = 'I';

    public ItemTile(string description)
    {
        Description = description;
    }
}
