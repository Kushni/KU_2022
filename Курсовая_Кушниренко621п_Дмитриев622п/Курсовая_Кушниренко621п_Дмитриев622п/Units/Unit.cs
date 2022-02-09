using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    abstract class Unit : Movable
    {
       
        public Unit(string name, string color, Coordinates newcoordinates, bool ispacked = false)
        {
            Name = name;
            Color = color;
            coordinates = newcoordinates;
            IsPacked = ispacked;
            id = Unit.idCounter++;
            model = "Test Unit";
            CellNumber = Cell.GetCellNumber(coordinates);
        }

        public enum TypeMove
        {
            Ground,
            Water,
            Flying,
        }

        protected TypeMove typeMove;

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

        Coordinates coordinatesEndPoint;

        List<Coordinates> WayToPoint; 
        
        internal void Move()
        {
            double LenghtMove = SpeedUnit;
            while (coordinates != coordinatesEndPoint)
            {
                double LenghtToPoint = Coordinates.VectorLength(coordinates, coordinatesNextPoint);
                Coordinates Difference = coordinatesNextPoint - coordinates;
                if (LenghtToPoint < LenghtMove) LenghtMove = MoveToPoint(LenghtMove);
                else
                {
                    coordinates += Difference
                }
            }
        }

        internal double MoveToPoint(double Speed)
        {
            Speed -= Coordinates.VectorLength(coordinates, coordinatesNextPoint);
            coordinates = coordinatesNextPoint;
            coordinatesNextPoint = WayToPoint[0];
            WayToPoint.RemoveAt(0);
            return Speed;
        }

        public virtual string toString()
        {
            string s = $"{this.model}: {Name}, ID={id}, Координаты:{{{coordinates.x}; {coordinates.y}}}, Регион:{CellNumber}";
            //if()  добавить конечную точку
            return s;
        }

    }
}
