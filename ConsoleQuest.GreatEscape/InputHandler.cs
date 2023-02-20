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
            return GetDirectionFromKey(keyInfo.Key);
        }

        public async Task<Direction> GetDirectionAsync()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    return GetDirectionFromKey(keyInfo.Key);
                }
                await Task.Delay(50); // Wait for 50 milliseconds before checking again
            }
        }

        private Direction GetDirectionFromKey(ConsoleKey key) =>
            key switch
            {
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                _ => Direction.Up // Default to up direction
            };
    }
}
