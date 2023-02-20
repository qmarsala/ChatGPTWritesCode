
namespace TextBasedRPG;

public class World : IWorld
{
    private ITile[,] _tiles;
    private List<IEntity> _entities = new List<IEntity>();
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

    public void GenerateTiles()
    {
        _tiles = new ITile[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                ITile tile;
                if (x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
                {
                    tile = new WallTile();
                }
                else if (_random.NextDouble() < _exitChance)
                {
                    tile = new ExitTile();
                }
                else if (_random.NextDouble() < _enemyChance)
                {
                    tile = new EnemyTile();
                    _entities.Add(new Entity { X = x, Y = y, Health = 1, CurrentTile = tile });
                }
                else
                {
                    tile = new FloorTile();
                }

                // Set the symbol for the tile based on its type
                if (tile is WallTile)
                {
                    tile.Symbol = "#";
                }
                else if (tile is ExitTile)
                {
                    tile.Symbol = "E";
                }
                else if (tile is EnemyTile)
                {
                    tile.Symbol = "X";
                }
                else if (tile is FloorTile)
                {
                    tile.Symbol = ".";
                }

                _tiles[x, y] = tile;
            }
        }
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