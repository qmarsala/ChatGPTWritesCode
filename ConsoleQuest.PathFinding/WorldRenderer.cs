// Create nodes for the graph

namespace ConsoleQuest.PathFinding;

public class WorldRenderer<T>
{
    private readonly Func<T, char> _nodeToCharFunc;

    public WorldRenderer(Func<T, char> nodeToCharFunc)
    {
        _nodeToCharFunc = nodeToCharFunc;
    }

    public void Render(T[,] world, T start, T goal, IEnumerable<T> path)
    {
        int width = world.GetLength(0);
        int height = world.GetLength(1);

        Console.WriteLine("World:");

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                T node = world[x, y];

                if (node.Equals(start))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (node.Equals(goal))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (path != null && path.Contains(node))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.Write(_nodeToCharFunc(node));

                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}