
namespace TextBasedRPG;

public class Player : Entity, IPlayer
{
    private int daysSurvived;
    private int health;
    private int maxHealth;
    private int hunger;
    private IItem equippedItem;

    public Player(int x, int y, int health, int maxHealth, int hunger)
    {
        X = x;
        Y = y;
        this.health = health;
        this.maxHealth = maxHealth;
        this.hunger = hunger;
    }

    public int GetDaysSurvived()
    {
        return daysSurvived;
    }

    public Direction GetInput()
    {
        // Logic to get player input goes here
        return Direction.None;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetHealth(int health)
    {
        this.health = Math.Min(health, maxHealth);
    }

    public int GetHunger()
    {
        return hunger;
    }

    public void SetHunger(int hunger)
    {
        this.hunger = hunger;
    }

    public IItem GetEquippedItem()
    {
        return equippedItem;
    }

    public void SetEquippedItem(IItem item)
    {
        equippedItem = item;
    }

    public (int x, int y) GetPosition()
    {
        return (X, Y);
    }

    public void SetPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                Move(0, -1);
                break;
            case Direction.South:
                Move(0, 1);
                break;
            case Direction.West:
                Move(-1, 0);
                break;
            case Direction.East:
                Move(1, 0);
                break;
        }
    }

    public void Attack(Direction direction)
    {
        // Logic to attack an enemy in a given direction goes here
    }

    public void Eat(IItem food)
    {
        // Logic to eat a food item goes here
    }
}