using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Group
    {

        internal List<Unit> AllUnits = new List<Unit>();

        internal void CreateNewUnit (Unit newUnit)
        {
            AllUnits.Add(newUnit);
        }

        internal void DeleteUnit (Unit unit)
        {
            AllUnits.Remove(unit);
        }

        internal bool DeleteUnit (int id)
        {
            foreach (Unit i in AllUnits)
            {
                if (i.id == id)
                {
                    AllUnits.Remove(i);
                    return true;
                }
            }
            return false;
        }

        public void WriteAllUnits(Object obj)
        {
            Console.Clear();
            foreach (Unit i in AllUnits)
            {
                Console.WriteLine(i.ToString());
            }
        }

        internal void NextTickMove(Object obj)
        {
            foreach (Unit i in AllUnits)
            {
                i.Move();
            }
        }
    }
}
