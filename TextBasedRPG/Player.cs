
namespace TextBasedRPG;

public class Player : Entity, IPlayer
{
    public int MaxHealth { get; set; } = 100;
    public int Hunger { get; set; } = 0;
    public IItem EquippedItem { get; set; }
    public int DaysSurvived { get; set; } = 1;

    public bool IsAlive
    {
        get { return Health > 0; }
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
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
        ConsoleKeyInfo inputKey = Console.ReadKey(true);
        switch (inputKey.Key)
        {
            case ConsoleKey.UpArrow:
                return Direction.North;
            case ConsoleKey.DownArrow:
                return Direction.South;
            case ConsoleKey.LeftArrow:
                return Direction.West;
            case ConsoleKey.RightArrow:
                return Direction.East;
            default:
                return Direction.None;
        }
    }
}