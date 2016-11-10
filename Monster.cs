using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeaverOfLife
{
    class Monster
    {
        MonsterCanvas race_stat;

        public int hp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int spd { get; set; }


        public int x { get; set; }
        public int y { get; set; }
        public string name { get; set; }

        public Monster(int hp_in, int x_in, int y_in, string name_in)
        {
            x = x_in;
            y = y_in;
            hp = hp_in;
            name = name_in;
        }

        public Monster(MonsterCanvas mc_in, int x_in, int y_in, Random rnd_in)
        {
            x = x_in;
            y = y_in;
            hp = rnd_in.Next(mc_in.hp.Item1, mc_in.hp.Item2);
            atk = rnd_in.Next(mc_in.atk.Item1, mc_in.atk.Item2);
            def = rnd_in.Next(mc_in.def.Item1, mc_in.def.Item2);
            spd = rnd_in.Next(mc_in.spd.Item1, mc_in.spd.Item2);
            name = mc_in.name;
        }

        public void move_ran(Random rnd_in)
        {
            switch (rnd_in.Next(1, 5))
            {
                case (int)Move.Right: 
                    x++;
                    break;
                case (int)Move.Up:
                    y++;
                    break;
                case (int)Move.Left:
                    x--;
                    break;
                case (int)Move.Down:
                    y--;
                    break;
                default:
                    break;
            }

            if (x > 24)
                x = 24;
            if (x < 1)
                x = 1;

            if (y > 24)
                y = 24;
            if (y < 1)
                y = 1;
        }

    }
}
