using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    interface Movable
    {
        internal void Move() { }

        internal int MoveToPoint(double Speed) { return 0; }
    }
}
