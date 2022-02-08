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

        Packable[] carrying = new Packable[0];
        public void Pack(Packable u)
        {
            if (internalSize < ) 
            {
                carrying.Append(u);
                
            }
        }
        public void UnPack(Packable u)
        {
            
        }
    }
}
