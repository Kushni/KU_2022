using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class FinderWay
    {
        internal void FindWay(Coordinates StartPoint, Coordinates EndPoint, out List<Coordinates> WayToPoint)
        {
            WayToPoint = new List<Coordinates>();
            int StartPointNumber = Cell.GetCellNumber(StartPoint);
            int EndPointNumber = Cell.GetCellNumber(EndPoint);

            if (StartPointNumber == EndPointNumber)
            {
                WayToPoint.Add(EndPoint);
            }
            else
            {
                WayCell EndPointCell = FindWayBFS(StartPointNumber, EndPointNumber);
                WayToPoint = GetWayToPoint(EndPointCell, StartPoint);
            }
        }

        WayCell FindWayBFS (int StartPointNumber, int EndPointNumber)
        {
            Queue<WayCell> WayInCells = new Queue<WayCell>();
            WayInCells.Enqueue(new WayCell(StartPointNumber, null));
            bool[] CheckedCell = new bool[105];
            int[] a = new int[] { 1, -1, 10, -10 };
            int[] b = new int[] { 1, 1, 10, 10 };

            while (WayInCells.Count > 0)
            {

                WayCell ThisWayCell = WayInCells.Peek();
                WayInCells.Dequeue();
                if (ThisWayCell.ThisCellNumber == EndPointNumber) return ThisWayCell;


                for (int i = 0; i < 4; ++i)
                {
                    WayCell NextWayCell = new WayCell(ThisWayCell.ThisCellNumber + a[i], ThisWayCell);
                    if (ThisWayCell.GetTypeLandscape() != NextWayCell.GetTypeLandscape()) continue;
                    else if (b[i] == 1)
                    {
                        if (ThisWayCell.ThisCellNumber / 10 - NextWayCell.ThisCellNumber / 10 != 0) continue;
                    } 
                    else
                    {
                        if (NextWayCell.ThisCellNumber > -1 && NextWayCell.ThisCellNumber < 100) continue;
                    }
                    WayInCells.Enqueue(NextWayCell);
                    CheckedCell[NextWayCell.ThisCellNumber] = true;
                }
                
            }
            return null;
        }

        List<Coordinates> GetWayToPoint (WayCell ThisWayCell, Coordinates ThisCoordinates)
        {

            WayCell NextWayCell = ThisWayCell.ParentCell;
            List<Coordinates> WayToPoint = new List<Coordinates>();

            while (ThisWayCell.ParentCell != null)
            {

                switch (ThisWayCell.ThisCellNumber - NextWayCell.ThisCellNumber)
                {
                    case -1:
                        WayToPoint.Add(new Coordinates((ThisCoordinates.x / 100 + 1) * 100, ThisCoordinates.y));
                        break;
                    case 1:
                        WayToPoint.Add(new Coordinates((ThisCoordinates.x / 100 - 1) * 100 + 99, ThisCoordinates.y));
                        break;
                    case -10:
                        WayToPoint.Add(new Coordinates(ThisCoordinates.x, (ThisCoordinates.y / 100 + 1) * 100));
                        break;
                    case 10:
                        WayToPoint.Add(new Coordinates(ThisCoordinates.x, (ThisCoordinates.y / 100 - 1) * 100 + 99));
                        break;

                }

            }

            return WayToPoint;
        }
    }
}

/**
 * case появился только опосля...
 * 
            if (ThisWayCell.ThisCellNumber - NextWayCell.ThisCellNumber == -1)
                {
                    WayToPoint.Add(new Coordinates((ThisCoordinates.x / 100 + 1) * 100, ThisCoordinates.y));
                }
                else if (ThisWayCell.ThisCellNumber - NextWayCell.ThisCellNumber == 1)
                {
                    WayToPoint.Add(new Coordinates((ThisCoordinates.x / 100 - 1) * 100 + 99, ThisCoordinates.y));
                }
                else if (ThisWayCell.ThisCellNumber - NextWayCell.ThisCellNumber == -10)
                {
                    WayToPoint.Add(new Coordinates(ThisCoordinates.x, (ThisCoordinates.y / 100 + 1) * 100));
                }
                else if (ThisWayCell.ThisCellNumber - NextWayCell.ThisCellNumber == 10)
                {
                    WayToPoint.Add(new Coordinates(ThisCoordinates.x, (ThisCoordinates.y / 100 - 1) * 100 + 99));
                }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    abstract class Unit : Movable
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
            CellNumber = Cell.GetCellNumber(coordinates);
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

*/
