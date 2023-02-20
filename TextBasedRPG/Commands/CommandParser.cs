namespace TextBasedRPG;

class CommandParser
{
    private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

    public CommandParser()
    {
        commands = new Dictionary<string, ICommand>
        {
            { FishingCommand.CommandString, new FishingCommand(player, 10) },
            { WoodcuttingCommand.CommandString, new WoodcuttingCommand(player, 10) },
            { FiremakingCommand.CommandString, new FiremakingCommand(player, 10) },
            { CookingCommand.CommandString, new CookingCommand(player, 10) },
            { CombatCommand.CommandString, new CombatCommand(player, 10) },
            { QuitCommand.CommandString, new QuitCommand(player) }
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