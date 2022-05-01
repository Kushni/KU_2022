using System;
using System.Threading;

namespace WalkingHomunculus
{
    class Program
    {

        delegate void TickCommand(Object obj);

        internal static Timer timer;


        static void Main(string[] args)
        {
            Log.Clear();

            Group group = new Group();
            RandomCommand randomCommand = new RandomCommand(group);

            int typeWorldBuild;
            Console.WriteLine("Виберіть як ви хочете створити початкову мапу:\n" +
                "1) Власноруч\n" + "2) Випадково");

            while (true)
            {
                try
                {
                    typeWorldBuild = int.Parse(Console.ReadLine());
                    if (typeWorldBuild > 2 || typeWorldBuild < 1) continue;
                    break;
                }
                catch { }
            }

            if (typeWorldBuild == 1)
            {

                Console.WriteLine("Виберіть мапу");
                group.ChooseMap(0);
                while (true)
                {
                    try
                    {
                        int k = int.Parse(Console.ReadLine());
                        if (k >= 1 && k <= 6) group.ChooseMap(k);
                        else
                        {
                            Console.WriteLine("Виберіть одну із новедених мап.");
                            Log.Write("Error creating map");
                            throw new Exception();
                        }
                        break;
                    }
                    catch { }
                }
            }
            else
            {
                randomCommand.CreateMap();
                randomCommand.CreateSomeRandomUnits();
            }
            
            TickCommand tickCommand = group.NextTickMove;
            tickCommand += group.WriteAllUnits;
            TimerCallback tm = new TimerCallback(tickCommand);

            timer = new Timer(tm, 0, 0, 1000);
            ReadCommand readCommand = new ReadCommand();
            while (true)
            {
                readCommand.Read(group);
            }
            Console.ReadLine();
        }
    }
}
