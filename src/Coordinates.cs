using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaverOfLife
{
    class Coordinates
    {
        public int x { get; set; }
        public int y { get; set; }

        public Coordinates(int x_in, int y_in)
        {
            x = x_in;
            y = y_in;
        }
    }
}
