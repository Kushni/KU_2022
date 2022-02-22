using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Quad_Bike: Light
    {
        public Quad_Bike(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked)
        {
            typeMove = TypeMove.Ground;
            size = 4;
            SpeedUnit = 15;
            model = "Quad_Bike";
        }
    }
}
