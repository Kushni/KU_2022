using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Group
    {

        public List<Unit> AllUnits { get; private set; }

        internal static string[] AllModels = new string[] { "soldier", "scout", "boat", "bike", "truck", "airtruck", "aircarrier", "ship", "jeep", "helicopter" };

        public Group()
        {
            AllUnits = new List<Unit>();
            Log.Write("Create Group");
        }

        internal void CreateNewUnit(Unit newUnit)
        {
            AllUnits.Add(newUnit);

            Log.Write($"Command: CreateNewUnit {newUnit.id} {newUnit.GetThisCoordinates()} {newUnit.model}");
        }

        Unit FindUnit(int id)
        {
            foreach (Unit i in AllUnits)
            {
                if (i.id == id) return i;
            }
            return null;
        }

        internal void DeleteUnit(Unit unit)
        {
            try
            {
                AllUnits.Remove(unit);
                Log.Write($"Command: DeleteUnit {unit.model} {unit.GetThisCoordinates()} {unit.id}");
            }
            catch
            {

                Console.WriteLine("Такого юніту немає на мапі");
                Log.Write($"Error command: DeleteUnit {unit.model} {unit.GetThisCoordinates()} {unit.id}");
            }
        }

        internal void DeleteUnit(int id)
        {
            Unit unit = FindUnit(id);

            if (unit == null)
            {
                Console.WriteLine("Такого юніту немає на мапі");
                Log.Write($"Error command: DeleteUnit {id}");
            }
            else
            {
                AllUnits.Remove(unit);
                Log.Write($"Command: DeleteUnit {id}");
            }

        }

        public void WriteAllUnits()
        {
            foreach (Unit i in AllUnits)
            {
                if (i is Packable)
                {
                    if ((i as Packable).GetIsPacked()) continue;
                }
                Console.WriteLine(i.ToString());
            }

            Log.Write($"Command: WriteAllUnits");
        }

        public void WriteAllUnits(object obj)
        {
            Console.Clear();
            foreach (Unit i in AllUnits)
            {
                if (i is Packable)
                {
                    if ((i as Packable).GetIsPacked()) continue;
                }
                Console.WriteLine(i.ToString());
            }
        }

        internal void NextTickMove(Object obj)
        {
            foreach (Unit i in AllUnits)
            {
                i.Move();
            }
        }

        internal void Help()
        {
            Console.WriteLine("Усі наявні команди:\n" + "help - вивід інформації щодо наявних команд\n" + "continue - продовження роботи програми\n" +
                "models - показати усі варіанти моделей юнітів\n" + "seemap - виведення мапи у консоль\n" + "infoall - виведення детальної інформації про усіх юнітів\n"
                + "position id - показати на мапі клітинку, де знаходиться юніт\n" +
                "infounit id - виведення детальної інформації про юніт за номером id\n" + "infocell id - виведення інформації про клітинку з номером id\n" +
                "delete id - видалення юніту id\n" + "infocell x y - виведення інформації про клітинку за координатами x y\n" +
                "pack idloader idcargo - пакування юніту idcargo у юніт idloader\n" + "unpack idloader idcargo - розпакування юніту idcargo у юніт idloader\n" +
                "goto id x y - змінити точку призначення для юніту id у точку x y\n" + "spawn model x y - створити нового юніту типу model у точці x y\n");

            Log.Write($"Command: Help");
        }

        internal void SeeMap()
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    if (Map.AllCells[i * 10 + j].TypeLandscape == true) Console.Write("E");
                    else Console.Write("W");
                }
                Console.WriteLine();
            }

            Log.Write($"Command: Seemap");
        }

        internal void InfoAll()
        {
            WriteAllUnits();
        }

        internal void ModelsInfo()
        {
            Console.WriteLine("Легкі юніти - упаковуються\nВажкі юніти - упаковують\nСередні юніти- упаковують і упаковуються\nНаземні:\nsoldier - легкий\n" +
                "bike - легкий\njeep - середній\ntruck - важкий\nВодні:\nboat - легкий\nship - середній\naircarrier - важкий\n" +
                "Повітряні:\nscout - легкий\nhelicopter - середній\nairtruck - важкий\n");

            Log.Write("Command: ModelsInfo");
        }

        internal void InfoUnit(int id)
        {
            Unit unit = FindUnit(id);

            if (unit == null)
            {
                Console.WriteLine($"Юніт {id} не знайдено");
                Log.Write($"Error command: InfoUnit {id}");
            }
            else
            {
                Console.WriteLine(unit.ToString());
                Log.Write($"Command: InfoUnit {id}");
            }
        }

        internal void InfoCell(int id)
        {
            if (id < 0 || id >= 100)
            {
                Console.WriteLine($"Клітинка {id} не знайдена");
                Log.Write($"Error command: InfoCell {id}");
            }

            Cell cell = Map.AllCells[id];

            Console.WriteLine($"ID: {id}");

            if (cell.TypeLandscape == true) Console.WriteLine($"Тип поверхні - Earth");
            else Console.WriteLine($"Тип поверхні - Water");

            Console.WriteLine("Юніти у клітинці:");

            List<Unit> UnitsInCell = cell.GetUnits();

            foreach (Unit i in UnitsInCell)
            {
                Console.WriteLine(i.ToString());
            }

            Log.Write($"Command: InfoCell {id}");
        }

        internal void InfoCellV2(int x, int y)
        {

            Coordinates coordinates = new Coordinates(x, y);

            if (x < 1 || x > 1000 || y < 1 || y > 1000)
            {
                Console.WriteLine("Клітинку не знайдено");
                Log.Write($"Error command: InfoCellV2 ({x}; {y})");
            }
            else
            {
                int id = Cell.GetCellNumber(new Coordinates(x, y));
                Log.Write($"Command: InfoCellV2 ({x}, {y})");
                InfoCell(id);
            }
        }

        internal void ShowUnitPosition(int id)
        {
            Unit unit = FindUnit(id);

            if (unit == null)
            {
                Console.WriteLine($"Юніт {id} не знайдено");
                Log.Write($"Error command: ShowUnitPosition {id}");
                return;
            }

            for (int i = 0; i < 100; ++i)
            {
                if (i % 10 == 0) Console.WriteLine();
                if (i == unit.GetThisCell()) Console.Write("U");
                else if (Map.AllCells[i].TypeLandscape) Console.Write("E");
                else Console.Write("W");
            }
            Console.WriteLine();

            Log.Write($"Command: ShowUnitPosition {id}");
        }

        internal void PackUnit(int idHeavy, int idLight)
        {
            Unit heavyUnit = FindUnit(idHeavy);
            Unit lightUnit = FindUnit(idLight);

            if (heavyUnit == null || lightUnit == null || !(heavyUnit is Packing) || !(lightUnit is Packable))
            {
                Console.WriteLine($"Не вдалося упакувати {idLight} у {idHeavy}");
                Log.Write($"Error command: PackUnit {idHeavy}, {idLight}");
            }
            else
            {
                Log.Write($"Command: PackUnit {idHeavy}, {idLight}");

                (heavyUnit as Packing).PackIN(lightUnit as Packable);
            }
        }

        internal void UnPackUnit(int idHeavy, int idLight)
        {
            Unit heavyUnit = FindUnit(idHeavy);
            Unit lightUnit = FindUnit(idLight);

            if (heavyUnit == null || lightUnit == null || !(heavyUnit is Packing) || !(lightUnit is Packable))
            {
                Console.WriteLine($"Не вдалося упакувати {idLight} у {idHeavy}");
                Log.Write($"Error command: UnPackUnit {idHeavy}, {idLight}");
            }
            else
            {
                (heavyUnit as Packing).PackOUT(lightUnit as Packable);

                Log.Write($"Command: UnPackUnit {idHeavy}, {idLight}");
            }
        }

        internal void GetNewWay(int id, int x, int y)
        {
            Unit unit = FindUnit(id);
            Coordinates coordinates = new Coordinates(x, y);

            if (unit == null)
            {
                Console.WriteLine($"Не вдалося знайти юніт.");
                Log.Write($"Error command: GetNewWay {id}, ({x}; {y})");
            }
            else
            {
                Log.Write($"Command: GetNewWay {id}, ({x}, {y})");

                unit.GetNewWay(coordinates);
            }
        }

        internal void ChooseMap(int n)
        {
            if (n == 0)
            {
                for (int i = 0; i < 6; ++i)
                {
                    Console.WriteLine($"{i + 1}:");
                    string map = Map.GetMap(i + 1);
                    for (int j = 0; j < 10; ++j)
                    {
                        for (int k = 0; k < 10; ++k)
                        {
                            Console.Write(map[j * 10 + k]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }

                Log.Write("Show all maps");
            }
            else
            {
                Map.CreateMap(n);
            }
        }

        internal void SpawnNewUnit(string model, int x, int y)
        {
            Coordinates coordinates = new Coordinates(x, y);
            SpawnNewUnit(model, coordinates);
        }

        internal void SpawnNewUnit(string model, Coordinates coordinates)
        {
            switch (model)
            {
                case "helicopter":
                    CreateNewUnit(new Helicopter(NameDealer.GetName(), "Green", coordinates));
                    break;
                case "jeep":
                    if (Map.AllCells[Cell.GetCellNumber(coordinates)].TypeLandscape) CreateNewUnit(new Jeep(NameDealer.GetName(), "Green", coordinates));
                    else
                    {
                        Console.WriteLine("Не можна поставити на воді");
                        Log.Write($"Error command: SpawnNewUnit {model} {coordinates}");
                    }
                    break;
                case "aircarrier":
                    if (!Map.AllCells[Cell.GetCellNumber(coordinates)].TypeLandscape) CreateNewUnit(new AirCarrier(NameDealer.GetName(), "Green", coordinates));
                    else
                    {
                        Console.WriteLine("Не можна поставити на суші");
                        Log.Write($"Error command: SpawnNewUnit {model} {coordinates}");
                    }
                    break;
                case "bike":
                    if (Map.AllCells[Cell.GetCellNumber(coordinates)].TypeLandscape) CreateNewUnit(new Bike(NameDealer.GetName(), "Green", coordinates));
                    else
                    {
                        Console.WriteLine("Не можна поставити на воді");
                        Log.Write($"Error command: SpawnNewUnit {model} {coordinates}");
                    }
                    break;
                case "soldier":
                    if (Map.AllCells[Cell.GetCellNumber(coordinates)].TypeLandscape) CreateNewUnit(new Soldier(NameDealer.GetName(), "Green", coordinates));
                    else
                    {
                        Console.WriteLine("Не можна поставити на воді");
                        Log.Write($"Error command: SpawnNewUnit {model} {coordinates}");
                    }
                    break;
                case "truck":
                    if (Map.AllCells[Cell.GetCellNumber(coordinates)].TypeLandscape) CreateNewUnit(new Truck(NameDealer.GetName(), "Green", coordinates));
                    else
                    {
                        Console.WriteLine("Не можна поставити на воді");
                        Log.Write($"Error command: SpawnNewUnit {model} {coordinates}");
                    }
                    break;
                case "scout":
                    CreateNewUnit(new Scout(NameDealer.GetName(), "Green", coordinates));
                    break;
                case "airtruck":
                    CreateNewUnit(new Airtruck(NameDealer.GetName(), "Green", coordinates));
                    break;
                case "boat":
                    if (!Map.AllCells[Cell.GetCellNumber(coordinates)].TypeLandscape) CreateNewUnit(new Boat(NameDealer.GetName(), "Green", coordinates));
                    else
                    {
                        Console.WriteLine("Не можна поставити на суші");
                        Log.Write($"Error command: SpawnNewUnit {model} {coordinates}");
                    }
                    break;
                case "ship":
                    if (!Map.AllCells[Cell.GetCellNumber(coordinates)].TypeLandscape) CreateNewUnit(new Ship(NameDealer.GetName(), "Green", coordinates));
                    else
                    {
                        Console.WriteLine("Не можна поставити на суші");
                        Log.Write($"Error command: SpawnNewUnit {model} {coordinates}");
                    }
                    break;
                default:
                    Console.WriteLine("Хибна назва юніту");
                    Log.Write($"Error command: SpawnNewUnit {model} {coordinates}");
                    break;
            }
        }
    }
}
