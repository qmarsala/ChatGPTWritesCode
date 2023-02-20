
namespace TextBasedRPG;

class Program
{
    static void Main(string[] args)
    {
        IGame game = new Game();
        game.Start();
    }
}