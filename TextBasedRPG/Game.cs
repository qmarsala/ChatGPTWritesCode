namespace TextBasedRPG;

public class Game
{
    private readonly World _world;
    private readonly Player _player;
    private readonly GameLoop _gameLoop;

    public Game(int worldWidth, int worldHeight)
    {
        _world = new World(worldWidth, worldHeight);
        _player = new Player();
        _gameLoop = new GameLoop(_world, _player);
    }

    public void Run()
    {
        while (!_gameLoop.GameOver)
        {
            _gameLoop.Update();
            _gameLoop.Render();
        }

        if (_gameLoop.HasPlayerWon)
        {
            Console.WriteLine("Congratulations, you won the game!");
        }
        else
        {
            Console.WriteLine("Game over!");
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}