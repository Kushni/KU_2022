using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Heavy : Unit, Packing
    {
        public Heavy(TypeMove typemove, string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(typemove, name, color, newcoordinates, ispacked) 
        {
            internalSize = 20;
        }

        List<Packable> carrying = new List<Packable>(0);
        public void Pack(Packable u)
        {
            if ((internalSize < carrying.Sum(unit => unit.GetSize())) && (!u.GetIsPacked()))
            {
                carrying.Append(u);
                u.Pack();            }
        }
        public void UnPack(Packable u)
        {
            if (carrying.Contains(u)) 
            {
                carrying.RemoveAt(carrying.IndexOf(u));
            }
        }
    }
}
