
namespace TextBasedRPG;

public class World : IWorld
{
    private ITile[,] _tiles;
    private int _playerX;
    private int _playerY;

    public void GenerateWorld(int width, int height)
    {
        _tiles = new ITile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                _tiles[x, y] = new Tile { IsAccessible = true };
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
            _playerX = newX;
            _playerY = newY;
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

    public bool IsInsideWorld(int x, int y)
    {
        return x >= 0 && x < _tiles.GetLength(0) && y >= 0 && y < _tiles.GetLength(1);
    }

    public string GetTileDescription()
    {
        return GetTile(_playerX, _playerY).Description;
    }

    public (int x, int y) GetPlayerPosition()
    {
        return (_playerX, _playerY);
    }
}