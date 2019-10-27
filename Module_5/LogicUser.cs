using System;
using System.Collections.Generic;

namespace Module_5
{
    class LogicUser
    {
        enum Direction
        {
            Stop,
            Left,
            Right,
            Up,
            Down
        }

        public static bool Status { get; set; } = true;
        public static string Message { get; set; }

        Direction direction;

        public void Move(Player player, List<ITrap> trap)
        {
            Input();

            switch (direction)
            {
                case Direction.Left:
                    player.SetPositionX(player.GetPositionX() - 1);
                    break;
                case Direction.Right:
                    player.SetPositionX(player.GetPositionX() + 1);
                    break;
                case Direction.Up:
                    player.SetPositionY(player.GetPositionY() - 1);
                    break;
                case Direction.Down:
                    player.SetPositionY(player.GetPositionY() + 1);
                    break;
            }

            if (player.GetPositionX() >= Map.GetWidth())
            {
                player.SetPositionX(Map.GetWidth() - 1);
            }
            if (player.GetPositionX() <= 0)
            {
                player.SetPositionX(1);
            }
            if (player.GetPositionY() >= Map.GetHeight())
            {
                player.SetPositionY(player.GetPositionY() - 1);
            }
            if (player.GetPositionY() <= 0)
            {
                player.SetPositionY(1);
            }
            foreach (var item in trap)
            {
                if ((player.GetPositionX() == item.GetPositionX()) && (player.GetPositionY() == item.GetPositionY()) && (item.GetIsActiveTrap()))
                {
                    player.SetHitPoint(player.GetHitPoint() - item.GetDamage());
                    item.SetIsActiveTrap(false);
                }
            }
            if (player.GetHitPoint() <= 0)
            {
                Status = false;
                Message = "Game over. You lose.";
            }
            if (player.GetPositionX() == 10 && player.GetPositionY() == 10)
            {
                Status = false;
                 Message = "Game over. You win.";
            }
        }

        private void Input()
        {
            direction = Console.ReadKey().Key switch
            {
                ConsoleKey.A => Direction.Left,
                ConsoleKey.D => Direction.Right,
                ConsoleKey.W => Direction.Up,
                ConsoleKey.S => Direction.Down,
                _ => Direction.Stop,
            };
        }
    }
}
