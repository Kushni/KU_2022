using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Ship: Average
    {
        public Ship(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked)
        {
            typeMove = TypeMove.Water;
            size = 200;
            internalSize = 60;
            SpeedUnit = 30;
            model = "Ship";
        }
    }
}
