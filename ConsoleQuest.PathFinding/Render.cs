// Create nodes for the graph
using ConsoleQuest.PathFinding;

public class Render
{
    private readonly int _width;
    private readonly int _height;

    public Render(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public void DrawWorld(List<Node> path, Node startNode, Node endNode)
    {
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                Node node = new Node(x, y, 0);
                if (startNode.Equals(node))
                {
                    Console.Write("S ");
                    continue;
                }
                else if (endNode.Equals(node))
                {
                    Console.Write("E ");
                    continue;
                }
                else if (path.Contains(node))
                {
                    Console.Write("* ");
                    continue;
                }
                else
                {
                    Console.Write(". ");
                    continue;
                }
            }
            Console.WriteLine();
        }
    }
}
