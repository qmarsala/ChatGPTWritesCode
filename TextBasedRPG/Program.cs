namespace TextBasedRPG;

class Program
{
    static void Main(string[] args)
    {
        // Create a new player
        var player = new Player();

        // Create a command parser
        var commandParser = new CommandParser();

        // Main game loop
        while (true)
        {
            // Display prompt for user input
            Console.WriteLine("Enter a command:");

            // Read user input from console
            var input = Console.ReadLine().Trim();

            // Parse user input and execute command
            commandParser.Parse(player, input);
        }
    }
}