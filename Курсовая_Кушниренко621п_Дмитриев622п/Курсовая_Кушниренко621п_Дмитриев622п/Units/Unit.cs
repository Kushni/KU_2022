using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    abstract class Unit
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
            Map.AllCells[CellNumber].AddUnit(this);
        }

        public enum TypeMove
        {
            Ground,
            Water,
            Flying,
        }

        protected TypeMove typeMove;

        protected static int idCounter=0;

        public int id { get; private set; }

        protected string Name;

        protected bool IsPacked;

        protected string Color;

        public int CellNumber { get; protected set; }

        //Перенес GetCellNumber в класс Cell

        protected int SpeedUnit = 10;

        public string model { get; protected set; }

        public int size = 0;

        public int internalSize = 0;

        protected Coordinates coordinatesThisPoint;

        protected Coordinates coordinatesNextPoint;

        protected Coordinates coordinatesEndPoint;

        protected List<Coordinates> WayToPoint = new List<Coordinates>();

        FinderWay finderWay = new FinderWay();

        protected void NewSpeed (int newSpeed)
        {
            SpeedUnit = newSpeed;
        }

        internal int GetThisCell()
        {
            return Cell.GetCellNumber(coordinatesThisPoint);
        }

        internal Coordinates GetThisCoordinates()
        {
            return coordinatesThisPoint;
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
            finderWay.FindWay(coordinatesThisPoint, newcoordinatesEndPoint, out CheckWayList);
            if (CheckWayList == null)
            {
                Console.WriteLine($"Не удалось найти путь для {Name} из точки {coordinatesThisPoint.ToString()} в точку {newcoordinatesEndPoint.ToString()}");
                Log.Write("Error find way");
            } 
            else if (CheckWayList.Count > 0)
            {
                coordinatesEndPoint = newcoordinatesEndPoint;
                WayToPoint = CheckWayList;
                coordinatesNextPoint = WayToPoint[0];
                WayToPoint.RemoveAt(0);
            }
            else
            {
                coordinatesEndPoint = newcoordinatesEndPoint;
                coordinatesNextPoint = newcoordinatesEndPoint;
            }
        }

        internal virtual void Move()
        {
            double LenghtMove = SpeedUnit;
            while (coordinatesThisPoint != coordinatesEndPoint && LenghtMove > 0)
            {
                
                double LenghtToPoint = Coordinates.VectorLength(coordinatesThisPoint, coordinatesNextPoint);
                Coordinates Difference = coordinatesNextPoint - coordinatesThisPoint;

                if (LenghtToPoint <= LenghtMove) LenghtMove = MoveToPoint(LenghtMove);
                else
                {
                    coordinatesThisPoint += Difference * LenghtMove / LenghtToPoint;
                    LenghtMove = 0;
                }

                if (CellNumber != Cell.GetCellNumber(coordinatesThisPoint))
                {
                    Map.AllCells[CellNumber].RemoveUnit(this);
                    CellNumber = Cell.GetCellNumber(coordinatesThisPoint);
                    Map.AllCells[CellNumber].AddUnit(this);
                }
            }
        }

        protected double MoveToPoint(double Speed)
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
            string s = $"{this.model}: {Name}, ID={id}, Координати:{{{coordinatesThisPoint.ToString()}}}, Область:{CellNumber}";
            //if()  добавить конечную точку
            return s;
        }

    }
}
