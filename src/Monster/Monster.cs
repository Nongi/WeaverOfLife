﻿using System;
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

        public Tuple<int, int> hp { get; set; }
        public Tuple<int, int> atk { get; set; }
        public Tuple<int, int> def { get; set; }
        public Tuple<int, int> spd { get; set; }

        public int vision = 1;

        public Coordinates coord {get; set;}

        public string name { get; set; }
        public string acronyme { get; set; }

        public Monster(int hp_in, int x_in, int y_in, string name_in)
        {
        }

        public Monster(MonsterCanvas mc_in, int x_in, int y_in, Random rnd_in)
        {

            coord = new Coordinates(x_in, y_in);

            int birth_hp = rnd_in.Next(mc_in.hp.Item1, mc_in.hp.Item2);
            hp = new Tuple<int,int>(birth_hp,birth_hp);

            int birth_atk = rnd_in.Next(mc_in.atk.Item1, mc_in.atk.Item2);
            atk = new Tuple<int, int>(birth_atk, birth_atk);

            int birth_def = rnd_in.Next(mc_in.def.Item1, mc_in.def.Item2);
            def = new Tuple<int, int>(birth_atk, birth_atk);

            int birth_spd = rnd_in.Next(mc_in.spd.Item1, mc_in.spd.Item2);
            spd = new Tuple<int, int>(birth_atk, birth_atk);

            name = mc_in.name;
            acronyme = mc_in.acronyme;
        }



        public int getAction()
        {
            return 0;
        }
    }
}
