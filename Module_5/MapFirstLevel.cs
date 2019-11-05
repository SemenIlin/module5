using System;
using System.Collections.Generic;

namespace Module_5
{
    public class MapFirstLevel : IMap
    {
        private const int WIDTH = 11;
        private const int HEIGHT = 11;
        private const int COUNT_TRAP_ON_MAP = 10;

        private readonly Random random = new Random();

        private readonly char[,] map = new char[HEIGHT + 1, WIDTH + 1];
        private readonly bool[,] isEmptyCellsOfMap = new bool[HEIGHT + 1, WIDTH + 1];
        private readonly List<ITrap> traps;
        private readonly IPlayer player;
        private readonly IPlayer quin;

        private Trap trap;
        private int prevPositionX;
        private int prevPositionY;
        private int trapPositionX;
        private int trapPositionY;
        private int damage;

        public MapFirstLevel(IPlayer player, IPlayer quin, List<ITrap> traps)
        {
            this.player = player;
            this.quin = quin;
            this.traps = traps;
        }

        public int Width { get; } = WIDTH;
        public int Height { get; } = HEIGHT;

        public void AddTrapOnMap()
        {
            for (int index = 0; index < COUNT_TRAP_ON_MAP;)
            {
                GenerateParametersOfTrap();
                if (isEmptyCellsOfMap[trapPositionX, trapPositionY])
                {
                    trap = new Trap(damage, trapPositionX, trapPositionY, true);
                    traps.Add(trap);
                    isEmptyCellsOfMap[trapPositionX, trapPositionY] = false;
                    index++;
                }
            }
        }

        public void UpadateTrapOnMap()
        {
            for (int index = 0; index < traps.Count;)
            {
                GenerateParametersOfTrap();
                if (isEmptyCellsOfMap[trapPositionX, trapPositionY])
                {
                    traps[index].TrapDamage = damage;
                    traps[index].TrapPositionX = trapPositionX;
                    traps[index].TrapPositionY = trapPositionY;
                    traps[index].TrapIsActive = true;
                    traps[index].TrapIsVisible = false;

                    isEmptyCellsOfMap[trapPositionX, trapPositionY] = false;
                    index++;
                }
            }
        }

        public void CreateMap()
        {
            for (int positionY = 0; positionY <= HEIGHT; positionY++)
            {
                for (int positionX = 0; positionX <= WIDTH; positionX++)
                {
                    if ((positionY == 0) || (positionY == HEIGHT) ||
                        (positionX == 0) || (positionX == WIDTH))
                    {
                        isEmptyCellsOfMap[positionY, positionX] = false;
                        map[positionY, positionX] = '#';
                    }
                    else if ((positionY == player.PlayerPositionY) && 
                        (positionX == player.PlayerPositionX))
                    {
                        isEmptyCellsOfMap[positionY, positionX] = false;
                    }
                    else if ((positionY == quin.PlayerPositionY) && 
                        (positionX == quin.PlayerPositionX))
                    {
                        isEmptyCellsOfMap[positionY, positionX] = false;
                    }
                    else
                    {
                        isEmptyCellsOfMap[positionY, positionX] = true;
                        map[positionY, positionX] = ' ';
                    }
                }
            }
        }

        public void RenderMap()
        {
            prevPositionX = player.PlayerPositionX;
            prevPositionY = player.PlayerPositionY;
            DrawTrap();

            Console.WriteLine($"\nHit points {player.PlayerHitPoints}.");

            for (int positionY = 0; positionY <= HEIGHT; positionY++)
            {
                for (int positionX = 0; positionX <= WIDTH; positionX++)
                {
                    if ((positionY == player.PlayerPositionY) && 
                        (positionX == player.PlayerPositionX))
                    {
                        map[positionY, positionX] = player.PlayerView;
                    }
                    else if ((positionY == quin.PlayerPositionY) &&
                        (positionX == quin.PlayerPositionX))
                    {
                        map[positionY, positionX] = quin.PlayerView;
                    }

                    if ((positionY != prevPositionY) &&
                        (positionX != prevPositionX))
                    {
                        map[prevPositionY, prevPositionX] = ' ';
                    }
                    Console.Write(map[positionY, positionX]);
                }

                Console.WriteLine();
            }
        }

        private void GenerateParametersOfTrap()
        {
            trapPositionX = random.Next(1, 11);
            trapPositionY = random.Next(1, 11);
            damage = random.Next(1, 11);
        }

        private void DrawTrap()
        {
            foreach (var item in traps)
            {
                if (item.TrapIsVisible)
                {
                    map[item.TrapPositionY, item.TrapPositionX] = 'X';
                    item.TrapIsVisible = true;
                }
            }
        }
    }
}