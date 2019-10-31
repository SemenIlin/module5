using System;

namespace Module_5
{
    public class Program
    {
        static void Main()
        {
            var program = new Program();
            var player = new Player(10, 1, 1);
            var quin = new Player(10, 10, 10, '$');
            
            var mapFirstLevel = new MapFirstLevel(player, quin);
            var logicFirstLevel = new LogicFirstLevel(mapFirstLevel);

            mapFirstLevel.CreateMap();
            mapFirstLevel.AddTrapOnMap();

            while (logicFirstLevel.Status)
            {
                mapFirstLevel.RenderMap();
                try
                {
                    logicFirstLevel.LogicGameInteractionWithOjects(program.InputData());
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                logicFirstLevel.LogicQuitOrUpdateLevelGame();

                Console.Clear();
            }
        }

        public Direction InputData()
        {
            var key = Console.ReadKey().Key;
            switch(key)
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
                    throw new ArgumentOutOfRangeException(nameof(Direction), $"Unknown direction: {key}");
            }
        }
    }
}
