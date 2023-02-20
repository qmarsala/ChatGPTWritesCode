namespace ConsoleQuest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Console Quest: The Great Escape!");
            Console.WriteLine("Use the arrow keys to navigate the maze and find the exit.");

            //MazeGenerator mazeGenerator = new MazeGenerator(10, 10);
            Maze maze = MazeGenerator.GenerateMaze(10, 10);
            Player player = new Player(maze.Start.x, maze.Start.y);

            MazeRenderer mazeRenderer = new MazeRenderer(maze, player);
            mazeRenderer.Render();

            while (true)
            {
                InputHandler inputHandler = new InputHandler();
                var direction = await inputHandler.GetDirectionAsync();
                int newX = player.X;
                int newY = player.Y;

                switch (direction)
                {
                    case Direction.Left:
                        newX--;  // decrement newX by 1
                        break;
                    case Direction.Right:
                        newX++;  // increment newX by 1
                        break;
                    case Direction.Up:
                        newY++;
                        break;
                    case Direction.Down:
                        newY--;
                        break;
                }

                if (maze.IsExit(newX, newY))
                {
                    Console.WriteLine("Congratulations, you escaped the maze!");
                    break;
                }

                if (!maze.IsWall(newX, newY))
                {
                    player.X = newX;
                    player.Y = newY;
                }

                mazeRenderer.Render();
            }

            Console.ReadLine();
        }

    }
}