
namespace TextBasedRPG;

public class TileGenerator
{
    private readonly string[] _tileDescriptions;

    public TileGenerator(string[] tileDescriptions)
    {
        _tileDescriptions = tileDescriptions;
    }

    public Tile GenerateTile(int x, int y)
    {
        var random = new Random(x * 1000 + y);

        if (x == 0 || y == 0 || x == _width - 1 || y == _height - 1)
        {
            return new Tile(TileType.Wall, "Wall");
        }

        // Generate a random tile type
        TileType type = random.Next(100) < _wallPercent ? TileType.Wall : TileType.Floor;

        // Ensure that the generated tile is accessible
        if (type == TileType.Wall && AreTilesSurroundedByWalls(x, y))
        {
            type = TileType.Floor;
        }

        return new Tile(type, GetTileDescription(type));
    }

    private bool AreTilesSurroundedByWalls(int x, int y)
    {
        return _tiles[x - 1, y].Type == TileType.Wall &&
               _tiles[x + 1, y].Type == TileType.Wall &&
               _tiles[x, y - 1].Type == TileType.Wall &&
               _tiles[x, y + 1].Type == TileType.Wall;
    }
}
