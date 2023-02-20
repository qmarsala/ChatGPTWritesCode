
namespace TextBasedRPG;

public class World
{
    private readonly Random _random;
    private readonly ITileGenerator _tileGenerator;
    private readonly int _width;
    private readonly int _height;
    private readonly Player _player;
    private ITile[,] _tiles;

    public World(Random random, ITileGenerator tileGenerator, int width, int height)
    {
        _random = random;
        _tileGenerator = tileGenerator;
        _width = width;
        _height = height;
        _player = new Player();

        GenerateWorld();
    }

    public ITile[,] Tiles => _tiles;

    public int Width => _width;

    public int Height => _height;

    public Player Player => _player;

    public bool UpdatePlayerPosition(int newPlayerX, int newPlayerY)
    {
        // Check if the player has reached the boundary of the world
        if (newPlayerX < 0 || newPlayerX >= Width || newPlayerY < 0 || newPlayerY >= Height)
        {
            return false;
        }

        MovePlayerTo(newPlayerX, newPlayerY);

        if (_tiles[newPlayerX, newPlayerY] is ExitTile)
        {
            _player.Won = true;
        }

        return true;
    }

    private void GenerateWorld()
    {
        _tiles = new ITile[_width, _height];

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _tiles[x, y] = _tileGenerator.GenerateTile(_random);
            }
        }

        // Place the player in a random location
        int playerX = _random.Next(_width);
        int playerY = _random.Next(_height);
        _player.SetPosition(playerX, playerY);
        _tiles[playerX, playerY].IsPlayerOnTile = true;
    }

    private void MovePlayerTo(int x, int y)
    {
        int oldPlayerX = _player.X;
        int oldPlayerY = _player.Y;

        _tiles[oldPlayerX, oldPlayerY].IsPlayerOnTile = false;
        _tiles[x, y].IsPlayerOnTile = true;

        _player.SetPosition(x, y);

        _player.IncreaseDaysSurvived();
    }
}