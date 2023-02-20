
namespace TextBasedRPG;

public interface IWorld
{
    int Width { get; }
    int Height { get; }

    ITile[,] Tiles { get; }

    ITile GetTileAt(int x, int y);
    void SetTileAt(int x, int y, ITile tile);

    void GenerateWorld();
}

