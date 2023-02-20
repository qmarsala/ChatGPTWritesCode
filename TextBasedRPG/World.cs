
namespace TextBasedRPG;

public class World : IWorld
{
    private ITile[,] _tiles;
    private IPlayer _player;
    private int _playerX;
    private int _playerY;
    private int width;
    private int height;

    public World(int width, int height, IPlayer player)
    {
        this.width = width;
        this.height = height;
        _player = player;
        GenerateWorld(width, height);
    }

    public void GenerateWorld(int width, int height)
    {
        _tiles = new ITile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                _tiles[x, y] = new Tile();
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

        return _tiles[x, y];
    }

    public void MovePlayerTo(int x, int y)
    {
        _playerX = x;
        _playerY = y;
    }

    public bool CanMovePlayer(Direction direction)
    {
        int x = _playerX;
        int y = _playerY;

        switch (direction)
        {
            case Direction.North:
                y -= 1;
                break;
            case Direction.South:
                y += 1;
                break;
            case Direction.West:
                x -= 1;
                break;
            case Direction.East:
                x += 1;
                break;
            default:
                throw new ArgumentException("Invalid direction.");
        }

        return IsInsideWorld(x, y) && _tiles[x, y].IsAccessible;
    }
}
