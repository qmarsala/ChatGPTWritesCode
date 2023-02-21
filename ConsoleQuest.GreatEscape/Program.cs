using System.Text;

namespace ConsoleQuest
{
    class Program
    {
        static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            var inputHandler = new InputHandler();

            // Generate maze
            var mazeGenerator = new MazeGenerator(25, 15);
            var maze = mazeGenerator.GenerateMaze();
            var player = new Player(maze.Start.x, maze.Start.y);

            // Initialize player position
            var playerPosition = maze.Start;

            // Start timer
            var startTime = DateTime.Now;

            // Render initial state of the game
            var renderer = new MazeRenderer(maze, player);
            renderer.Render();

            // Wait for player to complete maze
            while (!maze.IsExit(playerPosition.x, playerPosition.y))
            {
                // Get user input
                var direction = await inputHandler.GetDirectionAsync();

                // Calculate new player position
                var newPosition = playerPosition switch
                {
                    (int x, int y) pos when direction == Direction.Up => (x, y - 1),
                    (int x, int y) pos when direction == Direction.Down => (x, y + 1),
                    (int x, int y) pos when direction == Direction.Left => (x - 1, y),
                    (int x, int y) pos when direction == Direction.Right => (x + 1, y),
                    _ => playerPosition
                };

                // Check if new position is valid
                if (!maze.IsWall(newPosition.Item1, newPosition.Item2))
                {
                    // Update player position
                    playerPosition = newPosition;

                    // Render updated state of the game
                    renderer.Render();
                }
            }

            // End timer and calculate elapsed time
            var endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;

            // Display time elapsed to player
            Console.SetCursorPosition(0, maze.Height + 2);
            Console.WriteLine($"Congratulations! You completed the maze in {elapsedTime.TotalSeconds} seconds!");
            Console.ReadKey();
        }
    }
}