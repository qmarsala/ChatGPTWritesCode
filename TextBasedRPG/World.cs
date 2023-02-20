
namespace TextBasedRPG;

public class World : IWorld
{
    private ITile[,] _tiles;
    private int _playerX;
    private int _playerY;
    public int Width { get; private set; }
    public int Height { get; private set; }
    private readonly TileGenerator _tileGenerator;

    public World(int width, int height, TileGenerator tileGenerator)
    {
        _tiles = new ITile[width, height];
        Width = width;
        Height = height;
        _tileGenerator = tileGenerator;
    }

    public void GenerateWorld()
    {
        _tiles = new ITile[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                _tiles[x, y] = _tileGenerator.GenerateTile();
            }
        }
    }

    public ITile GetTile(int x, int y)
    {
        if (IsInsideWorld(x, y))
        {
            return _tiles[x, y];
        }
        else
        {
            throw new ArgumentException("Coordinates are outside the world bounds");
        }
    }

    public bool CanMovePlayer(Direction direction)
    {
        var (newX, newY) = GetNewPlayerPosition(direction);
        return IsInsideWorld(newX, newY) && GetTile(newX, newY).IsAccessible;
    }

    public void MovePlayer(Direction direction)
    {
        if (CanMovePlayer(direction))
        {
            var (newX, newY) = GetNewPlayerPosition(direction);
            UpdatePlayerPosition(newX, newY);
        }
    }

    public void MovePlayerTo(int x, int y)
    {
        if (IsInsideWorld(x, y) && GetTile(x, y).IsAccessible)
        {
            _playerX = x;
            _playerY = y;
        }
        else
        {
            throw new ArgumentException("Cannot move player to the specified position");
        }
    }

    private (int, int) GetNewPlayerPosition(Direction direction)
    {
        var (dx, dy) = direction switch
        {
            Direction.North => (0, -1),
            Direction.South => (0, 1),
            Direction.West => (-1, 0),
            Direction.East => (1, 0),
            _ => throw new ArgumentException("Invalid direction"),
        };

        return (_playerX + dx, _playerY + dy);
    }

    public void UpdatePlayerPosition(int newPlayerX, int newPlayerY)
    {
        // Check if the player has reached the boundary of the world
        if (newPlayerX < 0)
        {
            newPlayerX = Width - 1;
            GenerateWorld();
        }
        else if (newPlayerX >= Width)
        {
            newPlayerX = 0;
            GenerateWorld();
        }
        else if (newPlayerY < 0)
        {
            newPlayerY = Height - 1;
            GenerateWorld();
        }
        else if (newPlayerY >= Height)
        {
            newPlayerY = 0;
            GenerateWorld();
        }

        MovePlayerTo(newPlayerX, newPlayerY);
    }

    public bool IsInsideWorld(int x, int y)
    {
        return x >= 0 && x < _tiles.GetLength(0) && y >= 0 && y < _tiles.GetLength(1);
    }

    public string GetTileDescription(int x, int y)
    {
        return GetTile(x, y).Description;
    }

    public (int x, int y) GetPlayerPosition()
    {
        return (_playerX, _playerY);
    }
}