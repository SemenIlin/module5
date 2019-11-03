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

        public IPlayer Player { get; }
        public IPlayer Quin { get; }
        private Trap trap;

        public MapFirstLevel(IPlayer player,IPlayer quin)
        {
            Player = VerifyPositionGamePerson(player, 1, 1);
            Quin = VerifyPositionGamePerson(quin, 10, 10);
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
            for (int index = 0; index <= HEIGHT; index++)
            {
                for (int index1 = 0; index1 <= WIDTH; index1++)
                {
                    if ((index == 0) || (index == HEIGHT) ||
                        (index1 == 0) || (index1 == WIDTH))
                    {
                        isEmptyCellsOfMap[index, index1] = false;
                        map[index, index1] = '#';
                    }
                    else if ((index == Player.PlayerPositionY) && 
                        (index1 == Player.PlayerPositionX))
                    {
                        isEmptyCellsOfMap[index, index1] = false;
                    }
                    else if ((index == Quin.PlayerPositionY) && 
                        (index1 == Quin.PlayerPositionX))
                    {
                        isEmptyCellsOfMap[index, index1] = false;
                    }
                    else
                    {
                        isEmptyCellsOfMap[index, index1] = true;
                        map[index, index1] = ' ';
                    }
                }
            }
        }

        public void RenderMap()
        {
            prevPositionX = Player.PlayerPositionX;
            prevPositionY = Player.PlayerPositionY;
            DrawTrap();

            Console.WriteLine($"\nHit points {Player.PlayerHitPoints}.");

            for (int index = 0; index <= HEIGHT; index++)
            {
                for (int index1 = 0; index1 <= WIDTH; index1++)
                {
                    if ((index == Player.PlayerPositionY) && 
                        (index1 == Player.PlayerPositionX))
                    {
                        map[index, index1] = Player.PlayerView;
                    }
                    else if ((index == Quin.PlayerPositionY) &&
                        (index1 == Quin.PlayerPositionX))
                    {
                        map[index, index1] = Quin.PlayerView;
                    }

                    if ((index != prevPositionY) &&
                        (index1 != prevPositionX))
                    {
                        map[prevPositionY, prevPositionX] = ' ';
                    }
                    Console.Write(map[index, index1]);
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

