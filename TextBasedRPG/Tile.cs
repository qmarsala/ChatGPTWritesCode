
namespace TextBasedRPG;

public class GroundTile : ITile
{
    public string Description => "You are standing on a patch of grass.";
    public bool IsAccessible => true;
    public char Character => '.';
}