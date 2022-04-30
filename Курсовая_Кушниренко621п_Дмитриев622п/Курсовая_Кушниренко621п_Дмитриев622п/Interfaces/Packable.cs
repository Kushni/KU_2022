using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    interface Packable
    {
        public bool GetIsPacked();
        public int GetSize();
        public void Pack(Coordinates coordinates);
        public void UnPack();

        public bool CheckLandscape();

        public void MoveIn(Coordinates coordinates);
    }
}
/*
        public bool GetIsPacked() { return IsPacked; }
        public int GetSize() { return size; }
        public void Pack() { IsPacked = true; }
        public void UnPack() { IsPacked = false; }
*/