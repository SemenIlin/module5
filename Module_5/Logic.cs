using System;
using System.Collections.Generic;

namespace Module_5
{
    class Logic
    {        
        enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        Direction direction;

        readonly Player player;
        readonly List<ITrap> trap;

        public Logic(Player player, List<ITrap> trap)
        {
            this.player = player;
            this.trap = trap;
        }

        public bool Status { get; set; } = true;
        public string Message { get; set; }

        public void LogicGame()
        {
            Move();
            OutOfBounds();
            ContactWithTrap();
            StatusGame();
            TextMessage();
        }

        private void Move()
        {
            InputData();

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
        }

        private void InputData()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    direction = Direction.Up;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    direction = Direction.Down;
                    break;
            }
        }

        private void OutOfBounds() 
        {
            if (player.GetPositionX() >= Map.GetWidth())
            {
                player.SetPositionX(Map.GetWidth() - 1);
            }
            else if (player.GetPositionX() <= 0)
            {
                player.SetPositionX(1);
            }
            else if (player.GetPositionY() >= Map.GetHeight())
            {
                player.SetPositionY(player.GetPositionY() - 1);
            }
            else if (player.GetPositionY() <= 0)
            {
                player.SetPositionY(1);
            }
        }

        private void ContactWithTrap()
        {
            foreach (var item in trap)
            {
                if ((player.GetPositionX() == item.GetPositionX()) && (player.GetPositionY() == item.GetPositionY()) && (item.GetIsActiveTrap()))
                {
                    player.SetHitPoint(player.GetHitPoint() - item.GetDamage());
                    item.SetIsActiveTrap(false);
                    break;
                }
            }
        }    
        
        private void StatusGame()
        {
            if (player.GetHitPoint() <= 0)
            {
                Status = false;
            }
            if (player.GetPositionX() == 10 && player.GetPositionY() == 10)
            {
                Status = false;
            }
        }

        private void TextMessage() 
        {
            if (player.GetHitPoint() <= 0)
            {
                Message = "Game over. You lose.";
            }
            if (player.GetPositionX() == 10 && player.GetPositionY() == 10)
            {
                Message = "Game over. You win.";
            }
        }
    }
}
