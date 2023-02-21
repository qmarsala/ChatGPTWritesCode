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
            Console.WriteLine("Welcome to Console Quest!");

            Console.WriteLine("The objective of this game is to navigate through a maze to reach the end point.");
            Console.WriteLine("To move through the maze, use the arrow keys on your keyboard.");
            Console.WriteLine("You can only see a limited number of spaces around you, so make sure to plan your moves carefully.");
            Console.WriteLine("Be careful not to hit any walls or you will have to start over!");
            Console.WriteLine("Good luck!");

            Console.WriteLine("Before we begin, please select a difficulty level:");
            Console.WriteLine("- (1) Easy: Larger view radius around the player");
            Console.WriteLine("- (2) Medium: Medium view radius around the player");
            Console.WriteLine("- (3) Hard: Smaller view radius around the player");

            int difficulty = GetDifficulty();
            int renderRadius = difficulty == 1 ? 15 : difficulty == 2 ? 7 : 3;

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
            var renderer = new MazeRenderer(maze, player, renderRadius);
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
                else
                {
                    Console.WriteLine("You hit a wall! Game Over.");
                    return;
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