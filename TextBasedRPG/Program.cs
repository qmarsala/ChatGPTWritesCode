namespace TextBasedRPG;

class Program
{
    static void Main(string[] args)
    {
        // Create a new player
        var player = new Player();

        // Create a new game object
        var game = new TextBasedRPG(player);

        // Main game loop
        while (true)
        {
            // Display prompt for user input
            Console.WriteLine("Enter a command:");

            // Read user input from console
            var input = Console.ReadLine().Trim();

            // Execute user command
            game.ExecuteCommand(input);
        }
    }
}
