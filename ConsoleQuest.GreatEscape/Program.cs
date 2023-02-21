using System.Text;

namespace ConsoleQuest
{
    class Program
    {
        public static int GetDifficulty()
        {
            Console.WriteLine("Please select a difficulty (1 - easy, 2 - medium, 3 - hard):");
            int difficulty;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out difficulty) && difficulty >= 1 && difficulty <= 3)
                {
                    return difficulty;
                }
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }
        }

        static async Task Main()
        {
            int difficulty = GetDifficulty();
            int renderRadius = difficulty == 1 ? 20 : difficulty == 2 ? 10 : 3;

            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            var inputHandler = new InputHandler();

            // Generate maze
            var mazeGenerator = new MazeGenerator(25, 15);
            var maze = mazeGenerator.GenerateMaze();
            var player = new Player(maze.Start.x, maze.Start.y);

            // Start timer
            var startTime = DateTime.Now;

            // Render initial state of the game
            var renderer = new MazeRenderer(maze, player);
            renderer.Render();

            // Wait for player to complete maze
            while (!maze.IsExit(player.X, player.Y))
            {
                // Get user input
                var direction = await inputHandler.GetDirectionAsync();

                // Calculate new player position
                var newPosition = direction switch
                {
                    Direction.Up => (player.X, player.Y - 1),
                    Direction.Down => (player.X, player.Y + 1),
                    Direction.Left => (player.X - 1, player.Y),
                    Direction.Right => (player.X + 1, player.Y),
                    _ => (player.X, player.Y)
                };

                // Check if new position is valid
                if (!maze.IsWall(newPosition.Item1, newPosition.Item2))
                {
                    // Update player position
                    player.X = newPosition.Item1;
                    player.Y = newPosition.Item2;

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