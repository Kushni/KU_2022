using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    abstract class Unit
    {

        public enum TypeMove
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
        public Unit(TypeMove typemove, string name, string color)
        {
            typeMove = typemove;
            Name = name;
            Color = color;
            IsPacked = false;
        }
        public Unit(TypeMove typemove, string name, string color, bool ispacked)
        {
            typeMove = typemove;
            Name = name;
            Color = color;
            IsPacked = ispacked;
        }
    }
}
