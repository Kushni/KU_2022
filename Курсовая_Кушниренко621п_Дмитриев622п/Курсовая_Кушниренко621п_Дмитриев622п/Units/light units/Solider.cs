using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Solider : Light, Packable
    {
        public Solider(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked)
        {
            typeMove = TypeMove.Ground;
            size = 1;
            model = "Solider";
        }
        public bool GetIsPacked() { return IsPacked; }
        public int GetSize() { return size; }
        public void Pack() { IsPacked = true; }
        public void UnPack() { IsPacked = false; }
        public override string ToString()
        {
            string s = base.ToString();
            s += $", Размер = {size}";
            return s;
        }
    }
}
