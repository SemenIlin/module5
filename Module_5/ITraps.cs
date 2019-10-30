
namespace Module_5
{
    public interface ITrap
    {
        int TrapDamage { get; set; }

        int TrapPositionX { get; set; }

        int TrapPositionY { get; set; }

        bool TrapIsActive { get; set; }

        bool TrapIsVisible { get; set; }        
    }
}
