using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    interface Packing
    {
        public void PackIN(Packable u);
        public void PackOUT(Packable u);
    }
}
/*
 List<Packable> carrying = new List<Packable>(0);
        public void Pack(Packable u)
        {
            if ((internalSize > carrying.Sum(unit => unit.GetSize()) + u.GetSize()) && (!u.GetIsPacked()))
            {
                carrying.Add(u);
                u.Pack();            
            }
        }
        public void UnPack(Packable u)
        {
            if (carrying.Contains(u)) 
            {
                carrying.RemoveAt(carrying.IndexOf(u));
            }
        }
 public override string toString()
        {
            string s = base.toString();
            s += $", Место={internalSize}, Свободно места = {internalSize - carrying.Sum(unit => unit.GetSize())}";
            if (carrying.Count != 0) 
            {
                s += $"\n    {Name}'s inventory:";
                foreach (Unit unit in carrying) 
                {
                    s += $"\n       {unit.toString()}";
                }
            }
            return s;
        }
 */