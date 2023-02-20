
namespace TextBasedRPG;

class Program
{
    static void Main(string[] args)
    {
        var tileGenerator = new TileGenerator(10);
        var world = new World(10, 10, tileGenerator);
        world.GenerateWorld(10, 10);

        var player = new Player("John", 10);
        var gameLoop = new GameLoop(world, player, tileGenerator);

        gameLoop.Run();
    }
}