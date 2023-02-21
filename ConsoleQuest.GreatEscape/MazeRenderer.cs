namespace ConsoleQuest
{
    public class MazeRenderer
    {
        private Maze _maze;
        private Player _player;

        public MazeRenderer(Maze maze, Player player)
        {
            _maze = maze;
            _player = player;
        }

        public void Render()
        {
            Console.Clear();
            for (int y = 0; y < _maze.Height; y++)
            {
                for (int x = 0; x < _maze.Width; x++)
                {
                    if (_maze.Grid[x, y])
                    {
                        Console.Write("█");
                    }
                    else if (_player.X == x && _player.Y == y)
                    {
                        Console.Write("P");
                    }
                    else if (_maze.IsExit(x, y))
                    {
                        Console.Write("E");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}