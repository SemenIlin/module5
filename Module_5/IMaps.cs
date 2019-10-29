namespace Module_5
{
    interface IMap
    {
        void CreateMap();

        void UpadateTrapOnMap();

        void AddTrapOnMap();        

        void RenderMap();
        
        int Width { get;  }

        int Height { get;  }
    }
}
