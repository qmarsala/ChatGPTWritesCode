namespace ConsoleQuest.PathFinding;

public class AStarPathfinder
{
    private int width;
    private int height;
    private Node[,] world;

    public AStarPathfinder(Node[,] world)
    {
        this.world = world;
        this.width = world.GetLength(0);
        this.height = world.GetLength(1);
    }

    private int Heuristic(Node a, Node b)
    {
        return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
    }

    public List<Node> FindPath(Node start, Node goal)
    {
        HashSet<Node> closedSet = new HashSet<Node>();
        HashSet<Node> openSet = new HashSet<Node>();
        openSet.Add(start);

        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();

        Dictionary<Node, int> gScore = new Dictionary<Node, int>();
        gScore[start] = 0;

        Dictionary<Node, int> fScore = new Dictionary<Node, int>();
        fScore[start] = Heuristic(start, goal);

        while (openSet.Count > 0)
        {
            Node current = GetNodeWithLowestFScore(openSet, fScore);

            if (current == goal)
            {
                return ReconstructPath(cameFrom, current);
            }

            openSet.Remove(current);
            closedSet.Add(current);

            foreach (Node neighbor in GetNeighbors(current))
            {
                if (closedSet.Contains(neighbor))
                {
                    continue;
                }

                int tentativeGScore = gScore[current] + 1;

                if (!openSet.Contains(neighbor) || tentativeGScore < gScore[neighbor])
                {
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + Heuristic(neighbor, goal);

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }

        return null;
    }

    private T GetNodeWithLowestFScore<T>(HashSet<T> openSet, Dictionary<T, int> fScore)
    {
        float lowestScore = float.MaxValue;
        T lowestNode = default;

        foreach (var node in openSet)
        {
            if (fScore.TryGetValue(node, out int score) && score < lowestScore)
            {
                lowestScore = score;
                lowestNode = node;
            }
        }

        return lowestNode;
    }


    public List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();

        // Check all 8 directions around the node
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                // Skip the node itself
                if (dx == 0 && dy == 0)
                {
                    continue;
                }

                int x = node.x + dx;
                int y = node.y + dy;

                // Make sure the neighboring node is within bounds
                if (x >= 0 && x < width && y >= 0 && y < height)
                {
                    Node neighbor = world[x, y];

                    // Check if the neighbor is a valid node (i.e. not an obstacle and not null)
                    if (neighbor != null && neighbor.cost < 1)
                    {
                        neighbors.Add(neighbor);
                    }
                }
            }
        }

        return neighbors;
    }


    private List<Node> ReconstructPath(Dictionary<Node, Node> cameFrom, Node currentNode)
    {
        List<Node> path = new List<Node>();
        path.Add(currentNode);

        while (cameFrom.ContainsKey(currentNode))
        {
            currentNode = cameFrom[currentNode];
            path.Insert(0, currentNode);
        }

        return path;
    }
}
