using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Light : Unit, Packable
    {
        public Light(TypeMove typemove, string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(typemove, name, color, newcoordinates, ispacked) 
        {
            size = 2;
        }
        public void Pack()
        {
            IsPacked = true;
        }
        public void UnPack()
        {
            IsPacked = false;
        }
    }
}