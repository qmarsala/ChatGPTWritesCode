
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
            _world.GenerateWorld(_world.Width, _world.Height, _tileGenerator);
        }

        // Update the player's position and handle collisions with the environment
        var direction = GetPlayerInput();
        if (_world.CanMovePlayer(direction))
        {
            _world.MovePlayer(direction);
        }
    }

    private void Render()
    {
        // Render the world and player information based on the current time of day
        var timeOfDay = GetTimeOfDay();
        switch (timeOfDay)
        {
            case TimeOfDay.Day:
                // Render the world with a bright and clear sky
                break;
            case TimeOfDay.Dusk:
                // Render the world with a dim and orange-tinted sky
                break;
            case TimeOfDay.Night:
                // Render the world with a dark and starry sky
                break;
            case TimeOfDay.Dawn:
                // Render the world with a gradually brightening sky
                break;
            default:
                throw new InvalidOperationException("Invalid time of day");
        }

        // Render the player's position and status
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
