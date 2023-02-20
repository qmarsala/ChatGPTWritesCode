
namespace TextBasedRPG;

public class World : IWorld
{
    private ITile[,] _tiles;
    public int Width { get; }
    public int Height { get; }

    public World(int width, int height)
    {
        Width = width;
        Height = height;
        _tiles = new ITile[width, height];

        // Initialize all the tiles to be of type "grass" and unexplored
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                _tiles[x, y] = new Tile { Type = TileType.Grass, IsExplored = false };
            }
        }
    }

    public ITile GetTileAt(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
        {
            return null;
        }

        return _tiles[x, y];
    }

    public void SetTileAt(int x, int y, ITile tile)
    {
        if (x >= 0 && x < Width && y >= 0 && y < Height)
        {
            _tiles[x, y] = tile;
        }
    }
}
