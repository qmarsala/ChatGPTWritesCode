
namespace TextBasedRPG;

public class Entity : IEntity
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Health { get; set; }
    public ITile CurrentTile { get; set; }

    public void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }

    public bool IsAdjacent(IEntity otherEntity)
    {
        int dx = Math.Abs(X - otherEntity.X);
        int dy = Math.Abs(Y - otherEntity.Y);

        return (dx == 1 && dy == 0) || (dx == 0 && dy == 1);
    }

    public bool Attack(IEntity otherEntity)
    {
        if (IsAdjacent(otherEntity))
        {
            otherEntity.Health -= 1;
            return true;
        }

        return false;
    }
}