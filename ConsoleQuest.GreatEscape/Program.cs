namespace ConsoleQuest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Console Quest: The Great Escape!");
            Console.WriteLine("Use the arrow keys to navigate the maze and find the exit.");

            MazeGenerator mazeGenerator = new MazeGenerator();
            Maze maze = mazeGenerator.GenerateMaze();

            MazeRenderer mazeRenderer = new MazeRenderer(maze);
            mazeRenderer.Render();

            int currentRow = maze.StartRow;
            int currentCol = maze.StartCol;

            while (true)
            {
                InputHandler inputHandler = new InputHandler();
                var direction = await inputHandler.GetDirectionAsync();
                int newRow = currentRow;
                int newCol = currentCol;

                switch (direction)
                {
                    case InputHandler.Direction.Up:
                        newRow--;
                        break;
                    case InputHandler.Direction.Down:
                        newRow++;
                        break;
                    case InputHandler.Direction.Left:
                        newCol--;
                        break;
                    case InputHandler.Direction.Right:
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
                    currentRow = newRow;
                    currentCol = newCol;
                }

                mazeRenderer.Render(currentRow, currentCol);
            }

            Console.ReadLine();
        }

    }
}