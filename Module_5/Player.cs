namespace Module_5
{
    public class Player :  IPlayer
    {
        public Player(int hitPoint = 10, int x = 1, int y = 1, char view ='@')
        {
            PlayerHitPoints = hitPoint;
            PlayerPositionX = x;
            PlayerPositionY = y;
            PlayerView = view;
        }

        public int PlayerHitPoints { get; set; }

        public int PlayerPositionX { get; set; }

        public int PlayerPositionY { get; set; }

        public char PlayerView { get; set; }
    }
}
