using System;

namespace ConsoleQuest
{
    public class MazeGenerator
    {
        public static Maze GenerateMaze(int width, int height)
        {
            Maze maze = new Maze(width, height);

            // Starting position
            maze.Start = (0, height / 2);
            maze.RemoveWall(maze.Start.x, maze.Start.y);

            // Ending position
            maze.End = (width - 1, height / 2);
            maze.RemoveWall(maze.End.x, maze.End.y);

            // Add walls to block off other areas
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if ((x != 0 || y != height / 2) && (x != width - 1 || y != height / 2))
                    {
                        maze.SetWall(x, y);
                    }
                }
            }

            return maze;
        }
    }
}
