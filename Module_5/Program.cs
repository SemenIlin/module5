using System;

namespace Module_5
{
    class Program
    {
        static void Main()
        {
            Player player = new Player(10, 1, 1);
            Player quin = new Player(10, 10, 10);
            MapFirstLevel mapFirstLevel = new MapFirstLevel(player,quin);

            Map map = new Map();
            CommandByUser commandByUser = new CommandByUser();
            Logic logic = new Logic(player, quin, mapFirstLevel, commandByUser, mapFirstLevel.Traps);

            map.CreateMap(mapFirstLevel);
            map.AddTrapOnMap(mapFirstLevel);

            while (true)
            {
                map.RenderMap(mapFirstLevel);
                try
                {
                    commandByUser.InputData();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);                
                }

                logic.LogicGame();               
                if (!logic.Status)
                {
                    Console.WriteLine($"{logic.Message}\n" +
                                       "Do you want play again?\n" +
                                       "If yes, press any key. " +
                                       "Else press Esc.");
                    if (Console.ReadKey().Key != ConsoleKey.Escape)
                    {
                        player.PlayerPositionX = 1;
                        player.PlayerPositionY = 1;
                        player.PlayerHitPoints = 10;
                        map.CreateMap(mapFirstLevel);
                        map.UpadateTrapOnMap(mapFirstLevel);
                        logic.Status = true;
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Clear();
            }
        }
    }
}
