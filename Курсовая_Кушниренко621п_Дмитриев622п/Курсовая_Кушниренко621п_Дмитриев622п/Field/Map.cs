using System;
using System.Collections.Generic;
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
            for (int i = 0; i < 100; ++i)
            {
                AllCells[i] = new Cell();
                if (i / 10 % 2 == 0) AllCells[i].TypeLandscape = true;
                else AllCells[i].TypeLandscape = false;
            }
            AllCells[15].TypeLandscape = true;
            AllCells[33].TypeLandscape = true;
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    if (AllCells[i * 10 + j].TypeLandscape) Console.Write("#");
                    else Console.Write("$");
                }
                Console.WriteLine();
            }
        }
    }
}
