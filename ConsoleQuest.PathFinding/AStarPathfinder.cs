namespace ConsoleQuest.PathFinding;

public class AStarPathfinder
{
    private List<Node> nodes;

    public AStarPathfinder(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    private float Heuristic(Node a, Node b)
    {
        return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
    }

    public List<Node> FindPath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();

        Dictionary<Node, float> gScore = new Dictionary<Node, float>();
        gScore[startNode] = 0f;

        Dictionary<Node, float> fScore = new Dictionary<Node, float>();
        fScore[startNode] = Heuristic(startNode, endNode);

        HashSet<Node> closedSet = new HashSet<Node>();
        HashSet<Node> openSet = new HashSet<Node> { startNode };

        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();

        while (openSet.Count > 0)
        {
            Node current = null;
            foreach (Node node in openSet)
            {
                if (current == null || fScore[node] < fScore[current] && node.IsTraversable())
                {
                    current = node;
                }
            }

            if (current == endNode)
            {
                path = ReconstructPath(cameFrom, current);
                break;
            }

            openSet.Remove(current);
            closedSet.Add(current);

            foreach (Node neighbor in current.neighbors)
            {
                if (closedSet.Contains(neighbor))
                {
                    continue;
                }

                float tentativeGScore = gScore[current] + neighbor.cost;

                if (!openSet.Contains(neighbor) || tentativeGScore < gScore[neighbor])
                {
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = tentativeGScore + Heuristic(neighbor, endNode);
                    openSet.Add(neighbor);
                }
            }
        }

        return path;
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
