namespace Module_5
{
    class Player :  IPlayer
    {
        private int _hitPoint;
        private int _x;
        private int _y;
        readonly char _view;

        public Player(int hitPoint = 10, int x = 1, int y = 1, char view ='@')
        {
            _hitPoint = hitPoint;
            _x = x;
            _y = y;
            _view = view;
        }
        
        public void SetHitPoint(int hitPoint) => _hitPoint = hitPoint;  
       
        public int GetHitPoint() => _hitPoint;      

        public void SetPositionX(int x) => _x = x;       

        public int GetPositionX() => _x;

        public void SetPositionY(int y) => _y = y;

        public int GetPositionY() => _y;

        public char GetView() => _view;        
    }
}
