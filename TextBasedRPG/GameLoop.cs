
namespace TextBasedRPG;

public class GameLoop
{
    private readonly IWorld _world;
    private readonly IPlayer _player;
    private readonly TileGenerator _tileGenerator;

    private int _loopCount;

    public GameLoop(IWorld world, IPlayer player, TileGenerator tileGenerator)
    {
        _world = world;
        _player = player;
        _tileGenerator = tileGenerator;
        _loopCount = 0;
    }

    public void Run()
    {
        while (_player.IsAlive)
        {
            var (playerX, playerY) = _world.GetPlayerPosition();
            var tile = _world.GetTile(playerX, playerY);
            Console.WriteLine(tile.Description);

            Console.Write("Enter a direction (N/S/E/W) or 'Q' to quit: ");
            var input = Console.ReadLine()?.ToUpper();
            if (input == null)
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (input)
            {
                case "N":
                    _world.MovePlayer(Direction.North);
                    break;
                case "S":
                    _world.MovePlayer(Direction.South);
                    break;
                case "E":
                    _world.MovePlayer(Direction.East);
                    break;
                case "W":
                    _world.MovePlayer(Direction.West);
                    break;
                case "Q":
                    Console.WriteLine("Quitting game...");
                    return;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }

            _loopCount++;
            if (_loopCount % 6 == 0)
            {
                Console.WriteLine("Switching to " + (_world.IsDay ? "night" : "day") + " mode...");
                _world.ToggleDayNight();
            }

            if (_loopCount % 12 == 0)
            {
                _loopCount = 0;
                Console.WriteLine("Generating new tiles...");
                _world.GenerateTiles(_tileGenerator);
            }

            Console.WriteLine();
        }

        Console.WriteLine("Game over.");
    }
}