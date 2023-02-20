
namespace TextBasedRPG;

class Program
{
   static void Main(string[] args)
{
    // Create a new world with a size of 10x10 tiles
    IWorld world = new World();
    world.GenerateWorld(10, 10);

    // Initialize player location to center of the world
    world.MovePlayerTo(5, 5);

    // Game loop
    while (true)
    {
        // Get player input
        Console.WriteLine("Enter a direction to move (north, south, east, west):");
        string input = Console.ReadLine();

        // Parse input and move player if valid
        if (Enum.TryParse(input, true, out Direction direction))
        {
            if (world.CanMovePlayer(direction))
            {
                world.MovePlayer(direction);
                Console.WriteLine($"Moved {direction.ToString().ToUpper()}");
            }
            else
            {
                Console.WriteLine("Cannot move in that direction");
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
        }

        // Display current tile description
        Console.WriteLine(world.GetTileDescription());
    }
}
}