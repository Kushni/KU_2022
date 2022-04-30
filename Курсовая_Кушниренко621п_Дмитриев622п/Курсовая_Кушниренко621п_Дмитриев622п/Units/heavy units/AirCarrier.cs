using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class AirCarrier: Heavy
    {
        public AirCarrier(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked)
        {
            typeMove = TypeMove.Water;
            internalSize = 400;
            SpeedUnit = 20;
            model = "AirCarrier";
        }
    }
}
