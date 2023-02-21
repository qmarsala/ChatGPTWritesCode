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

            int playerX = _player.X;
            int playerY = _player.Y;
            int renderRadius = 2; // Change this to control how many spaces are visible around the player

            int startX = Math.Max(0, playerX - renderRadius);
            int endX = Math.Min(_maze.Width, playerX + renderRadius + 1);

            int startY = Math.Max(0, playerY - renderRadius);
            int endY = Math.Min(_maze.Height, playerY + renderRadius + 1);

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