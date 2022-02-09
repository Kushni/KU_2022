using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Light : Unit
    {
        public Light(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked) 
        {
            model = "Test Light";
        }
        public override string ToString()
        {
            string s = base.ToString();
            return s;
        }
    }
}