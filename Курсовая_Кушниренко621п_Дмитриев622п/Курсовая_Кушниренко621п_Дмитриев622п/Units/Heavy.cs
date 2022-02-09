using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    abstract class Heavy : Unit
    {
        public Heavy(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked) 
        {
            model = "Test Heavy";
        }
        public override string toString()
        {
            string s = base.toString();
            return s;
        }
    }
}
