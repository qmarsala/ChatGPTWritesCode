
namespace TextBasedRPG;

public interface IWorld
{
    int Width { get; }
    int Height { get; }

    ITile GetTileAt(int x, int y);
    void Update();
}
