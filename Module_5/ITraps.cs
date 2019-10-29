
namespace Module_5
{
    interface ITrap
    {
        int TrapDamage { get; set; }

        int TrapPositionX { get; set; }

        int TrapPositionY { get; set; }

        bool TrapIsActive { get; set; }

        bool TrapIsVisible { get; set; }        
    }
}
