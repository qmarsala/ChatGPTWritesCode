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
            for (int j = _maze.Height - 1; j > 0; j--)
            {
                for (int i = 0; i < _maze.Width; i++)
                {
                    if (_maze.Grid[i, j])
                    {
                        Console.Write("█");
                    }
                    else if (_player.X == i && _player.Y == j)
                    {
                        Console.Write("P");
                    }
                    else if (_maze.IsExit(i, j))
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