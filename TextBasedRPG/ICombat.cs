
namespace TextBasedRPG;

public interface ICombat
{
    int CalculateDamage(IEntity attacker, IEntity defender);
    void ResolveCombat(IEntity attacker, IEntity defender);
}
