namespace TextBasedRPG;
public interface IGame
{
    // Start the game loop
    void Start();

    // End the game loop
    void End();

    // Get the current game state
    GameState GetState();

    // Get the current player
    IPlayer GetPlayer();

    // Get the current world
    IWorld GetWorld();

    // Check if the game is over (due to win or lose conditions)
    bool IsGameOver();

    // Check if the player has won the game
    bool HasPlayerWon();

    // Check if the player has lost the game
    bool HasPlayerLost();
}
