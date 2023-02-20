namespace ConsoleQuest
{
    public class MazeRenderer
    {
        private readonly Maze _maze;

        public MazeRenderer(Maze maze)
        {
            _maze = maze;
        }

        public void RenderMaze()
        {
            Console.Clear();

            for (int i = 0; i < _maze.Rows; i++)
            {
                for (int j = 0; j < _maze.Columns; j++)
                {
                    if (_maze.GetCell(i, j) == 1)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}