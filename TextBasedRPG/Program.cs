
namespace TextBasedRPG;

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