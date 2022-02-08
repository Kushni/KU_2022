using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    interface Packing
    {
        public void Pack(Packable u);
        public void UnPack(Packable u);
    }
}
