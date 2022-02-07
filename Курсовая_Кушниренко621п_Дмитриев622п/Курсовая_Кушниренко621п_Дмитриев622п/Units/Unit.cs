using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    abstract class Unit
    {
        enum TypeMove
        {
            Ground,
            Water,
            Flying,
        }

        TypeMove typeMove;

        int id;

        string Name;

        public bool IsPacked { get; protected set; }

        string Color;

        public int CellNumber { get; internal set; }

        Coordinates coordinates { get; set; }
    }
}
