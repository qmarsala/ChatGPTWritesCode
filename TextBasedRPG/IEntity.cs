
namespace TextBasedRPG;

public interface IEntity
{
    ITile CurrentTile { get; set; }
    int X { get; set; }
    int Y { get; set; }
    int Health { get; set; }
    void Move(int dx, int dy);
    bool IsAdjacent(IEntity otherEntity);
    bool Attack(IEntity otherEntity);
}