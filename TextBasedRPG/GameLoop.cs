
namespace TextBasedRPG;

public class GameLoop
{
    private IWorld world;
    private IPlayer player;

    public GameLoop(IWorld world, IPlayer player)
    {
        this.world = world;
        this.player = player;
    }

    public void Run()
    {
        while (true)
        {
            // Get current player position
            var playerPos = world.GetPlayerPosition();

            // Get tile at player position and display description
            var tile = world.GetTile(playerPos.x, playerPos.y);
            Console.WriteLine(tile.Description);

            // Get user input for movement direction
            Console.Write("Which direction do you want to go? ");
            var input = Console.ReadLine();

            // Parse user input to direction
            if (Enum.TryParse<Direction>(input, true, out var direction))
            {
                // Move player if direction is valid
                if (world.CanMovePlayer(direction))
                {
                    world.MovePlayer(direction);
                }
                else
                {
                    Console.WriteLine("You can't move in that direction.");
                }
            }
            else
            {
                Console.WriteLine("Invalid direction.");
            }
        }
    }
}
