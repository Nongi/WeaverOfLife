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

            foreach (var m in list_monster)
            {
                /*m.move_ran(rnd);
                floor[m.x,m.y]=m.name;*/
                action(m);
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
                    Console.Write((map[i, j]==null ? "   " : map[i, j].acronyme) + ",");
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


        public void action(Monster m)
        {
            //m.vision
            //m.coord.x, 
            //m.coord.y
            switch (m.getAction())
            {
                case 0:
                    move(m);
                    break;
                case 1:
                    attack(m);
                    break;
                default:
                    break;
            }
        }

        public void attack(Monster m)
        {
        }

        public void move(Monster m)
        {
            move_ran(m);
        }

        public void move_ran(Monster m)
        {
            int x_old = m.coord.x;
            int y_old = m.coord.y;
            switch (rnd.Next(1, 5))
            {
                case (int)Move.Right:
                    m.coord.x++;
                    break;
                case (int)Move.Up:
                    m.coord.y++;
                    break;
                case (int)Move.Left:
                    m.coord.x--;
                    break;
                case (int)Move.Down:
                    m.coord.y--;
                    break;
                default:
                    break;
            }

            if (m.coord.x > width - 1)
                m.coord.x = width - 1;
            if (m.coord.x < 1)
                m.coord.x = 1;

            if (m.coord.y > heigth - 1)
                m.coord.y = heigth - 1;
            if (m.coord.y < 1)
                m.coord.y = 1;

            if (map[m.coord.x, m.coord.y] == null)
            {
                map[m.coord.x, m.coord.y] = m;
                map[x_old, y_old] = null;
            }
            else
            {
                m.coord.x = x_old;
                m.coord.y = y_old;
            }
        }
    }
}
