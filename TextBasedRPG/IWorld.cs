
namespace TextBasedRPG;

public interface IWorld
{
    ITile GetTileAt(int x, int y);
    void SetTileAt(int x, int y, ITile tile);
}
