
namespace TextBasedRPG;

public class GameLoop
{
    private IWorld _world;
    private IPlayer _player;

    public GameLoop(IWorld world, IPlayer player)
    {
        _world = world;
        _player = player;
    }

    public void Run()
    {
        while (_player.IsAlive)
        {
            var (playerX, playerY) = _world.GetPlayerPosition();
            Console.WriteLine(_world.GetTileDescription(playerX, playerY));

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

            Console.WriteLine();
        }

        Console.WriteLine("Game over.");
    }
}
