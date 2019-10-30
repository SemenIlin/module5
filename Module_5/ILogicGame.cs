namespace Module_5
{
    interface ILogicGame
    {
        bool Status { get; set; }

        string Message { get; set; }

        void LogicGame();

        void UpdateLevel();
    }
}
