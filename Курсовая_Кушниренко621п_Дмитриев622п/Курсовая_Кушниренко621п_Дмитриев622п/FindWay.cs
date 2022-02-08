using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class FinderWay
    {
        internal void FindWay (Coordinates StartPoint, Coordinates EndPoint, out List <Coordinates> WayToPoint)
        {
            WayToPoint = new List<Coordinates>();
            int StartPointNumber = Cell.GetCellNumber(StartPoint);
        }
    }
}
