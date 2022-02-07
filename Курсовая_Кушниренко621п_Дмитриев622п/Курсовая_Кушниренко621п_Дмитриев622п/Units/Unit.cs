using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    abstract class Unit
    {
       
        public Unit(TypeMove typemove, string name, string color, Coordinates newcoordinates, bool ispacked = false)
        {
            typeMove = typemove;
            Name = name;
            Color = color;
            coordinates = newcoordinates;
            IsPacked = ispacked;
        }

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

        int GetCellNuber (int x, int y)
        {
            return y / 100 * 10 + x / 100 + x % 100 > 0 ? 1 : 0;
        }

        int SpeedUnit = 10;


        Coordinates coordinates;

        Coordinates coordinatesNextPoint;

        void TryMove ()
        {
            double LenghtX = coordinatesNextPoint.x - coordinates.x;
            double LenghtY = coordinatesNextPoint.y - coordinates.y;
        }
    }
}
