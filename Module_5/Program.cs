
using System;

namespace Module_5
{
    class Program
    {
        static void Main()
        {
            Player player = new Player(10,1,1);
            Map map = new Map(player);
            map.AddTrapOnMap();

            while (true)
            {
                map.DrawMap();
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;                
                }
                if (!LogicUser.Status)
                {
                    Console.WriteLine($"{LogicUser.Message}\n"+
                                       "Do you want play again?\n"+
                                       "If yes, press any key. "+
                                       "Else press Esc.");
                    if (Console.ReadKey().Key != ConsoleKey.Escape)
                    {
                        player = new Player(10, 1, 1);
                        map = new Map(player);
                        map.AddTrapOnMap();
                        LogicUser.Status = true;
                    }
                    else 
                    {
                        break;                    
                    }
                    
                }
                
            }
        }
    }
}
