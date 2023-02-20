
namespace TextBasedRPG;


public class GameLoop {
    private IWorld world;
    private IPlayer player;

    public GameLoop(IWorld world, IPlayer player) {
        this.world = world;
        this.player = player;
    }

    public void Run() {
        while (true) {
            // Print the current location and description
            Console.WriteLine($"You are at {player.X},{player.Y}: {world.GetTileDescription(player.X, player.Y)}");

            // Get user input
            Console.Write("Enter a direction (N/S/E/W): ");
            var input = Console.ReadLine();

            // Parse input and move player if valid
            if (Enum.TryParse(input, out Direction direction)) {
                if (world.CanMovePlayer(direction)) {
                    world.MovePlayer(direction);
                } else {
                    Console.WriteLine("You can't move in that direction.");
                }
            } else {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create world and player instances
        IWorld world = new World();
        world.GenerateWorld(10, 10);
        IPlayer player = new Player();

        // Create game loop and run it
        GameLoop gameLoop = new GameLoop(world, player);
        gameLoop.Run();
    }
}