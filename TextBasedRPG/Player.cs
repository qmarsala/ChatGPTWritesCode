
namespace TextBasedRPG;

public class Player : Entity, IPlayer
{
    public int MaxHealth { get; set; }
    public int Hunger { get; set; }
    public IItem EquippedItem { get; set; }
    public int DaysSurvived { get; set; }

    public bool IsAlive
    {
        get { return Health > 0; }
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.None:
                Y -= 1;
                break;
            case Direction.South:
                Y += 1;
                break;
            case Direction.West:
                X -= 1;
                break;
            case Direction.East:
                X += 1;
                break;
        }
    }

    public bool IsAdjacent(IEntity otherEntity)
    {
        int dx = Math.Abs(X - otherEntity.X);
        int dy = Math.Abs(Y - otherEntity.Y);

        return (dx == 1 && dy == 0) || (dx == 0 && dy == 1);
    }

    public Direction GetInput()
    {
        throw new NotImplementedException();
    }
}