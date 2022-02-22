using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Helicopter : Average
    {
        public Helicopter(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked)
        {
            typeMove = TypeMove.Flying;
            size = 35;
            internalSize = 6;
            SpeedUnit = 40;
            model = "Helicopter";
        }
    }
}