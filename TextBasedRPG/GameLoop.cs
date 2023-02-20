
namespace TextBasedRPG;

public class GameLoop
{
    private const int FramesPerDay = 6;
    private const int FramesPerDusk = 2;
    private const int FramesPerNight = 6;
    private const int FramesPerDawn = 2;

    private readonly IWorld _world;
    private readonly IPlayer _player;
    private readonly TileGenerator _tileGenerator;
    private int _frameCount;

    public GameLoop(IWorld world, IPlayer player, TileGenerator tileGenerator)
    {
        _world = world;
        _player = player;
        _tileGenerator = tileGenerator;
    }

    public void Run()
    {
        while (true)
        {
            UpdateWorldState();

            // Render the world and player information
            Render();

            // Wait for a short time to slow down the loop
            Thread.Sleep(100);
        }
    }

    private void UpdateWorldState()
    {
        // Increment the frame count and reset it to 0 after one full day/night cycle
        _frameCount = (_frameCount + 1) % (FramesPerDay + FramesPerDusk + FramesPerNight + FramesPerDawn);

        // Generate new tiles at the start of each day/dusk/night/dawn cycle
        if (_frameCount == 0 || _frameCount == FramesPerDay + FramesPerDusk || _frameCount == FramesPerDay + FramesPerDusk + FramesPerNight)
        {
            _world.GenerateWorld();
        }

        // Update the player's position and handle collisions with the environment
        var direction = GetPlayerInput();
        if (_world.CanMovePlayer(direction))
        {
            _world.MovePlayer(direction);
        }
    }

    public void Render()
    {
        Console.Clear();

        for (int y = 0; y < _world.Height; y++)
        {
            for (int x = 0; x < _world.Width; x++)
            {
                var tile = _world.GetTile(x, y);
                var playerPosition = _world.GetPlayerPosition();
                if (x == playerPosition.x && y == playerPosition.y)
                {
                    Console.Write("@");
                }
                else
                {
                    Console.Write(tile.Character);
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine("Player: " + _player.Name + " Health: " + _player.Health);
    }

    public Direction GetPlayerInput()
    {
        ConsoleKeyInfo input = Console.ReadKey(intercept: true);
        switch (input.Key)
        {
            case ConsoleKey.UpArrow:
                return Direction.North;
            case ConsoleKey.DownArrow:
                return Direction.South;
            case ConsoleKey.LeftArrow:
                return Direction.West;
            case ConsoleKey.RightArrow:
                return Direction.East;
            default:
                return Direction.None;
        }
    }

    private TimeOfDay GetTimeOfDay()
    {
        if (_frameCount < FramesPerDay)
        {
            return TimeOfDay.Day;
        }
        else if (_frameCount < FramesPerDay + FramesPerDusk)
        {
            return TimeOfDay.Dusk;
        }
        else if (_frameCount < FramesPerDay + FramesPerDusk + FramesPerNight)
        {
            return TimeOfDay.Night;
        }
        else
        {
            return TimeOfDay.Dawn;
        }
    }
}
