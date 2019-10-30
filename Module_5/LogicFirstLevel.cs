using System.Collections.Generic;

namespace Module_5
{
    class LogicFirstLevel : ILogicGame
    {    
        private readonly IPlayer player;
        private readonly IPlayer quin;
        private readonly IMap map;
        private readonly List<ITrap> trap;
        private readonly CommandByUser commandByUser;

        public LogicFirstLevel(IPlayer player, IPlayer quin, IMap map, CommandByUser commandByUser)
        {
            this.player = player;
            this.quin = quin;
            this.map = map;
            this.commandByUser = commandByUser;
            trap = map.Traps;
        }

        public bool Status { get; set; } = true;
        public string Message { get; set; }

        public void LogicGame()
        {
            Move(commandByUser.DirectionPlayer);
            OutOfBounds();
            ContactWithTrap();
            StatusGame();
            ShowMessageAfterGameOver();
        }

        private void Move(CommandByUser.Direction direction)
        {  
            switch (direction)
            {
                case CommandByUser.Direction.Left:
                    player.PlayerPositionX -= 1;
                    break;
                case CommandByUser.Direction.Right:
                    player.PlayerPositionX += 1;
                    break;
                case CommandByUser.Direction.Up:
                    player.PlayerPositionY -= 1;
                    break;
                case CommandByUser.Direction.Down:
                    player.PlayerPositionY += 1;
                    break;
            }
        }       

        private void OutOfBounds() 
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
                if ((player.PlayerPositionX == item.TrapPositionX) && (player.PlayerPositionY == item.TrapPositionY) && (item.TrapIsActive))
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
            if ((player.PlayerPositionX == quin.PlayerPositionX) && (player.PlayerPositionY == quin.PlayerPositionY))
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
            if ((player.PlayerPositionX == quin.PlayerPositionX) && (player.PlayerPositionY == quin.PlayerPositionY))
            {
                Message = "Game over. You win.";
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
