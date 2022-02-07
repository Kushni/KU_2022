using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_Кушниренко621п_Дмитриев622п
{
    abstract class Unit
    {
        
        enum TypeMove
        {
            Ground,
            Water,
            Flying,
        }

        TypeMove typeMove;

        int id;

        string Name;

        public bool IsPacked { get; protected set; }

        string Color;

        Coordinates coordinates { get; set; }
    }
}
