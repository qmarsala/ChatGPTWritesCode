namespace ConsoleQuest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Console Quest: The Great Escape!");
            Console.WriteLine("Use the arrow keys to navigate the maze and find the exit.");

            MazeGenerator mazeGenerator = new MazeGenerator(10, 10);
            Maze maze = mazeGenerator.GenerateMaze();
            Player player = new Player(maze.Start.x, maze.Start.y);

            MazeRenderer mazeRenderer = new MazeRenderer(maze, player);
            mazeRenderer.Render();

            while (true)
            {
                InputHandler inputHandler = new InputHandler();
                var direction = await inputHandler.GetDirectionAsync();
                int newRow = player.X;
                int newCol = player.Y;

                switch (direction)
                {
                    case Direction.Up:
                        newRow--;
                        break;
                    case Direction.Down:
                        newRow++;
                        break;
                    case Direction.Left:
                        newCol--;
                        break;
                    case Direction.Right:
                        newCol++;
                        break;
                    default:
                        break;
                }

                if (maze.IsExit(newRow, newCol))
                {
                    Console.WriteLine("Congratulations, you escaped the maze!");
                    break;
                }

                if (!maze.IsWall(newRow, newCol))
                {
                    player.X = newRow;
                    player.Y = newCol;
                }

                mazeRenderer.Render();
            }

            Console.ReadLine();
        }

    }
}