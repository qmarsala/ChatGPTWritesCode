
namespace TextBasedRPG;

public class World : IWorld
{
    private ITile[,] tiles;
    private IPlayer player;
    private int width;
    private int height;

    public World(int width, int height, IPlayer player)
    {
        this.width = width;
        this.height = height;
        this.player = player;
        GenerateWorld(width, height);
    }

    public void GenerateWorld(int width, int height)
    {
        tiles = new ITile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y] = new Tile();
            }
        }

        // Set player starting position
        int startX = width / 2;
        int startY = height / 2;
        MovePlayerTo(startX, startY);
    }

    public ITile GetTile(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            return null;
        }

        return tiles[x, y];
    }

    public void MovePlayerTo(int x, int y)
    {
        player.X = x;
        player.Y = y;
    }

    public bool CanMovePlayer(Direction direction)
    {
        int newX = player.X;
        int newY = player.Y;

        switch (direction)
        {
            case Direction.Up:
                newY--;
                break;
            case Direction.Down:
                newY++;
                break;
            case Direction.Left:
                newX--;
                break;
            case Direction.Right:
                newX++;
                break;
        }

        if (newX < 0 || newX >= width || newY < 0 || newY >= height)
        {
            return false;
        }

        ITile newTile = GetTile(newX, newY);

        return newTile != null && newTile.IsAccessible;
    }
}
