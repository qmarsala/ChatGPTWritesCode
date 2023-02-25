// Create nodes for the graph
using ConsoleQuest.PathFinding;

int width = 10;
int height = 10;
Node[,] graph = new Node[10, 10];

for (int x = 0; x < 10; x++)
{
    for (int y = 0; y < 10; y++)
    {
        graph[x, y] = new Node(x, y, 1);
        // Add some random noise to the world
        Random rand = new Random();
        int cost = rand.Next(100) < 30 ? 1 : 0;
        graph[x, y] = new Node(x, y, cost);
    }
}

// Add some walls around the edge of the world
for (int x = 0; x < width; x++)
{
    graph[x, 0].cost = 1;
    graph[x, height - 1].cost = 1;
}
for (int y = 0; y < height; y++)
{
    graph[0, y].cost = 1;
    graph[width - 1, y].cost = 1;
}

// Connect nodes in the graph
for (int x = 0; x < 10; x++)
{
    for (int y = 0; y < 10; y++)
    {
        Node node = graph[x, y];

        if (x > 0) // Connect to the left node
        {
            node.AddNeighbor(graph[x - 1, y]);
        }
        if (x < 9) // Connect to the right node
        {
            node.AddNeighbor(graph[x + 1, y]);
        }
        if (y > 0) // Connect to the top node
        {
            node.AddNeighbor(graph[x, y - 1]);
        }
        if (y < 9) // Connect to the bottom node
        {
            node.AddNeighbor(graph[x, y + 1]);
        }
    }
}

// Find a path using A*
AStarPathfinder pathfinder = new AStarPathfinder(graph.Cast<Node>().ToList());
Node start = graph[0, 0];
Node end = graph[9, 9];
List<Node> path = pathfinder.FindPath(start, end);

var renderer = new Render(10, 10);
renderer.DrawWorld(path, start, end);

Console.ReadLine();
