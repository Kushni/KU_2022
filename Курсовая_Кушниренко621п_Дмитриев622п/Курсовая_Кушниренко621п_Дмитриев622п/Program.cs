using System;

namespace WalkingHomunculus
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Light l = new Light(Unit.TypeMove.Ground, "sussyboi", "red", new Coordinates(1, 2));
            Heavy h = new Heavy(Unit.TypeMove.Ground, "sussyboi2", "red", new Coordinates(1, 2));
            Console.WriteLine(l.toString());
            Console.WriteLine(h.toString());
            h.Pack(l);
            Console.WriteLine(l.toString());
            Console.WriteLine(h.toString());
            h.UnPack(l);
            Console.WriteLine(l.toString());
            Console.WriteLine(h.toString());
        }
    }
}
