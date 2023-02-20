
namespace TextBasedRPG;

public class World : IWorld
{
    private ITile[,] _tiles;
    private List<IEntity> _entities;
    public int Width { get; }
    public int Height { get; }

    public World()
    {
        Width = 10;
        Height = 10;
        _tiles = new ITile[Width, Height];
        
        // Generate tiles
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                bool isExitTile = (x == 9 && y == 9);

                _tiles[x, y] = new Tile(isExitTile);
            }
        }

        GenerateEntities();
    }

    public void GenerateEntities()
    {
        var rand = new Random();
        for (int i = 0; i < _tiles.GetLength(0); i++)
        {
            for (int j = 0; j < _tiles.GetLength(1); j++)
            {
                var tile = _tiles[i, j];

                // Skip non-grass tiles
                if (tile.Type != TileType.Grass)
                {
                    continue;
                }

                // Random chance of generating an entity on this tile
                if (rand.Next(10) == 0)
                {
                    // Create a new entity
                    var entity = new Entity();
                    entity.X = j;
                    entity.Y = i;
                    entity.CurrentTile = tile;

                    // Add entity to the list of entities
                    _entities.Add(entity);
                }
            }
        }
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