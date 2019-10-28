using System;
using System.Collections.Generic;
using System.Threading;

namespace Module_5
{
    class Map
    {
        readonly Random random = new Random();
        private const int WIDTH = 11;
        private const int HEIGHT = 11;
        private int _prevPositionX;
        private int _prevPositionY;
        private int _positionTrapX;
        private int _positionTrapY;
        private int _damage;

        readonly char[,] _map = new char[WIDTH + 1, HEIGHT + 1];
        readonly bool[,] _isEmpty = new bool[WIDTH + 1, HEIGHT + 1];

        readonly Player player; 
        readonly Player quin = new Player(10, 10, 10, '$');
        private Trap trap;

        public Map(Player player)
        {
            this.player = player;
        }

        public List<ITrap> Traps { get; private set; } = new List<ITrap>();

        public void AddTrapOnMap()
        {
            CreateMap();

            for (int index = 0; index < 10; )
            {
                _positionTrapX = random.Next(1, 11);
                _positionTrapY = random.Next(1, 11);
                _damage = random.Next(1, 11);

                if (_isEmpty[_positionTrapX, _positionTrapY])
                {
                    trap = new Trap(_damage, _positionTrapX, _positionTrapY);
                    Traps.Add(trap);
                    _isEmpty[_positionTrapX, _positionTrapY] = false;
                    index++;                             
                }
            }
        }

        private void CreateMap()
        {
            for (int index = 0; index <= HEIGHT; index++)
            {
                for (int index1 = 0; index1 <= WIDTH ; index1++)
                {
                    if ((index == 0) || (index == HEIGHT) || (index1 == 0) || (index1 == WIDTH))
                    {
                        _isEmpty[index, index1] = false;
                        _map[index, index1] = '#';
                    }
                    else if ((index == player.GetPositionY()) && (index1 == player.GetPositionX()))
                    {
                        _isEmpty[index, index1] = false;
                    }
                    else if ((index == quin.GetPositionY()) && (index1 == quin.GetPositionX()))
                    {
                        _isEmpty[index, index1] = false;
                    }
                    else
                    {
                        _isEmpty[index, index1] = true;
                        _map[index, index1] = ' ';
                    }
                }
            }
        }

        public void DrawMap()
        {
            _prevPositionX = player.GetPositionX();
            _prevPositionY = player.GetPositionY();
            
            Console.WriteLine($"\nHit points {player.GetHitPoint()}.");

            for (int index = 0; index <= HEIGHT; index++)
            {
                for (int index1 = 0; index1 <= WIDTH; index1++)
                {
                    if ((index == player.GetPositionY()) && (index1 == player.GetPositionX()))
                    {                       
                        _map[index, index1] = player.GetView();
                    }
                    else if ((index == quin.GetPositionY()) && (index1 == quin.GetPositionX()))
                    {
                        _map[index, index1] = quin.GetView();
                    }
                 
                    if ((index != _prevPositionY) && (index1 != _prevPositionX))
                    {
                        _map[_prevPositionY, _prevPositionX] = ' ';
                    }
                    Console.Write(_map[index, index1]);
                }

                Console.WriteLine();
            }

            Thread.Sleep(500);
        }

        public static int GetWidth()
        {
            return WIDTH;
        }

        public static int GetHeight()
        {
            return HEIGHT;
        }
    }
}
