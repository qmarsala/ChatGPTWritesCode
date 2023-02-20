
namespace TextBasedRPG;

public interface IEntity
{
    int X { get; set; }
    int Y { get; set; }
    int Health { get; set; }
    ITile CurrentTile { get; set; }
    void Move(int dx, int dy);
    bool IsAdjacent(IEntity otherEntity);
    bool Attack(IEntity otherEntity);
}