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

class TextBasedRPG
{
    private readonly Player player;
    private readonly CommandParser commandParser;

    public TextBasedRPG(Player player)
    {
        this.player = player;
        this.commandParser = new CommandParser();
    }

    public bool ExecuteCommand(string input)
    {
        // Parse user input
        var command = commandParser.Parse(input);

        // Execute command
        if (command != null)
        {
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            command.Execute(player, parts.Skip(1).ToArray());
            if (player.Health <= 0)
            {
                Console.WriteLine("You have died. Game over.");
                return false;
            }

        }
        return true;
    }
}