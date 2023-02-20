
namespace TextBasedRPG;

class Program
{
    static void Main(string[] args)
    {
        var player = new Player();
        var world = new World();
        var game = new Game(player, world);
        game.Start();
    }
}