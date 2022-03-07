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
            Log.Write($"Add unit {newUnit.model} {newUnit.id}");
        }

        internal void DeleteUnit (Unit unit)
        {
            try
            {
                AllUnits.Remove(unit);
                Log.Write($"Delete unit {unit.model} {unit.id}");
            }
            catch
            {
                Log.Write($"Error delete unit {unit.model} {unit.id}");
            }
        }

        internal bool DeleteUnit (int id)
        {
            foreach (Unit i in AllUnits)
            {
                if (i.id == id)
                {
                    AllUnits.Remove(i);
                    Log.Write($"Delete {id} unit {i.model}");
                    return true;
                }
            }
            Log.Write($"Error delete unit {id}");
            return false;
        }

        public void WriteAllUnits(Object obj)
        {
            Console.Clear();
            foreach (Unit i in AllUnits)
            {
                Console.WriteLine(i.ToString());
            }
            Log.Write($"Show all units");
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
