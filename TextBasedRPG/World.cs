
namespace TextBasedRPG;

public class World : IWorld
{
    private ITile[,] tiles;
    private int width;
    private int height;
    private (int x, int y) playerPosition;

    public void GenerateWorld(int width, int height)
    {
        this.width = width;
        this.height = height;
        tiles = new ITile[width, height];

        // Generate tiles
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y] = new Tile();
            }
        }

        // Place player at center of map
        playerPosition = (width / 2, height / 2);
    }

    public ITile GetTile(int x, int y)
    {
        return tiles[x, y];
    }

    public void MovePlayerTo(int x, int y)
    {
        playerPosition = (x, y);
    }

    public bool CanMovePlayer(Direction direction)
    {
        int x = playerPosition.x;
        int y = playerPosition.y;

        switch (direction)
        {
            case Direction.North:
                y -= 1;
                break;
            case Direction.South:
                y += 1;
                break;
            case Direction.East:
                x += 1;
                break;
            case Direction.West:
                x -= 1;
                break;
        }

        return IsInsideWorld(x, y) && tiles[x, y].IsAccessible;
    }

    public (int x, int y) GetPlayerPosition()
    {
        return playerPosition;
    }

    private bool IsInsideWorld(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    public void MovePlayer(Direction direction)
    {
        if (CanMovePlayer(direction))
        {
            int x = playerPosition.x;
            int y = playerPosition.y;

            switch (direction)
            {
                case Direction.North:
                    MovePlayerTo(x, y - 1);
                    break;
                case Direction.South:
                    MovePlayerTo(x, y + 1);
                    break;
                case Direction.East:
                    MovePlayerTo(x + 1, y);
                    break;
                case Direction.West:
                    MovePlayerTo(x - 1, y);
                    break;
            }
        }
    }

    public string GetTileDescription()
    {
        if (!IsInsideWorld(playerPosition.x, playerPosition.y))
        {
            return "You are at the edge of the world.";
        }

        ITile tile = GetTile(playerPosition.x, playerPosition.y);

        return tile.Description;
    }
}