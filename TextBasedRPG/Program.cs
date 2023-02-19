partial class Program
{
    static void Main(string[] args)
    {
        // Create a new player
        var player = new Player();

        // Main game loop
        while (true)
        {
            // Display prompt for user input
            Console.WriteLine("Enter a command:");

            // Read user input from console
            var input = Console.ReadLine().Trim().ToLower();

            // Process user input
            if (input == "quit")
            {
                // Exit the game loop
                break;
            }
            else if (input.StartsWith("fish"))
            {
                // TODO: Implement fishing logic
            }
            else if (input.StartsWith("chop"))
            {
                // TODO: Implement woodcutting logic
            }
            else if (input.StartsWith("make fire"))
            {
                // TODO: Implement firemaking logic
            }
            else if (input.StartsWith("cook"))
            {
                // TODO: Implement cooking logic
            }
            else if (input.StartsWith("fight"))
            {
                // TODO: Implement combat logic
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }
    }
}