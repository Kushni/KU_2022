using System;
using System.Threading;

namespace WalkingHomunculus
{
    class MainClass
    {

        delegate void TickCommand(Object obj);

        static void Main(string[] args)
        {
            Map.CreateMap(1);
            Jeep jeep = new Jeep("Jeeps", "Green", new Coordinates(1, 1));
            jeep.GetNewWay(new Coordinates(300, 300));
            Group group = new Group();
            group.CreateNewUnit(jeep);
            TickCommand tickCommand = group.NextTickMove;
            tickCommand += group.WriteAllUnits;
            TimerCallback tm = new TimerCallback(tickCommand);
            Timer timer = new Timer(tm, 0, 0, 1000);
            Console.ReadLine();
        }
    }
}
