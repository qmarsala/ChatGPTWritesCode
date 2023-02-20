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
        while (!IsGameOver())
        {
            GameLoop();
        }
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

    private void GameLoop()
    {
        // Get player input
        Direction direction = _player.GetInput();

        // Update player position
        ITile newTile = _world.UpdatePlayerPosition(_player, direction);

        // Interact with tile
        _world.InteractWithTile(_player, newTile);

        // Update game state
        if (HasPlayerWon())
        {
            _state = GameState.Won;
        }
        else if (HasPlayerLost())
        {
            _state = GameState.Lost;
        }
    }
}
