using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class WayCell
    {
        internal WayCell (int newThisCellNumber, WayCell newParentCell) 
        {
            ThisCellNumber = newThisCellNumber;
            ParentCell = newParentCell;
        }

        public int ThisCellNumber { get; private set; }
        public WayCell ParentCell { get; private set; }

        internal bool GetTypeLandscape()
        {
            return Map.AllCells[ThisCellNumber].TypeLandscape;
        }
    }
}
