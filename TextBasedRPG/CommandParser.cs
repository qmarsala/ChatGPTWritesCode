namespace TextBasedRPG;

class CommandParser
{
    private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

    public CommandParser()
    {
        commands.Add("quit", new QuitCommand());
        commands.Add("fish", new FishingCommand());
        commands.Add("chop", new WoodcuttingCommand());
        commands.Add("fire", new FiremakingCommand());
        commands.Add("cook", new CookingCommand());
        commands.Add("fight", new CombatCommand());
    }

    public ICommand Parse(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var commandName = parts[0].ToLower();

        if (!commands.TryGetValue(commandName, out ICommand command))
        {
            Console.WriteLine("Invalid command.");
            return null;
        }

        return command;
    }
}