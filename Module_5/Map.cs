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
        private int prevPositionX;
        private int prevPositionY;

        readonly char[,] _map = new char[WIDTH + 1, HEIGHT + 1];
        readonly bool[,] _isEmpty = new bool[WIDTH + 1, HEIGHT + 1];

        readonly Player _player; 
        readonly Player quin = new Player(10, 10, 10, '$');
        private Trap trap;
        readonly LogicUser moveUser = new LogicUser();
        readonly List<ITrap> traps = new List<ITrap>();

        public Map(Player player)
        {
            _player = player;
        }

        public void AddTrapOnMap()
        {
            int x;
            int y;
            int damage;

            FillingBoolArray();

            for (int index = 0; index < 10; )
            {
                x = random.Next(1, 11);
                y = random.Next(1, 11);
                damage = random.Next(1, 11);

                if (_isEmpty[x, y])
                {
                    trap = new Trap(damage, x, y);
                    traps.Add(trap);

                    _isEmpty[x, y] = false;
                    index++;                             
                }
            }    
        }

        private bool[,] FillingBoolArray()
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
                    else if ((index == _player.GetPositionY()) && (index1 == _player.GetPositionX()))
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

            return _isEmpty;
        }

        public void DrawMap()
        {
            prevPositionX = _player.GetPositionX();
            prevPositionY = _player.GetPositionY();
            moveUser.Move(_player, traps);
            
            Console.WriteLine($"\nHit points {_player.GetHitPoint()}.");

            for (int index = 0; index <= HEIGHT; index++)
            {
                for (int index1 = 0; index1 <= WIDTH; index1++)
                {
                    if ((index == _player.GetPositionY()) && (index1 == _player.GetPositionX()))
                    {                       
                        _map[index, index1] = _player.GetView();
                    }
                    else if ((index == quin.GetPositionY()) && (index1 == quin.GetPositionX()))
                    {
                        _map[index, index1] = quin.GetView();
                    }
                    else
                    {
                        //foreach (var item in traps)
                        //{
                        //    if ((index == item.GetPositionY()) && (index1 == item.GetPositionX()))
                        //    {
                        //        _map[index, index1] = 'u';
                        //    }
                        //}
                    }
                    if ((index != prevPositionY) && (index1 != prevPositionX))
                    {
                        _map[prevPositionY, prevPositionX] = ' ';
                    }
                    Console.Write(_map[index, index1]);
                }

                Console.WriteLine();
            }

            Thread.Sleep(500);

            Console.Clear();
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
