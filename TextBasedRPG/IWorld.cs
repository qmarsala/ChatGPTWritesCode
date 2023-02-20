
namespace TextBasedRPG;

public interface IWorld
{
    // generate the world with the given size
    void GenerateWorld(int width, int height);

    // get the tile at the specified position
    ITile GetTile(int x, int y);

    // move the player to the specified position
    void MovePlayerTo(int x, int y);

    // check if the player can move in the specified direction
    bool CanMovePlayer(Direction direction);
    void MovePlayer(Direction direction);
    // get a description of the tile at the specified position
    string GetTileDescription(int x, int y);
}
