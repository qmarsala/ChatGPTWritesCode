namespace ConsoleQuest
{
    public class MazeRenderer
    {
        private Maze _maze;
        private Player _player;
        private int _renderRadius;

        public MazeRenderer(Maze maze, Player player, int renderRadius)
        {
            _maze = maze;
            _player = player;
            _renderRadius = renderRadius;
        }

        public void Render()
        {
            Console.Clear();

            int playerX = _player.X;
            int playerY = _player.Y;

            int startX = Math.Max(0, playerX - _renderRadius);
            int endX = Math.Min(_maze.Width, playerX + _renderRadius + 1);

            int startY = Math.Max(0, playerY - _renderRadius);
            int endY = Math.Min(_maze.Height, playerY + _renderRadius + 1);

            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    if (_maze.Grid[x, y])
                    {
                        Console.Write("█");
                    }
                    else if (playerX == x && playerY == y)
                    {
                        Console.Write("@");
                    }
                    else if (_maze.IsExit(x, y))
                    {
                        Console.Write("[]");
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