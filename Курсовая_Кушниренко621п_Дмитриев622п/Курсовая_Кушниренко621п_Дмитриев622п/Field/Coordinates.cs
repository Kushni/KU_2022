using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Coordinates
    {
        public static double VectorLength (Coordinates Start, Coordinates End)
        {
            return Math.Pow((Start.x - End.x) * (Start.x - End.x) + (Start.y - End.y) * (Start.y - End.y), 0.5);
        }

        internal Coordinates (double newx, double newy)
        {
            x = newx;
            y = newy;
        }

        public static Coordinates operator + (Coordinates coordinates1, Coordinates coordinates2)
        {
            return new Coordinates(coordinates1.x + coordinates2.x, coordinates2.y + coordinates1.y);
        }

        public static Coordinates operator - (Coordinates coordinates1, Coordinates coordinates2)
        {
            return new Coordinates(coordinates1.x - coordinates2.x, coordinates1.y - coordinates2.y);
        }

        public static Coordinates operator * (Coordinates coordinatesThisPoint, double number)
        {
            return new Coordinates(coordinatesThisPoint.x * number, coordinatesThisPoint.y * number);
        }

        public static Coordinates operator / (Coordinates coordinatesThisPoint, double number)
        {
            return new Coordinates(coordinatesThisPoint.x / number, coordinatesThisPoint.y / number);
        }

        internal double x;
        internal double y;

        public override string ToString()
        {
            string s = $"({x}, {y})";
            return s;
        }
    }
}
