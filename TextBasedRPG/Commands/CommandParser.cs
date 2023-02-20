namespace TextBasedRPG;

class CommandParser
{
    private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

    public CommandParser()
    {
        commands = new Dictionary<string, ICommand>
        {
            { FishingCommand.CommandString, new FishingCommand(10) },
            { WoodcuttingCommand.CommandString, new WoodcuttingCommand(10) },
            { FiremakingCommand.CommandString, new FiremakingCommand(10) },
            { CookingCommand.CommandString, new CookingCommand(10) },
            { CombatCommand.CommandString, new CombatCommand(10) },
            { QuitCommand.CommandString, new QuitCommand() }
        };
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