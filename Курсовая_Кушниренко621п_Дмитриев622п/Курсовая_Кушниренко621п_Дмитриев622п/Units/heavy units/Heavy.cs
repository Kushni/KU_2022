using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    abstract class Heavy : Unit, Packing
    {
        public Heavy(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked) 
        {
            model = "Test Heavy";
        }
        List<Packable> carrying = new List<Packable>(0);
        public void PackIN(Packable u)
        {
            if ((internalSize > carrying.Sum(unit => unit.GetSize()) + u.GetSize()) && (!u.GetIsPacked()) && GetThisCell() == (u as Unit).GetThisCell())
            {
                carrying.Add(u);
                u.Pack(coordinatesThisPoint);
                Log.Write($"Command: PackIN {(u as Unit).id}, {id}");
            }
            else
            {
                Console.WriteLine($"Не вдалося упакувати {(u as Unit).id} у юніт {id}");
                Log.Write($"Error command: PackIN {(u as Unit).id}, {id}");
            }
        }
        public void PackOUT(Packable u)
        {
            if (carrying.Contains(u) && u.CheckLandscape())
            {
                carrying.RemoveAt(carrying.IndexOf(u));
                u.UnPack();
                Log.Write($"Error command: PackIN {(u as Unit).id}, {id}");
            }
            else
            {
                Console.WriteLine($"Не вдалося розпакувати {(u as Unit).id} з юніту {id}");
                Log.Write($"Error command: PackOUT {(u as Unit).id}, {id}");
            }
        }

        protected void Transportation()
        {
            foreach (Packable i in carrying)
            {
                i.MoveIn(coordinatesThisPoint);
            }
        }

        internal override void Move()
        {
            base.Move();
            Transportation();
        }

        public override string ToString()
        {
            string s = base.ToString();
            s += $", Місткість={internalSize}, Свободний простір = {internalSize - carrying.Sum(unit => unit.GetSize())}";
            if (carrying.Count != 0)
            {
                s += $"\n{Name}'s inventory:";
                foreach (Unit unit in carrying)
                {
                    s += $"\n\t{unit.ToString()}";
                }
                s += $"\nend of {Name}'s inventory.";
            }
            return s;
        }
    }
}
