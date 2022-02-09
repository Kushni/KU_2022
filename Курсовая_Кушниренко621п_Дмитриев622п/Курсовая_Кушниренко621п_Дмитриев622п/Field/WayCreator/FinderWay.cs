using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class FinderWay
    {
        internal static void FindWay(Coordinates StartPoint, Coordinates EndPoint, out List<Coordinates> WayToPoint)
        {
            WayToPoint = new List<Coordinates>();
            int StartPointNumber = Cell.GetCellNumber(StartPoint);
            int EndPointNumber = Cell.GetCellNumber(EndPoint);

            WayToPoint.Add(EndPoint);

            if (StartPointNumber != EndPointNumber)
            {
                WayCell EndPointCell = FindWayBFS(StartPointNumber, EndPointNumber);
                WayToPoint = GetWayToPoint(EndPointCell, EndPoint);
            }
            WayToPoint.Reverse();
        }

        internal static WayCell FindWayBFS (int StartPointNumber, int EndPointNumber)
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

                //Console.WriteLine(ThisWayCell.ThisCellNumber);

                for (int i = 0; i < 4; ++i)
                {
                    WayCell NextWayCell = new WayCell(ThisWayCell.ThisCellNumber + a[i], ThisWayCell);
                    if (NextWayCell.ThisCellNumber <= -1 || NextWayCell.ThisCellNumber >= 100) continue;
                    if (b[i] == 1 && ThisWayCell.ThisCellNumber / 10 - NextWayCell.ThisCellNumber / 10 != 0) continue;
                    if (CheckedCell[NextWayCell.ThisCellNumber]) continue;
                    if (ThisWayCell.GetTypeLandscape() != NextWayCell.GetTypeLandscape()) continue;
                    WayInCells.Enqueue(NextWayCell);
                    CheckedCell[NextWayCell.ThisCellNumber] = true;
                }
                
            }
            return null;
        }

        internal static List<Coordinates> GetWayToPoint (WayCell ThisWayCell, Coordinates ThisCoordinates)
        {

            WayCell NextWayCell = ThisWayCell.ParentCell;
            List<Coordinates> WayToPoint = new List<Coordinates>();
            WayToPoint.Add(ThisCoordinates);
            Console.WriteLine("Bya");
            //Environment.Exit(1);
            while (ThisWayCell.ParentCell != null)
            {

               // Console.WriteLine(ThisWayCell.ThisCellNumber);
               // Console.WriteLine(ThisCoordinates);

                int x = (int)(ThisCoordinates.x);
                int y = (int)(ThisCoordinates.y);

               /** Console.WriteLine((x / 100 + 1) * 100);
                Console.WriteLine((x / 100 - 1) * 100 + 99);
                Console.WriteLine((y / 100 + 1) * 100);
                Console.WriteLine((y / 100 - 1) * 100 + 99);
               Console.WriteLine();*/

                switch (ThisWayCell.ThisCellNumber - NextWayCell.ThisCellNumber)
                {
                    case -1:
                        WayToPoint.Add(new Coordinates((x / 100 + 1) * 100, y));
                        break;
                    case 1:
                        WayToPoint.Add(new Coordinates((x / 100 - 1) * 100 + 99, y));
                        break;
                    case -10:
                        WayToPoint.Add(new Coordinates(x, (y / 100 + 1) * 100));
                        break;
                    case 10:
                        WayToPoint.Add(new Coordinates(x, (y / 100 - 1) * 100 + 99));
                        break;

                }

                ThisWayCell = NextWayCell;
                NextWayCell = ThisWayCell.ParentCell;
                ThisCoordinates = WayToPoint[WayToPoint.Count - 1];

            }
            //Console.WriteLine("Bya");
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
            coordinatesThisPoint = newcoordinates;
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

        Coordinates coordinatesThisPoint;

        Coordinates coordinatesNextPoint;

        Coordinates coordinatesEndPoint;

        List<Coordinates> WayToPoint; 
        
        internal void Move()
        {
            double LenghtMove = SpeedUnit;
            while (coordinatesThisPoint != coordinatesEndPoint)
            {
                double LenghtToPoint = Coordinates.VectorLength(coordinatesThisPoint, coordinatesNextPoint);
                Coordinates Difference = coordinatesNextPoint - coordinatesThisPoint;
                if (LenghtToPoint < LenghtMove) LenghtMove = MoveToPoint(LenghtMove);
                else
                {
                    coordinatesThisPoint += Difference
                }
            }
        }

        internal double MoveToPoint(double Speed)
        {
            Speed -= Coordinates.VectorLength(coordinatesThisPoint, coordinatesNextPoint);
            coordinatesThisPoint = coordinatesNextPoint;
            coordinatesNextPoint = WayToPoint[0];
            WayToPoint.RemoveAt(0);
            return Speed;
        }

        public virtual string toString()
        {
            string s = $"{this.model}: {Name}, ID={id}, Координаты:{{{coordinatesThisPoint.x}; {coordinatesThisPoint.y}}}, Регион:{CellNumber}";
            //if()  добавить конечную точку
            return s;
        }

    }
}

*/
