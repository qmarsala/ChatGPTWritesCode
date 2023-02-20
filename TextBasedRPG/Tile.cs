
namespace TextBasedRPG;

public class GroundTile : ITile
{
    public string Description { get; }
    public bool IsAccessible => true;
    public char Character => '.';

    public GroundTile(string description)
    {
        Description = description;
    }
}