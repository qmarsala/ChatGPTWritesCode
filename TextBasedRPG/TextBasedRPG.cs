namespace TextBasedRPG;

class TextBasedRPG
{
    private readonly Player player;
    private readonly CommandParser commandParser;

    public TextBasedRPG(Player player, CommandParser commandParser)
    {
        this.player = player;
        this.commandParser = commandParser;
    }

    public void Run()
    {
        while (player.IsAlive)
        {
            Console.WriteLine("What would you like to do?");
            string input = Console.ReadLine();
            ICommand command = commandParser.Parse(input);
            if (command == null)
            {
                Console.WriteLine("Invalid command.");
            }
            else
            {
                command.Execute(player);
            }
        }
        Console.WriteLine("You died.");
    }
}