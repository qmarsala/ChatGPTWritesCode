namespace TextBasedRPG;

public class Game : IGame
{
    private IPlayer _player;
    private IWorld _world;
    private GameState _state;

    public Game(IPlayer player, IWorld world)
    {
        _player = player;
        _world = world;
        _state = GameState.Running;
    }

    public void Start()
    {
        Console.WriteLine("Starting game...");

        // Initialize game loop
        while (_state == GameState.Running)
        {
            // Update game state
            Update();

            // Render game state
            Render();
        }

        Console.WriteLine("Game over.");
    }

    public void Update()
    {
        // Get player input
        Direction input = _player.GetInput();

        // Move the player
        _player.Move(input);

        // Decrement player's hunger level
        _player.Hunger--;

        // Check if player is still alive
        if (!_player.IsAlive)
        {
            _state = GameState.Lost;
            return;
        }
        // Check if the player is starving
        if (_player.Hunger <= 0)
        {
            _player.Health--;
        }
        // Check if player has won
        if (HasPlayerWon())
        {
            _state = GameState.Won;
            return;
        }

        // Update world state
        _world.Update(_player);
    }

    public void Render()
    {
        // Clear the console
        Console.Clear();

        // Iterate over each tile in the world
        for (int y = 0; y < _world.Height; y++)
        {
            for (int x = 0; x < _world.Width; x++)
            {
                ITile tile = _world.GetTileAt(x, y);

                // Print the tile's symbol to the console
                Console.Write(tile.Symbol);
            }

            // Move to the next line
            Console.WriteLine();
        }

        // Print the player's position and stats
        Console.WriteLine($"Player position: ({_player.X}, {_player.Y})");
        Console.WriteLine($"Health: {_player.Health} / {_player.MaxHealth}");
        Console.WriteLine($"Hunger: {_player.Hunger} / 100");
        Console.WriteLine($"Equipped item: {_player.EquippedItem?.Name ?? "None"}");
    }

    public void End()
    {
        // End the game loop
    }

    public GameState GetState()
    {
        return _state;
    }

    public IPlayer GetPlayer()
    {
        return _player;
    }

    public IWorld GetWorld()
    {
        return _world;
    }

    public bool IsGameOver()
    {
        return HasPlayerWon() || HasPlayerLost();
    }

    public bool HasPlayerWon()
    {
        return _world.IsOnExitTile(_player) || _player.DaysSurvived >= 100;
    }

    public bool HasPlayerLost()
    {
        return !_player.IsAlive;
    }
}
