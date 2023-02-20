
namespace TextBasedRPG;

public interface ITile
{
    string Description { get; }
    bool IsAccessible { get; }
    char Character { get; }
}