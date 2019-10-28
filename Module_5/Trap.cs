namespace Module_5
{
    class Trap : ITrap
    {
        private int _damage;
        private int _x;
        private int _y;
        private bool _isActiveTrap;
        

        public Trap(int damage, int x, int y, bool isActiveTrap = true)
        {
            _damage = damage;
            _x = x;
            _y = y;
            _isActiveTrap = isActiveTrap;
        }

        public void SetDamage(int hitPoint) => _damage = hitPoint;  
                
        public int GetDamage() => _damage;       

        public void SetPositionX(int x) => _x = x;
 
        public int GetPositionX() => _x;       

        public void SetPositionY(int y) => _y = y;

        public int GetPositionY() => _y;

        public void SetIsActiveTrap(bool active) => _isActiveTrap = active;      

        public bool GetIsActiveTrap() => _isActiveTrap;
    }
}
