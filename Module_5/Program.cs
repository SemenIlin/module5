using System;

namespace Module_5
{
    class Program
    {
        static void Main()
        {
            Player player = new Player(10, 1, 1);
            Player quin = new Player(10, 10, 10, '$');
            
            MapFirstLevel mapFirstLevel = new MapFirstLevel(player,quin);
            Map map = new Map();

            CommandByUser commandByUser = new CommandByUser();
            LogicFirstLevel logicFirstLevel = new LogicFirstLevel(player, quin, mapFirstLevel, commandByUser);
            Logic logic = new Logic();

            map.CreateMap(mapFirstLevel);
            map.AddTrapOnMap(mapFirstLevel);

            while (true)
            {
                map.RenderMap(mapFirstLevel);
                try
                {
                    commandByUser.InputData();
                    logic.LogicMoveGame(logicFirstLevel);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                logic.LogicUpdateLevelGame(logicFirstLevel);
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Clear();
            }
        }
    }
}
