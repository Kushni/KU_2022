using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class RandomCommand
    {
        Group group;
        Random random = new Random();

        internal RandomCommand (Group newgroup)
        {
            group = newgroup;
            Log.Write("Create random start");
        }

        internal void CreateMap ()
        {
            int numberMap = random.Next(6) + 1;
            Log.Write("Create random map №" + numberMap);
            group.ChooseMap(numberMap);
        }

        internal Coordinates GetRandomCell()
        {
            return new Coordinates(random.NextDouble() * 1000.0, random.NextDouble() * 1000.0);
        }

        internal void CreateRandomUnit()
        {
            group.SpawnNewUnit(Group.AllModels[random.Next(10)], GetRandomCell());
        }

        internal void CreateRandomUnit (Coordinates coordinates)
        {
            group.SpawnNewUnit(Group.AllModels[random.Next(11)], coordinates);
        }

        internal void CreateSomeRandomUnits()
        {
            int n = random.Next(1, 11);

            for (int i = 0; i < n; ++i)
            {
                CreateRandomUnit();
            }

            Log.Write("Create random units");
        }
    }
}
