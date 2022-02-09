using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    interface Movable
    {
        internal void Move(List<Coordinates> WayToPoint);

        internal int MoveToPoint(int Speed, Coordinates NextWayPoint);
    }
}
