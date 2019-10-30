using System;
using System.Collections.Generic;

namespace Module_5
{
    public class LogicFirstLevel : ILogicGame
    {    
        private readonly IPlayer player;
        private readonly IPlayer quin;
        private readonly IMap map;
        private readonly List<ITrap> trap;

        public LogicFirstLevel(IPlayer player, IPlayer quin, IMap map)
        {
            this.player = player;
            this.quin = quin;
            this.map = map;
            trap = map.Traps;
        }

        public bool Status { get; set; } = true;
        public string Message { get; set; }

        public void LogicGameInteractionWithOjects(Direction direction)
        {
            Move(direction);
            VerifyOutOfBounds();
            ContactWithTrap();
            StatusGame();
            ShowMessageAfterGameOver();
        }

        private void Move(Direction direction)
        {  
            switch (direction)
            {
                case Direction.Left:
                    player.PlayerPositionX -= 1;
                    break;
                case Direction.Right:
                    player.PlayerPositionX += 1;
                    break;
                case Direction.Up:
                    player.PlayerPositionY -= 1;
                    break;
                case Direction.Down:
                    player.PlayerPositionY += 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }       

        private void VerifyOutOfBounds() 
        {
            if (player.PlayerPositionX >= map.Width)
            {
                player.PlayerPositionX = map.Width - 1;
            }
            else if (player.PlayerPositionX <= 0)
            {
                player.PlayerPositionX = 1;
            }
            else if (player.PlayerPositionY >= map.Height)
            {
                player.PlayerPositionY -=1;
            }
            else if (player.PlayerPositionY <= 0)
            {
                player.PlayerPositionY = 1;
            }
        }

        private void ContactWithTrap()
        {
            foreach (var item in trap)
            {
                if ((player.PlayerPositionX == item.TrapPositionX) && 
                    (player.PlayerPositionY == item.TrapPositionY) &&
                    (item.TrapIsActive))
                {
                    player.PlayerHitPoints -=  item.TrapDamage;
                    item.TrapIsActive = false;
                    item.TrapIsVisible = true;
                    break;
                }
            }
        }    
        
        private void StatusGame()
        {
            if (player.PlayerHitPoints <= 0)
            {
                Status = false;
            }
            if ((player.PlayerPositionX == quin.PlayerPositionX) && 
                (player.PlayerPositionY == quin.PlayerPositionY))
            {
                Status = false;
            }
        }

        private void ShowMessageAfterGameOver() 
        {
            if (player.PlayerHitPoints <= 0)
            {
                Message = "Game over. You lose.";
            }
            if ((player.PlayerPositionX == quin.PlayerPositionX) &&
                (player.PlayerPositionY == quin.PlayerPositionY))
            {
                Message = "Game over. You win.";
            }
        }

        public void LogicQuitOrUpdateLevelGame()
        {
            if (!Status)
            {
                Console.WriteLine($"{Message}\n" +
                                   "Do you want play again?\n" +
                                   "If yes, press any key. " +
                                   "Else press Esc.");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    UpdateLevel();
                }
            }
        }

        public void UpdateLevel()
        {
            player.PlayerPositionX = 1;
            player.PlayerPositionY = 1;
            player.PlayerHitPoints = 10;
            map.CreateMap();
            map.UpadateTrapOnMap();
            Status = true;
        }
    }
}
