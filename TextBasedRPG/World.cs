
namespace TextBasedRPG;

public class World : IWorld
{
    private ITile[,] _tiles;
    private IPlayer _player;

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

    public void MovePlayer(Direction direction)
    {
        int x = _player.X;
        int y = _player.Y;

        switch (direction)
        {
            case Direction.Up:
                y -= 1;
                break;
            case Direction.Down:
                y += 1;
                break;
            case Direction.Left:
                x -= 1;
                break;
            case Direction.Right:
                x += 1;
                break;
            default:
                throw new ArgumentException("Invalid direction");
        }

        if (CanMovePlayer(direction))
        {
            _player.X = x;
            _player.Y = y;
        }
    }

    public bool CanMovePlayer(Direction direction)
    {
        int x = _player.X;
        int y = _player.Y;

        switch (direction)
        {
            case Direction.Up:
                y -= 1;
                break;
            case Direction.Down:
                y += 1;
                break;
            case Direction.Left:
                x -= 1;
                break;
            case Direction.Right:
                x += 1;
                break;
            default:
                throw new ArgumentException("Invalid direction");
        }

        return IsInsideWorld(x, y) && _tiles[x, y].IsAccessible;
    }

    public bool IsInsideWorld(int x, int y)
    {
        return x >= 0 && x < _tiles.GetLength(0) && y >= 0 && y < _tiles.GetLength(1);
    }

    public string GetTileDescription(int x, int y)
    {
        return GetTile(x, y).Description;
    }

    public (int X, int Y) GetPlayerPosition()
    {
        return (_player.X, _player.Y);
    }
}