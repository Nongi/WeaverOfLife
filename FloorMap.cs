using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaverOfLife
{
    class FloorMap
    {
        int width, heigth;
        string[,] floor;

        Monster[,] map;

        public Random rnd { get; set; }

        List<Monster> list_monster = new List<Monster>();

        public FloorMap(int width_in, int heigth_in)
        {
            width = width_in;
            heigth = heigth_in;
            floor = new string[heigth, width];

            map = new Monster[heigth, width];

            rnd = new Random();
        }


        public void addMonster(MonsterCanvas mc_in)
        {
            int x = rnd.Next(0, width);
            int y = rnd.Next(0, heigth);

            var m = new Monster(mc_in, x, y, rnd);
            list_monster.Add(m);
            map[x, y] = m;
        }

        public void update_tab()
        {
            clean_tab();

            sort_Monster();
            /*
            foreach (var elt in list_monster)
                elt.name = "T";
            */

            foreach (var m in list_monster)
            {
                /*m.move_ran(rnd);
                floor[m.x,m.y]=m.name;*/

                move_ran(m);
            }
        }

        public void sort_Monster()
        {
            list_monster = list_monster.OrderByDescending(m => m.spd).ToList();
        }

        public  void display_tab()
        {
            Console.Clear();
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write((map[i, j]==null ? " " : map[i, j].name) + ",");
                }
                Console.WriteLine();
            } 
        }

        public  void clean_tab()
        {
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    floor[i, j]=" ";
                }
            }
        }




        public void move_ran(Monster m)
        {
            int x_old = m.x;
            int y_old = m.y;
            switch (rnd.Next(1, 5))
            {
                case (int)Move.Right:
                    m.x++;
                    break;
                case (int)Move.Up:
                    m.y++;
                    break;
                case (int)Move.Left:
                    m.x--;
                    break;
                case (int)Move.Down:
                    m.y--;
                    break;
                default:
                    break;
            }

            if (m.x > width-1)
                m.x = width - 1;
            if (m.x < 1)
                m.x = 1;

            if (m.y > heigth - 1)
                m.y = heigth - 1;
            if (m.y < 1)
                m.y = 1;

            if (map[m.x, m.y] == null)
            {
                map[m.x, m.y] = m;
                map[x_old, y_old] = null;
            }
            else
            {
                m.x = x_old;
                m.y = y_old;
            }
        }
    }
}
