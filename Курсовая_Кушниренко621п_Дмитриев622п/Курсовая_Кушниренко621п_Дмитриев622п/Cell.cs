using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_Кушниренко621п_Дмитриев622п
{
    class Cell
    {
        List<Unit> CellUnits;

        void AddUnit (Unit unit)
        {
            CellUnits.Add(unit);
        }

        void RemoveUnit (Unit unit)
        {
            CellUnits.Remove(unit);
        }

        List<Unit> GetUnits()
        {
            return CellUnits;
        }
    }
}
