
namespace TextBasedRPG;

public class EnemyTile : ITile
{
    public bool IsAccessible => true;
    public string Description { get; }
    public char Character { get; } = 'E';

    public EnemyTile(string description)
    {
        Description = description;
    }
}
