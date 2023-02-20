
namespace TextBasedRPG;

class Program
{
    static void Main(string[] args)
    {
        IWorld world = new World();
        world.GenerateWorld(10, 10);

        IPlayer player = new Player("John", 100);

        GameLoop game = new GameLoop(world, player);
        game.Run();
    }
}