using System.Collections.Generic;

namespace Module_5
{
    public interface IMap
    {
        int Width { get; }
        int Height { get; }

        void CreateMap();
        void UpadateTrapOnMap();
        void AddTrapOnMap(); 
        void RenderMap();        
    }
}
