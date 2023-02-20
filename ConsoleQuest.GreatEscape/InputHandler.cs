using System;

namespace ConsoleQuest
{
    public class InputHandler
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public Direction GetDirection()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    return Direction.Up;
                case ConsoleKey.DownArrow:
                    return Direction.Down;
                case ConsoleKey.LeftArrow:
                    return Direction.Left;
                case ConsoleKey.RightArrow:
                    return Direction.Right;
                default:
                    return Direction.Up; // Default to up direction
            }
        }

        public async Task<Direction> GetDirectionAsync()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            return Direction.Up;
                        case ConsoleKey.DownArrow:
                            return Direction.Down;
                        case ConsoleKey.LeftArrow:
                            return Direction.Left;
                        case ConsoleKey.RightArrow:
                            return Direction.Right;
                    }
                }
                await Task.Delay(50); // Wait for 50 milliseconds before checking again
            }
        }

    }
}
