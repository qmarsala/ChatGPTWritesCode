namespace ConsoleQuest.PathFinding;

public class World<T>
{
    private readonly T[,] _nodes;

    public World(T[,] nodes)
    {
        _nodes = nodes;
    }

    public T GetNode(int x, int y)
    {
        return _nodes[x, y];
    }

    public int Width => _nodes.GetLength(0);
    public int Height => _nodes.GetLength(1);
}
