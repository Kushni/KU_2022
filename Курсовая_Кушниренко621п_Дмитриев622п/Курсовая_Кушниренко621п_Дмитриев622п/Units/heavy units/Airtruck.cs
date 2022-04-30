using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Airtruck: Heavy
    {
        public Airtruck(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked)
        {
            typeMove = TypeMove.Flying;
            internalSize = 150;
            SpeedUnit = 80;
            model = "Airtruck";
        }
    }
}
