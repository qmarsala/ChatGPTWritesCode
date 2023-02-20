namespace TextBasedRPG;

class Program
{
    static void Main(string[] args)
    {
        // Create a new player with starting stats
        var player = new Player("John");

        // Create a new command parser
        var outputService = new ConsoleOutputService();
        var commandParser = new CommandParser(outputService);

        // Create a new game instance
        var game = new TextBasedRPG(player, commandParser);

        // Run the game loop
        game.Run();

        // Game has ended
        Console.WriteLine("Thanks for playing!");
    }
}