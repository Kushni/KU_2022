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

            Queue<WayCell> WayInCells = new Queue<WayCell>();

            WayInCells.Enqueue(new WayCell(StartPointNumber, null));

            
        }

        WayCell FindWayBFS (Queue<WayCell> WayInCells, int EndPointNumber)
        {
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
    }
}
