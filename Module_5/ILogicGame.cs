namespace Module_5
{
    public interface ILogicGame
    {
        bool Status { get; set; }

        string Message { get; set; }

        void LogicGameInteractionWithOjects(Direction direction);

        void UpdateLevel();
    }
}
