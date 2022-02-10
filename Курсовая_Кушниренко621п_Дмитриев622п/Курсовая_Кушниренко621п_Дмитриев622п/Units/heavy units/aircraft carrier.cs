using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class aircraft_carrier: Heavy
    {
        public aircraft_carrier(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked)
        {
            typeMove = TypeMove.Water;
            internalSize = 400;
            model = "aircraft_carrier";
        }
    }
}
