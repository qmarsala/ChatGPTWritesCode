
namespace TextBasedRPG;

public class GameLoop
{
    private readonly IWorld _world;
    private readonly IPlayer _player;

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
            var tileDescription = _world.GetTileDescription(playerX, playerY);
            if (tileDescription == null)
            {
                Console.WriteLine("Invalid tile description.");
                continue;
            }
            Console.WriteLine(tileDescription);

            Console.Write("Enter a direction (N/S/E/W) or 'Q' to quit: ");
            var input = Console.ReadLine()?.ToUpper();
            if (string.IsNullOrWhiteSpace(input) || !IsValidInput(input))
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
            }

            Console.WriteLine();
        }

        Console.WriteLine("Game over.");
    }

    private static bool IsValidInput(string input)
    {
        return input == "N" || input == "S" || input == "E" || input == "W" || input == "Q";
    }
}