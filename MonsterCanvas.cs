using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaverOfLife
{
    class MonsterCanvas
    {
        public string name { get; set; }

        public Tuple<int, int> hp { get; set; }
        public Tuple<int, int> atk { get; set; }
        public Tuple<int, int> def { get; set; }
        public Tuple<int, int> spd { get; set; }

        public MonsterCanvas(string name_in,
            Tuple<int, int> hp_tuple_in,
            Tuple<int, int> atk_tuple_in,
            Tuple<int, int> def_tuple_in,
            Tuple<int, int> spd_tuple_in)
        {
            name = name_in;
            hp = hp_tuple_in;
            atk = atk_tuple_in;
            def = def_tuple_in;
            spd = spd_tuple_in;
        }
    }
}
