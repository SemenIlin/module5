using System.Collections.Generic;

namespace Module_5
{
    public interface IMap
    {
        List<ITrap> Traps { get;  }

        void CreateMap();

        void UpadateTrapOnMap();

        void AddTrapOnMap();        

        void RenderMap();
        
        int Width { get;  }

        int Height { get;  }
    }
}
