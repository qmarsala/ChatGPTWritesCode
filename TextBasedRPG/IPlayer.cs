
namespace TextBasedRPG;

public interface IPlayer : IEntity
{
    int DaysSurvived { get; set; }
    int MaxHealth { get; set; }
    int Hunger { get; set; }
    IItem EquippedItem { get; set; }
    bool IsAlive { get; }
    
    Direction GetInput();
    void Move(Direction direction);
}