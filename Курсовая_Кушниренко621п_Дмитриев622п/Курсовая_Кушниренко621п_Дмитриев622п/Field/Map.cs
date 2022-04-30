using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Map
    {
        internal static Cell[] AllCells = new Cell[105];

        internal static void CreateMap (int k)
        {
            string map = GetMap(k);

            for (int i = 0; i < 100; ++i)
            {
                AllCells[i] = new Cell();
                if (map[i] == 'E') AllCells[i].TypeLandscape = true;
                else AllCells[i].TypeLandscape = false;
            }

            Log.Write("Create map №" + k);
        }

        internal static void CreateNewMap(string s)
        {
            string path = "Maps.dat";
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Append)))
            {
                binaryWriter.Write(s);
            }
        }

        internal static string GetMap(int n)
        {
            string map = "";
            string path = "Maps.dat";
            using (BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                for (int i = 1; i <= n; ++i)
                {
                    map = binaryReader.ReadString();
                }
            }
            return map;
        }
    }
}
