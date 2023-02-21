using System;

namespace ConsoleQuest
{
    public class MazeGenerator
    {
        private readonly int _width;
        private readonly int _height;
        private readonly bool[,] _visited;
        private readonly Random _random;

        public MazeGenerator(int width, int height)
        {
            _width = width;
            _height = height;
            _visited = new bool[width, height];
            _random = new Random();
        }

        public Maze GenerateMaze()
        {
            var maze = new Maze(_width, _height);
            var stack = new Stack<(int x, int y)>();

            // Start at a random cell and mark it as visited
            var startX = _random.Next(_width);
            var startY = _random.Next(_height);
            _visited[startX, startY] = true;

            // Push the starting cell onto the stack
            stack.Push((startX, startY));

            // Loop until the stack is empty
            while (stack.Count > 0)
            {
                // Pop a cell from the stack
                var current = stack.Pop();

                // Get the neighboring cells that haven't been visited
                var neighbors = GetUnvisitedNeighbors(current);

                // If there are unvisited neighbors
                if (neighbors.Count > 0)
                {
                    // Push the current cell back onto the stack
                    stack.Push(current);

                    // Choose a random unvisited neighbor
                    var next = neighbors[_random.Next(neighbors.Count)];

                    // Remove the wall between the current cell and the next cell
                    if (next.x < current.x)
                    {
                        maze.RemoveWall(current.x - 1, current.y);
                        maze.RemoveWall(next.x + 1, next.y);
                    }
                    else if (next.x > current.x)
                    {
                        maze.RemoveWall(current.x + 1, current.y);
                        maze.RemoveWall(next.x - 1, next.y);
                    }
                    else if (next.y < current.y)
                    {
                        maze.RemoveWall(current.x, current.y + 1);
                        maze.RemoveWall(next.x, next.y - 1);
                    }
                    else if (next.y > current.y)
                    {
                        maze.RemoveWall(current.x, current.y - 1);
                        maze.RemoveWall(next.x, next.y + 1);
                    }

                    // Mark the next cell as visited and push it onto the stack
                    _visited[next.x, next.y] = true;
                    stack.Push(next);
                }
            }

            // Set the start and end points
            maze.Start = (startX, startY);
            var endX = _random.Next(_width);
            var endY = _random.Next(_height);
            while (endX == startX && endY == startY)
            {
                endX = _random.Next(_width);
                endY = _random.Next(_height);
            }
            maze.End = (endX, endY);

            return maze;
        }

        private List<(int x, int y)> GetUnvisitedNeighbors((int, int) cell)
        {
            var neighbors = new List<(int, int)>();
            var (x, y) = cell;

            if (x > 0 && !_visited[x - 1, y])
            {
                neighbors.Add((x - 1, y));
            }
            if (y > 0 && !_visited[x, y - 1])
            {
                neighbors.Add((x, y - 1));
            }
            if (x < _visited.GetLength(0) - 1 && !_visited[x + 1, y])
            {
                neighbors.Add((x + 1, y));
            }
            if (y < _visited.GetLength(1) - 1 && !_visited[x, y + 1])
            {
                neighbors.Add((x, y + 1));
            }

            return neighbors;
        }
    }
}
