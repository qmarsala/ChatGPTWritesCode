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
    }
}
