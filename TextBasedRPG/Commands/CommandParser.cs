namespace TextBasedRPG;

class CommandParser
{
    private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

    public CommandParser(IOutputService outputService)
    {
        commands = new Dictionary<string, ICommand>
        {
            { FishingCommand.CommandString, new FishingCommand(outputService, 10) },
            { WoodcuttingCommand.CommandString, new WoodcuttingCommand(outputService, 10) },
            { FiremakingCommand.CommandString, new FiremakingCommand(outputService, 10) },
            { CookingCommand.CommandString, new CookingCommand(outputService, 10) },
            { CombatCommand.CommandString, new CombatCommand(outputService, 10) },
            { QuitCommand.CommandString, new QuitCommand(outputService) }
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