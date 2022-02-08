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
            id = Unit.idCounter++;
            model = "Test Unit";
        }

        public enum TypeMove
        {
            Ground,
            Water,
            Flying,
        }

        TypeMove typeMove;

        private static int idCounter=0;

        public int id { get; private set; }

        protected string Name;

        public bool IsPacked { get; protected set; }

        string Color;

        public int CellNumber { get; internal set; }

        //Перенес GetCellNumber в класс Cell

        int SpeedUnit = 10;

        protected string model;

        public int size = 0;

        public int internalSize = 0;

        Coordinates coordinates;

        Coordinates coordinatesNextPoint;

        List<Coordinates> WayToPoint;

        void TryMove ()
        {
            double LenghtX = coordinatesNextPoint.x - coordinates.x;
            double LenghtY = coordinatesNextPoint.y - coordinates.y;
        }

        public virtual string toString()
        {
            string s = $"{this.model}: {Name}, ID={id}, Координаты:{{{coordinates.x}; {coordinates.y}}}, Регион:{CellNumber}";
            //if()  добавить конечную точку
            return s;
        }
    }
}
