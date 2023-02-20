using System;

namespace ConsoleQuest
{
    public class Maze
    {
        private readonly int[,] _maze;
        private readonly int _rows;
        private readonly int _columns;

        public Maze(int rows, int columns)
        {
            _maze = new int[rows, columns];
            _rows = rows;
            _columns = columns;
        }

        public int GetCell(int row, int column)
        {
            return _maze[row, column];
        }

        public void SetCell(int row, int column, int value)
        {
            _maze[row, column] = value;
        }

        public void SetWall(int row, int column, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    if (row > 0)
                    {
                        _maze[row - 1, column] = 1;
                    }
                    break;
                case Direction.East:
                    if (column < _columns - 1)
                    {
                        _maze[row, column + 1] = 1;
                    }
                    break;
                case Direction.South:
                    if (row < _rows - 1)
                    {
                        _maze[row + 1, column] = 1;
                    }
                    break;
                case Direction.West:
                    if (column > 0)
                    {
                        _maze[row, column - 1] = 1;
                    }
                    break;
            }
        }

        public void SetPath(int row, int column)
        {
            _maze[row, column] = 0;
        }

        public int Rows => _rows;

        public int Columns => _columns;
    }


    public class MazeGenerator
    {
        private readonly int _width;
        private readonly int _height;

        public MazeGenerator(int width = 15, int height = 10)
        {
            _width = width;
            _height = height;
        }

        public Maze GenerateMaze()
        {
            var maze = new Maze(_width, _height);
            var visited = new bool[_height, _width];
            var rand = new Random();

            DFS(0, 0, maze, visited, rand);

            maze.StartRow = 0;
            maze.StartCol = 0;
            maze.EndRow = _height - 1;
            maze.EndCol = _width - 1;

            return maze;
        }

        private void DFS(int row, int col, Maze maze, bool[,] visited, Random rand)
        {
            visited[row, col] = true;
            var directions = new List<(int, int)> { (0, -1), (0, 1), (-1, 0), (1, 0) };
            directions.Shuffle(rand);

            foreach (var (deltaRow, deltaCol) in directions)
            {
                var newRow = row + deltaRow;
                var newCol = col + deltaCol;

                if (newRow < 0 || newRow >= _height || newCol < 0 || newCol >= _width || visited[newRow, newCol]) continue;

                if (newRow == row)
                {
                    if (newCol < col) maze.SetWall(row, col, Maze.Direction.West);
                    else maze.SetWall(row, col, Maze.Direction.East);
                }
                else
                {
                    if (newRow < row) maze.SetWall(row, col, Maze.Direction.North);
                    else maze.SetWall(row, col, Maze.Direction.South);
                }

                DFS(newRow, newCol, maze, visited, rand);
            }
        }
    }
}