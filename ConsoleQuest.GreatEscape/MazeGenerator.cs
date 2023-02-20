using System;

namespace ConsoleQuest
{
    public class MazeGenerator
    {
        private readonly int rows;
        private readonly int cols;
        private readonly Maze maze;

        public MazeGenerator(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.maze = new Maze(rows, cols);
        }

        public Maze GenerateMaze()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    maze.SetWall(row, col);
                }
            }

            int startRow = 0;
            int startCol = 0;
            int endRow = rows - 1;
            int endCol = cols - 1;

            maze.RemoveWall(startRow, startCol);
            maze.Start = (startRow, startCol);
            maze.End = (endRow, endCol);

            while (!PathExists(maze, startRow, startCol, endRow, endCol))
            {
                int row = new Random().Next(0, rows);
                int col = new Random().Next(0, cols);

                if ((row == startRow && col == startCol) || (row == endRow && col == endCol))
                {
                    continue;
                }

                maze.RemoveWall(row, col);
            }

            return maze;
        }

        private bool PathExists(Maze maze, int startRow, int startCol, int endRow, int endCol)
        {
            bool[,] visited = new bool[rows, cols];
            return PathExistsHelper(maze, startRow, startCol, endRow, endCol, visited);
        }

        private bool PathExistsHelper(Maze maze, int row, int col, int endRow, int endCol, bool[,] visited)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || maze.IsWall(row, col) || visited[row, col])
            {
                return false;
            }

            if (row == endRow && col == endCol)
            {
                return true;
            }

            visited[row, col] = true;

            bool found = PathExistsHelper(maze, row - 1, col, endRow, endCol, visited)
                || PathExistsHelper(maze, row, col + 1, endRow, endCol, visited)
                || PathExistsHelper(maze, row + 1, col, endRow, endCol, visited)
                || PathExistsHelper(maze, row, col - 1, endRow, endCol, visited);

            visited[row, col] = false;

            return found;
        }
    }
}