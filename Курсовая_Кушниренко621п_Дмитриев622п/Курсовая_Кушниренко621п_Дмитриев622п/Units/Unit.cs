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
            coordinatesThisPoint = newcoordinates;
            coordinatesNextPoint = coordinatesThisPoint;
            coordinatesEndPoint = coordinatesThisPoint;
            IsPacked = ispacked;
            id = Unit.idCounter++;
            model = "Test Unit";
            CellNumber = Cell.GetCellNumber(coordinatesThisPoint);
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

        protected int SpeedUnit = 10;

        protected string model;

        public int size = 0;

        public int internalSize = 0;

        Coordinates coordinatesThisPoint;

        Coordinates coordinatesNextPoint;

        Coordinates coordinatesEndPoint;

        List<Coordinates> WayToPoint; 
        
        void NewSpeed (int newSpeed)
        {
            SpeedUnit = newSpeed;
        }

        internal void GetNewWay (Coordinates newcoordinatesEndPoint)
        {
            if (typeMove == TypeMove.Flying) 
            {
                coordinatesEndPoint = newcoordinatesEndPoint;
                coordinatesNextPoint = newcoordinatesEndPoint;
                return;
            }
            List<Coordinates> CheckWayList;
            FinderWay.FindWay(coordinatesThisPoint, newcoordinatesEndPoint, out CheckWayList);
            if (CheckWayList == null)
            {
                Console.WriteLine($"Не удалось найти путь для {Name} из точки {coordinatesThisPoint.ToString()} в точку {newcoordinatesEndPoint.ToString()}");
            } 
            else
            {
                coordinatesEndPoint = newcoordinatesEndPoint;
                WayToPoint = CheckWayList;
                coordinatesNextPoint = WayToPoint[0];
                WayToPoint.RemoveAt(0);
            }
        }

        internal virtual void Move()
        {
            double LenghtMove = SpeedUnit;
            while (coordinatesThisPoint != coordinatesEndPoint && LenghtMove > 0)
            {
                //Console.WriteLine($"{coordinatesThisPoint.ToString()} + {coordinatesNextPoint.ToString()} + {coordinatesEndPoint.ToString()} Speed {LenghtMove}");
                double LenghtToPoint = Coordinates.VectorLength(coordinatesThisPoint, coordinatesNextPoint);
                Coordinates Difference = coordinatesNextPoint - coordinatesThisPoint;
                if (LenghtToPoint <= LenghtMove) LenghtMove = MoveToPoint(LenghtMove);
                else
                {
                    coordinatesThisPoint += Difference * LenghtMove / LenghtToPoint;
                    LenghtMove = 0;
                }
            }
        }

        internal double MoveToPoint(double Speed)
        {
            Speed -= Coordinates.VectorLength(coordinatesThisPoint, coordinatesNextPoint);
            coordinatesThisPoint = coordinatesNextPoint;
            if (WayToPoint.Count > 0)
            {
                coordinatesNextPoint = WayToPoint[0];
                WayToPoint.RemoveAt(0);
            }
            return Speed;
        }

        public override string ToString()
        {
            string s = $"{this.model}: {Name}, ID={id}, Координаты:{{{coordinatesThisPoint.ToString()}}}, Регион:{CellNumber}";
            //if()  добавить конечную точку
            return s;
        }

    }
}
