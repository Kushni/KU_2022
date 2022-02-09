using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    abstract class Map
    {
        internal static Cell[] AllCells = new Cell[105];

        internal static void CreateMap (int k)
        {
            for (int i = 0; i < 100; ++i)
            {
                AllCells[i] = new Cell();
                AllCells[i].TypeLandscape = true;
            }
        }
    }
}
