using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaverOfLife
{
    class HandlerGlobal
    {
        private static HandlerGlobal instance;

        private HandlerGlobal() { }

        public static HandlerGlobal Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new HandlerGlobal();
                }
                return instance;
            }
        }


        //Need Json Package http://www.nuget.org/packages/Newtonsoft.Json
        /*  Exemple :
            // Write the contents of the variable someClass to a file.
            WriteToBinaryFile<SomeClass>("C:\someClass.txt", object1);

            // Read the file contents back into a variable.
            SomeClass object1= ReadFromBinaryFile<SomeClass>("C:\someClass.txt");         
        */

        public static MonsterCanvas loadMonsterCanvas(string path_in)
        {
            using (StreamReader file = File.OpenText(path_in))
            {
                JsonSerializer serializer = new JsonSerializer();
                MonsterCanvas mc_out = (MonsterCanvas)serializer.Deserialize(file, typeof(MonsterCanvas));
                return mc_out;
            }
        }


        public static void saveMonsterCanvas(string path_in, MonsterCanvas monsterCanvas_in)
        {
            using (StreamWriter file = File.CreateText(path_in))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, monsterCanvas_in);
            }
        }
    }
}
