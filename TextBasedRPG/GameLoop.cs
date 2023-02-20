
namespace TextBasedRPG;

public class GameLoop
{
    private const int NumDayLoops = 6;
    private const int NumDuskLoops = 2;
    private const int NumNightLoops = 6;
    private const int NumDawnLoops = 2;

    private readonly IWorld _world;
    private readonly IPlayer _player;
    private readonly ITileGenerator _tileGenerator;

    private int _loopCount = 0;

    public GameLoop(IWorld world, IPlayer player, ITileGenerator tileGenerator)
    {
        _world = world;
        _player = player;
        _tileGenerator = tileGenerator;
    }

    public void Run()
    {
        while (true)
        {
            // Get player input
            var playerInput = GetPlayerInput();

            // Update player position
            var newPlayerX = _player.X;
            var newPlayerY = _player.Y;

            switch (playerInput)
            {
                case PlayerInput.MoveUp:
                    newPlayerY--;
                    break;
                case PlayerInput.MoveDown:
                    newPlayerY++;
                    break;
                case PlayerInput.MoveLeft:
                    newPlayerX--;
                    break;
                case PlayerInput.MoveRight:
                    newPlayerX++;
                    break;
            }

            _world.UpdatePlayerPosition(newPlayerX, newPlayerY);

            // Check win conditions
            if (_world.IsGameOver)
            {
                Console.WriteLine("Congratulations! You have reached the exit and won the game!");
                break;
            }

            if (_world.DayCount >= 100)
            {
                Console.WriteLine("You have survived for 100 days! You win!");
                break;
            }

            // Render game
            Console.Clear();
            Console.WriteLine($"Day {_world.DayCount} ({_world.TimeOfDay})");
            Console.WriteLine(_world.Render(_player.X, _player.Y));

            // Wait for some time
            Thread.Sleep(GetLoopDuration());
        }
    }

    private PlayerInput GetPlayerInput()
    {
        while (true)
        {
            Console.Write("Enter a direction to move (up, down, left, right): ");
            var inputStr = Console.ReadLine().Trim().ToLower();

            if (inputStr == "up")
            {
                return PlayerInput.MoveUp;
            }
            else if (inputStr == "down")
            {
                return PlayerInput.MoveDown;
            }
            else if (inputStr == "left")
            {
                return PlayerInput.MoveLeft;
            }
            else if (inputStr == "right")
            {
                return PlayerInput.MoveRight;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    private int GetLoopDuration()
    {
        if (_loopCount % NumDayLoops == 0)
        {
            _world.SetTimeOfDay(TimeOfDay.Day);
            return 2000;
        }
        else if (_loopCount % NumDuskLoops == 0)
        {
            _world.SetTimeOfDay(TimeOfDay.Dusk);
            return 500;
        }
        else if (_loopCount % NumNightLoops == 0)
        {
            _world.SetTimeOfDay(TimeOfDay.Night);
            return 2000;
        }
        else if (_loopCount % NumDawnLoops == 0)
        {
            _world.SetTimeOfDay(TimeOfDay.Dawn);
            return 500;
        }
        else
        {
            _world.SetTimeOfDay(TimeOfDay.Day);
            return 2000;
        }
    }
}