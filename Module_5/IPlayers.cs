﻿
namespace Module_5
{
    public interface IPlayer
    {
        int PlayerHitPoints { get; set; }
        int PlayerPositionX { get; set; }
        int PlayerPositionY { get; set; }
        char PlayerView { get; set; }        
    }
}
