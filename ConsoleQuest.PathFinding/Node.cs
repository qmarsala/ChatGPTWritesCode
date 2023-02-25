namespace ConsoleQuest.PathFinding;

public class Node
{
    public int x;
    public int y;
    public float cost;
    public List<Node> neighbors;
    public float gScore;
    public float fScore;
    public Node cameFrom;

    public Node(int x, int y, float cost)
    {
        this.x = x;
        this.y = y;
        this.cost = cost;
        neighbors = new List<Node>(); // Initialize the neighbors list
    }

    public void AddNeighbor(Node neighbor)
    {
        neighbors.Add(neighbor);
    }

    public override bool Equals(object? obj) 
        => obj is Node n && n.x == x && n.y == y;
}
