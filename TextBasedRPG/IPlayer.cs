
namespace TextBasedRPG;

public interface IPlayer : IEntity
{
    int GetDaysSurvived();
    Direction GetInput();

    // Get the player's current health
    int GetHealth();

    // Get the player's maximum health
    int GetMaxHealth();

    // Set the player's health
    void SetHealth(int health);

    // Get the player's hunger level
    int GetHunger();

    // Set the player's hunger level
    void SetHunger(int hunger);

    // Get the player's equipped item
    IItem GetEquippedItem();

    // Set the player's equipped item
    void SetEquippedItem(IItem item);

    // Get the player's current position in the world
    (int x, int y) GetPosition();

    // Set the player's current position in the world
    void SetPosition(int x, int y);

    // Check if the player is alive
    bool IsAlive();

    // Move the player in a given direction
    void Move(Direction direction);

    // Attack an enemy in a given direction
    void Attack(Direction direction);

    // Eat a food item to restore hunger and health
    void Eat(IItem food);
}