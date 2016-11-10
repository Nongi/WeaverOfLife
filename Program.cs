using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeaverOfLife
{
    enum Move { Right = 1, Up = 2, Left = 3, Down = 4 };

    class Program
    {

        static void Main(string[] args)
        {
            var floor = new FloorMap(25, 25);


            /*
             * MonsterCanvas (Race)
             *      name
             *      hp
             *      atk
             *      def
             *      spd
             */
            var knight_race = new MonsterCanvas("K",
                Tuple.Create(20, 30),
                Tuple.Create(5, 10),
                Tuple.Create(10, 20),
                Tuple.Create(5, 10));
            var witch_race = new MonsterCanvas("W",
                Tuple.Create(10, 20),
                Tuple.Create(10, 15),
                Tuple.Create(5, 10),
                Tuple.Create(10, 15));

            for (int i = 0; i <= 10; i++)
            {
                floor.addMonster(knight_race);
                floor.addMonster(witch_race);
            }
            try
            {
                while (true)
                {
                    floor.update_tab();
                    floor.display_tab();
                    Thread.Sleep(500);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }


    }
}
