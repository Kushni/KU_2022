using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Light : Unit, Packable
    {
        public Light(string name, string color, Coordinates newcoordinates, bool ispacked = false) : base(name, color, newcoordinates, ispacked) 
        {
            model = "Test Light";
        }
        public bool GetIsPacked() { return IsPacked; }
        public int GetSize() { return size; }
        public void Pack(Coordinates coordinates) 
        {
            IsPacked = true;
            coordinatesThisPoint = coordinates;
        }
        public void UnPack() { IsPacked = false; }
        public override string ToString()
        {
            string s = base.ToString();
            s += $", Розмір = {size}";
            return s;
        }

        public bool CheckLandscape()
        {
            if (typeMove == TypeMove.Flying) return true;
            else if (typeMove == TypeMove.Ground && Map.AllCells[Cell.GetCellNumber(coordinatesThisPoint)].TypeLandscape) return true;
            else if (typeMove == TypeMove.Water && !Map.AllCells[Cell.GetCellNumber(coordinatesThisPoint)].TypeLandscape) return true;
            else return false;
        }

        public void MoveIn(Coordinates coordinates)
        {
            if (coordinatesThisPoint == coordinatesEndPoint)
            {
                coordinatesEndPoint = coordinates;
                coordinatesNextPoint = coordinates;
            }

            coordinatesThisPoint = coordinates;

            if (CellNumber != Cell.GetCellNumber(coordinatesThisPoint))
            {
                Map.AllCells[CellNumber].RemoveUnit(this);
                CellNumber = Cell.GetCellNumber(coordinatesThisPoint);
                Map.AllCells[CellNumber].AddUnit(this);
            }
        }

        internal override void Move()
        {
            if (!IsPacked) base.Move();
        }
    }
}