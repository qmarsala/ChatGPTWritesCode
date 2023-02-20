using System;

namespace ConsoleQuest
{
    public class MazeGenerator
    {
        private readonly Maze maze;

        public MazeGenerator(int width, int height)
        {
            maze = new Maze(width, height);
            maze.Start = (0, 0);
            maze.End = (width - 1, height - 1);
        }

        public Maze GenerateMaze()
        {
            for (int i = 0; i < maze.Width; i++)
            {
                for (int j = 0; j < maze.Height; j++)
                {
                    maze.Grid[i, j] = false;
                }
            }

            return maze;
        }
    }
}
