using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Scout : Light
    {
        public Scout(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked)
        {
            typeMove = TypeMove.Flying;
            size = 18;
            SpeedUnit = 100;
            model = "Scout";
        }
    }
}
