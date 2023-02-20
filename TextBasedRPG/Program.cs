
namespace TextBasedRPG;

public interface IWorld {
    // generate the world with the given size
    void GenerateWorld(int width, int height);

    // get the tile at the specified position
    ITile GetTile(int x, int y);

    // move the player to the specified position
    void MovePlayerTo(int x, int y);

    // check if the player can move in the specified direction
    bool CanMovePlayer(Direction direction);
}



public interface IItem
{
    string Name { get; }
    int Weight { get; }
    void Use(IPlayer player);
}


public interface IPlayer
{
    string Name { get; }
    int Health { get; }
    bool IsAlive { get; }
    IEnumerable<IItem> Inventory { get; }

    void TakeDamage(int amount);
    void Heal(int amount);
    void AddToInventory(IItem item);
    void RemoveFromInventory(IItem item);
}



class Program
{
    static void Main(string[] args)
    {
       
    }
}