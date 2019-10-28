using System;

namespace Module_5
{
    class Program
    {
        static void Main()
        {
            Player player = new Player(10,1,1);
            Map map = new Map(player);
            Logic logic = new Logic(player, map.Traps);
            
            map.AddTrapOnMap(); 

            while (true)
            {
                map.DrawMap();
                logic.LogicGame();
               
                if (!logic.Status)
                {
                    Console.WriteLine($"{logic.Message}\n" +
                                       "Do you want play again?\n" +
                                       "If yes, press any key. " +
                                       "Else press Esc.");
                    if (Console.ReadKey().Key != ConsoleKey.Escape)
                    {
                        player.SetPositionX(1);
                        player.SetPositionY(1);
                        player.SetHitPoint(10);
                        map = new Map(player);
                        map.AddTrapOnMap();
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
