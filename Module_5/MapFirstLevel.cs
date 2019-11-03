using System;
using System.Collections.Generic;

namespace Module_5
{
    public class MapFirstLevel : IMap
    {
        readonly Random random = new Random();

        private const int WIDTH = 11;
        private const int HEIGHT = 11;
        private const int COUNT_TRAP_ON_MAP = 10;
        private int prevPositionX;
        private int prevPositionY;
        private int trapPositionX;
        private int trapPositionY;
        private int damage;

        private readonly char[,] map = new char[WIDTH + 1, HEIGHT + 1];
        private readonly bool[,] isEmptyCellsOfMap = new bool[WIDTH + 1, HEIGHT + 1];

        private readonly IPlayer player;
        private readonly IPlayer quin;
        private Trap trap;

        public MapFirstLevel(IPlayer player,IPlayer quin)
        {
            this.player = VerifyPositionGamePerson(player, 1, 1);
            this.quin = VerifyPositionGamePerson(quin, 10, 10);
        }

        private IPlayer VerifyPositionGamePerson(IPlayer person, int positionX, int positionY)
        {
            if (!IsValidRangeOfObjectLocation(person))
            {
                person.PlayerPositionX = positionX;
                person.PlayerPositionY = positionY;
            }

            return person;
        }

        private bool IsValidRangeOfObjectLocation(IPlayer person)
        {
            if ((person.PlayerPositionX >= WIDTH) || (person.PlayerPositionX <= 0) ||
                (person.PlayerPositionY >= HEIGHT) || (person.PlayerPositionY <= 0))
            {
                return false;
            }
            else 
            {
                return true;            
            }
        }

        public List<ITrap> Traps { get;  } = new List<ITrap>();

        public void AddTrapOnMap()
        {
            for (int index = 0; index < COUNT_TRAP_ON_MAP;)
            {
                GenerateParametersOfTrap();
                if (isEmptyCellsOfMap[trapPositionX, trapPositionY])
                {
                    trap = new Trap(damage, trapPositionX, trapPositionY, true);
                    Traps.Add(trap);
                    isEmptyCellsOfMap[trapPositionX, trapPositionY] = false;
                    index++;
                }
            }
        }

        public void UpadateTrapOnMap()
        {
            for (int index = 0; index < Traps.Count;)
            {
                GenerateParametersOfTrap();
                if (isEmptyCellsOfMap[trapPositionX, trapPositionY])
                {
                    Traps[index].TrapDamage = damage;
                    Traps[index].TrapPositionX = trapPositionX;
                    Traps[index].TrapPositionY = trapPositionY;
                    Traps[index].TrapIsActive = true;
                    Traps[index].TrapIsVisible = false;

                    isEmptyCellsOfMap[trapPositionX, trapPositionY] = false;
                    index++;
                }
            }
        }

        private void GenerateParametersOfTrap()
        {
            trapPositionX = random.Next(1, 11);
            trapPositionY = random.Next(1, 11);
            damage = random.Next(1, 11);
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

        private void DrawTrap()
        {
            foreach (var item in Traps)
            {
                if (item.TrapIsVisible)
                {
                    map[item.TrapPositionY, item.TrapPositionX] = 'X';
                    item.TrapIsVisible = true;
                }
            }
        }

        public int Width { get; } = WIDTH;

        public int Height { get; } = HEIGHT;       
    }
}

