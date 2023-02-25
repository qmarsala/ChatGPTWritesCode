// Create nodes for the graph
using ConsoleQuest.PathFinding;

Node[,] graph = new Node[10, 10];
for (int x = 0; x < 10; x++)
{
    for (int y = 0; y < 10; y++)
    {
        graph[x, y] = new Node(x, y, 1);
    }
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

//
graph[2, 2].cost = float.PositiveInfinity;
graph[2, 3].cost = float.PositiveInfinity;
graph[2, 4].cost = float.PositiveInfinity;
graph[3, 4].cost = float.PositiveInfinity;
graph[4, 4].cost = float.PositiveInfinity;
graph[5, 4].cost = float.PositiveInfinity;
graph[6, 4].cost = float.PositiveInfinity;
graph[6, 3].cost = float.PositiveInfinity;

// Find a path using A*
AStarPathfinder pathfinder = new AStarPathfinder(graph.Cast<Node>().ToList());
Node start = graph[0, 0];
Node end = graph[9, 9];
List<Node> path = pathfinder.FindPath(start, end);

var renderer = new Render(10, 10);
renderer.DrawWorld(path, start, end);

Console.ReadLine();
