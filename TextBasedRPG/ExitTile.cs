
namespace TextBasedRPG;

public class ExitTile : ITile
{
    public bool IsAccessible => true;
    public string Description { get; }
    public char Character { get; } = 'X';

    public ExitTile(string description)
    {
        Description = description;
    }
}