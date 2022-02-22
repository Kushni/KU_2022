using System;
using System.Threading;

namespace WalkingHomunculus
{
    class Program
    {

        delegate void TickCommand(Object obj);

        internal static Timer timer;

        static Group group = new Group();

        static void Main(string[] args)
        {
            Map.CreateMap(1);
            Jeep jeep = new Jeep("Jeeps", "Green", new Coordinates(1, 1));
            jeep.GetNewWay(new Coordinates(300, 300));
            group.CreateNewUnit(jeep);
            TickCommand tickCommand = group.NextTickMove;
            tickCommand += group.WriteAllUnits;
            TimerCallback tm = new TimerCallback(tickCommand);
            //Console.WriteLine(Cell.GetCellNumber(new Coordinates(300, 300)));
            timer = new Timer(tm, 0, 0, 1000);
            ReadCommand readCommand = new ReadCommand();
            while (true)
            {
                readCommand.Read();
            }
            Console.ReadLine();
        }
    }
}
