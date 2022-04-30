using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Cell
    {
        public bool TypeLandscape { get; internal set; }

        List<Unit> CellUnits = new List<Unit>();

        internal void AddUnit (Unit unit)
        {
            CellUnits.Add(unit);
        }

        internal void RemoveUnit (Unit unit)
        {
            CellUnits.Remove(unit);
        }

        public static int GetCellNumber (double dx, double dy)
        {
            int x = (int)(dx);
            int y = (int)(dy);
            return y / 100 * 10 + x / 100;
        }

        public static int GetCellNumber (Coordinates point)
        {
            int x = (int)(point.x);
            int y = (int)(point.y);
            return y / 100 * 10 + x / 100;
        }

        internal List<Unit> GetUnits()
        {
            return CellUnits;
        }
    }
}
