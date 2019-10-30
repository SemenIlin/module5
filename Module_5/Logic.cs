using System;

namespace Module_5
{
    class Logic
    {
        public void LogicMoveGame(ILogicGame logic)
        {
            logic.LogicGame();        
        }

        public void LogicUpdateLevelGame(ILogicGame logic)
        {
            if (!logic.Status)
            {
                Console.WriteLine($"{logic.Message}\n" +
                                   "Do you want play again?\n" +
                                   "If yes, press any key. " +
                                   "Else press Esc.");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    logic.UpdateLevel();
                }
            }
        }
    }
}
