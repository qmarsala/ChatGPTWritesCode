
namespace TextBasedRPG;

public class World : IWorld
{
    private ITile[,] _tiles;
    private List<IEntity> _entities;
    public int Width { get; }
    public int Height { get; }

    public World(ITile[,] tiles, List<IEntity> entities)
    {
        Width = tiles.GetLength(0);
        Height = tiles.GetLength(1);
        _tiles = tiles;
        _entities = entities;
    }

    public ITile GetTileAt(int x, int y)
    {
        return _tiles[x, y];
    }

    public List<IEntity> GetEntities()
    {
        return _entities;
    }

    public void Update()
    {
        foreach (var entity in _entities)
        {
            entity.CurrentTile = GetTileAt(entity.X, entity.Y);

            // Update hunger and health
            if (entity is IPlayer player)
            {
                player.Hunger += 1;
                player.Health -= 1;
            }

            // Check for interactions with other entities
            foreach (var otherEntity in _entities)
            {
                if (entity != otherEntity && entity.IsAdjacent(otherEntity))
                {
                    entity.Attack(otherEntity);
                }
            }
        }
    }

    public bool IsOnExitTile(IEntity entity)
    {
        var tile = GetTileAt(entity.X, entity.Y);
        return tile.IsExit;
    }
}