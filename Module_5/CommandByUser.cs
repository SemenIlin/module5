using System;

namespace Module_5
{
    class CommandByUser
    {
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        public Direction DirectionPlayer { get; set; }

        public void InputData()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    DirectionPlayer = Direction.Left;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    DirectionPlayer = Direction.Right;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    DirectionPlayer = Direction.Up;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    DirectionPlayer = Direction.Down;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
