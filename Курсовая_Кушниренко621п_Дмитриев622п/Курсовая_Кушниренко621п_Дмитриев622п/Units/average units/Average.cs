using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Average : Unit, Packing, Packable
    {
        public Average(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked)
        {
            model = "Test Average";
        }

        List<Packable> carrying = new List<Packable>(0);
        public void PackIN(Packable u)
        {
            if ((internalSize > carrying.Sum(unit => unit.GetSize()) + u.GetSize()) && (!u.GetIsPacked()))
            {
                carrying.Add(u);
                u.Pack();
            }
        }
        public void PackOUT(Packable u)
        {
            if (carrying.Contains(u))
            {
                carrying.RemoveAt(carrying.IndexOf(u));
            }
        }
        public bool GetIsPacked() { return IsPacked; }
        public int GetSize() { return size; }
        public void Pack() { IsPacked = true; }
        public void UnPack() { IsPacked = false; }
        public override string ToString()
        {
            string s = base.ToString();
            s += $", Размер = {size}";//packable
            s += $", Место={internalSize}, Свободно места = {internalSize - carrying.Sum(unit => unit.GetSize())}";//packing
            if (carrying.Count != 0)
            {
                s += $"\n{Name}'s inventory:";
                foreach (Unit unit in carrying)
                {
                    s += $"\n{unit.ToString()}";
                }
                s += $"\nend of{Name}'s inventory.";
            }
            return s;
        }
    }
}
