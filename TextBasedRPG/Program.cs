
namespace TextBasedRPG;

class Program
{
    static void Main(string[] args)
    {
        var player = new Player(5, 5);
        var entities = new List<IEntity> { player };
        var world = new World(tiles, entities);
        var game = new Game(player, world);
        game.Start();
    }
}