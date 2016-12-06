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
        
        /// <summary>
        /// Mix DNA (race stat) of two same race monster
        /// </summary>
        /// <param name="m">Monster to compare and maybe replicate</param>
        /// <param name="rnd_in">Random number to blend in :P</param>
        public MonsterCanvas replicate(Monster m, Random rnd_in)
        {
            // Controler le type
            if (name == m.name)
            {
                // Calcul affinite
                if (rnd_in.NextDouble() > 0.5f)
                {
                    // Mix de stats
                    Tuple<int,int> hp_temp = rnd_tuple(hp, m.hp, rnd_in);
                    Tuple<int,int> atk_temp = rnd_tuple(atk, m.atk, rnd_in);
                    Tuple<int,int> def_temp = rnd_tuple(def, m.def, rnd_in);
                    Tuple<int,int> spd_temp = rnd_tuple(spd, m.spd, rnd_in);

                    MonsterCanvas mc_temp = new MonsterCanvas(name, acronyme, hp_temp, atk_temp, def_temp, spd_temp);
                    return mc_temp;
                }
            }
            else return null;
        }


        /// <summary>
        /// Randomize a Tuple(int,int).
        /// </summary>
        /// <returns>Randomize Tuple(int,int).</returns>
        /// <param name="t_female">T female.</param>
        /// <param name="t_male">T male.</param>
        /// <param name="rnd_in">Random in.</param>
        private Tuple<int,int> rnd_tuple(Tuple<int,int> t_female, Tuple <int,int> t_male, Random rnd_in)
        {
            Tuple<int,int> t_out = new Tuple<int, int>(rnd_min_max(t_female.Item1, t_male.Item1, rnd_in), rnd_min_max(t_female.Item2,t_male.Item2,rnd_in));
            return t_out;
        }

        /// <summary>
        /// Randomize between two int.
        /// The sign and order doesn't matter
        /// </summary>
        /// <returns>The minimum max.</returns>
        /// <param name="i">The index.</param>
        /// <param name="j">J.</param>
        /// <param name="rnd_in">Random in.</param>
        private int rnd_min_max(int i, int j, Random rnd_in)
        {
            int int_out = rnd_in.Next(Math.Min(i, j), Math.Max(i, j));
            return int_out;
        }
    }
}
