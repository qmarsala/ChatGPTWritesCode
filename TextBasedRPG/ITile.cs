
namespace TextBasedRPG;

public interface ITile
{
    string Name { get; set; }
    string Description { get; set; }
    bool IsAccessible { get; set; }
}
