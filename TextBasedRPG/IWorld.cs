
namespace TextBasedRPG;

public interface IWorld
{
    // Get the size of the world
    int GetSize();

    // Get the tile at a specific location
    ITile GetTile(int x, int y);

    // Set the tile at a specific location
    void SetTile(int x, int y, ITile tile);

    // Check if a given position is within the world bounds
    bool IsPositionWithinBounds(int x, int y);

    // Add an enemy to the world
    void AddEnemy(IEnemy enemy);

    // Remove an enemy from the world
    void RemoveEnemy(IEnemy enemy);

    // Get the list of enemies in the world
    List<IEnemy> GetEnemies();

    // Add an item to the world
    void AddItem(IItem item);

    // Remove an item from the world
    void RemoveItem(IItem item);

    // Get the list of items in the world
    List<IItem> GetItems();
    
    void InteractWithTile(IPlayer player, ITile tile);

    ITile UpdatePlayerPosition(IPlayer player, Direction direction);

    bool IsOnExitTile(IPlayer player);
}
