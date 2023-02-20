
namespace TextBasedRPG;

public class TileGenerator
{
    private const int NumItems = 2;
    private const int NumEnemies = 2;

    private static readonly string[] GroundTileDescriptions = {
        "You see a patch of grass.",
        "You see a dirt path.",
        "You see a rocky outcropping.",
        "You see a dry riverbed.",
        "You see a sandy dune.",
        "You see a clump of bushes."
    };

    private static readonly string[] ItemTileDescriptions = {
        "You see a shiny object on the ground.",
        "You see a glint of light coming from a nearby bush.",
        "You see a small pouch lying on the ground.",
        "You see a wooden crate with the lid slightly ajar.",
        "You see a pile of coins on the ground.",
        "You see a glowing object in the distance."
    };

    private static readonly string[] EnemyTileDescriptions = {
        "You see a ferocious monster!",
        "You hear a growling noise nearby.",
        "You see a group of bandits in the distance.",
        "You see a mysterious figure lurking in the shadows."
    };

    private static readonly string ExitTileDescription = "You see the exit to the next level!";

    private readonly Random _random;

    public TileGenerator(int seed)
    {
        _random = new Random(seed);
    }

    public ITile GenerateTile()
    {
        var rand = _random.Next(100);

        if (rand < 60)
        {
            return new GroundTile(GetRandomDescription(GroundTileDescriptions));
        }
        else if (rand < 80)
        {
            return new ItemTile(GetRandomDescription(ItemTileDescriptions));
        }
        else if (rand < 95)
        {
            return new EnemyTile(GetRandomDescription(EnemyTileDescriptions));
        }
        else
        {
            return new ExitTile(ExitTileDescription);
        }
    }
    
    private string GetRandomDescription(string[] descriptions)
    {
        return descriptions[_random.Next(descriptions.Length)];
    }
}
