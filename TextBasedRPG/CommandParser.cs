namespace TextBasedRPG;

class CommandParser
{
    private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

    public CommandParser()
    {
        commands.Add("quit", new QuitCommand());
        commands.Add("fish", new FishCommand());
        commands.Add("chop", new ChopCommand());
        commands.Add("fire", new FireCommand());
        commands.Add("cook", new CookCommand());
        commands.Add("fight", new FightCommand());
    }

    public void Parse(Player player, string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var commandName = parts[0].ToLower();

        if (!commands.TryGetValue(commandName, out ICommand command))
        {
            Console.WriteLine("Invalid command.");
            return;
        }

        command.Execute(player, parts.Skip(1).ToArray());
    }
}
