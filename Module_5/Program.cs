using System;
using System.Collections.Generic;

namespace Module_5
{
    public class Program
    {
        static void Main()
        {
            var player = new Player(10, 1, 1);
            var quin = new Player(10, 10, 10, '$');
            var traps = new List<ITrap>();
            
            var mapFirstLevel = new MapFirstLevel(player, quin, traps);
            var logicFirstLevel = new LogicFirstLevel(mapFirstLevel, player, quin, traps);

            mapFirstLevel.CreateMap();
            mapFirstLevel.AddTrapOnMap();

            while (logicFirstLevel.Status)
            {
                mapFirstLevel.RenderMap();
                try
                {
                    logicFirstLevel.LogicGameInteractionWithOjects(InputData());
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                logicFirstLevel.LogicQuitOrUpdateLevelGame();

                Console.Clear();
            }
        }

        private static Direction InputData()
        {
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    return Direction.Left;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    return Direction.Right;                    
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    return Direction.Up;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    return Direction.Down;
                default:
                    return InputData();                    
            }
        }
    }
}
