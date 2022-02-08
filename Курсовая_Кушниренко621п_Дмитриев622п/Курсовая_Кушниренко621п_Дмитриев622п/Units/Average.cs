using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Average : Unit
    {
        public Average(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked)
        {
            model = "Test Average";
        }
    }
}
