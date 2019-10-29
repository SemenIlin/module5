namespace Module_5
{
    class Trap : ITrap
    {
        public Trap(int damage, int x, int y, bool isActiveTrap = true, bool isVisibleTrap = false)
        {
            TrapDamage = damage;
            TrapPositionX = x;
            TrapPositionY = y;
            TrapIsActive = isActiveTrap;
            TrapIsVisible = isVisibleTrap;
        }

        public int TrapDamage { get; set; }

        public int TrapPositionX { get; set; }

        public int TrapPositionY { get; set; }

        public bool TrapIsActive { get; set; }

        public bool TrapIsVisible { get; set; }
    }
}
