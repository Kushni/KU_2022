using System;

namespace WalkingHomunculus
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Jeep jeep = new Jeep("Plyalya", "Green", new Coordinates(1, 1));
            Map.CreateMap(1);
            Console.WriteLine(jeep.ToString());
            Map.AllCells[2].TypeLandscape = false;
            jeep.NewSpeed(1000);
            jeep.GetDestination(new Coordinates(100, 1));
            jeep.Move();
            Console.WriteLine(jeep.ToString());
        }
    }
}
