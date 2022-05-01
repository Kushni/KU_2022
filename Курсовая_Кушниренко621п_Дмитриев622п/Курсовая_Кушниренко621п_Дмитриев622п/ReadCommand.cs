using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class ReadCommand
    {

        bool TimerStop = false;
        ConsoleKeyInfo key;
        delegate void OneNumberCommand(int firstNumber);
        delegate void TwoNumberCommand(int firstNumber, int secondNumber);
        delegate void ThreeNumberCommand(int firstNumber, int secondNumber, int thirdNumber);
        delegate void SpawnCommand(string modelUnit, int firstNumber, int secondNumber);

        internal void Read(Group group)
        {
            string s = "";
            if (!TimerStop) key = Console.ReadKey(true);
            TimerStop = true;
            Console.WriteLine();
            Program.timer.Change(Timeout.Infinite, Timeout.Infinite);
            s = Console.ReadLine();
            GetTheCommand(s, group);
        }

        void GetTheCommand(string command, Group group)
        {
            command = command.Trim();
            command = command.ToLower();
            string[] commandWords = command.Split(" ");
            switch (commandWords.Length)
            {
                case 1:
                    switch (commandWords[0])
                    {
                        case "help":
                            //Вызов команды help
                            Log.Write("Use command help");
                            group.Help();                            
                            break;
                        case "continue":
                            Log.Write("Use command continue");
                            TimerStop = false;
                            Program.timer.Change(0, 1000);
                            break;
                        case "seemap":
                            Log.Write("Use command seemap");
                            group.SeeMap();
                            break;
                        case "infoall":
                            Log.Write("Use command infoall");
                            group.InfoAll();
                            break;
                        case "models":
                            Log.Write("Use command models");
                            group.ModelsInfo();
                            break;
                        default:
                            Console.WriteLine("Була введена недійсна команда");
                            Log.Write($"Wrong command {command}");
                            break;
                    }
                    break;
                case 2:
                    switch (commandWords[0])
                    {
                        case "infounit":
                            Log.Write("Use command infounit");
                            TryCommand(commandWords, group.InfoUnit);
                            break;
                        case "infocell":
                            Log.Write("Use command infocell");
                            TryCommand(commandWords, group.InfoCell);
                            break;
                        case "delete":
                            Log.Write("Use command delete");
                            TryCommand(commandWords, group.DeleteUnit);
                            break;
                        case "position":
                            Log.Write("Use command position");
                            TryCommand(commandWords, group.ShowUnitPosition);
                            break;
                        default:
                            Console.WriteLine("Була введена недійсна команда");
                            Log.Write($"Wrong command {command}");
                            break;
                    }
                    break;
                case 3:
                    switch (commandWords[0])
                    {
                        case "pack":
                            Log.Write("Use command pack");
                            TryCommand(commandWords, group.PackUnit);
                            break;
                        case "unpack":
                            Log.Write("Use command unpack");
                            TryCommand(commandWords, group.UnPackUnit);
                            break;
                        case "infocell":
                            Log.Write("Use command infocell v.2");
                            TryCommand(commandWords, group.InfoCellV2);
                            break;
                        default:
                            Console.WriteLine("Була введена недійсна команда");
                            Log.Write($"Wrong command {command}");
                            break;
                    }
                    break;
                case 4:
                    switch (commandWords[0])
                    {
                        case "goto":
                            //
                            Log.Write($"Use command goto");
                            TryCommand(commandWords, group.GetNewWay);
                            break;
                        case "spawn":
                            //
                            Log.Write("Use command spawn");
                            TryCommand(commandWords, group.SpawnNewUnit);
                            break;
                        case "куди":
                            if (commandWords[1] == "йде" && commandWords[2] == "рос?йський" && commandWords[3] == "корабель?")
                            {
                                Console.WriteLine("Нахуй!");
                                Log.Write("Привітання до російського корабля");
                            }
                            break;
                        default:
                            Console.WriteLine("Була введена недійсна команда");
                            Log.Write($"Wrong command {command}");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Була введена недійсна команда");
                    Log.Write($"Wrong command {command}");
                    break;
            }
        }

        string GetFirstWord(string s)
        {
            string t = "";
            for (int i = 0; i < s.Length && s[i] != ' '; ++i, t += s[i]) ;
            return t;
        }

        void TryCommand (string[] words, OneNumberCommand command)
        {
            try
            {
                int x = int.Parse(words[1]);
                command(x);
            }
            catch
            {
                Console.WriteLine("Була введена недійсна команда");
                Log.Write($"Wrong command" + words[0] + words[1]);
            }
        }

        void TryCommand (string[] words, TwoNumberCommand command)
        {
            try
            {
                int x = int.Parse(words[1]);
                int y = int.Parse(words[2]);
                command(x, y);
            }
            catch
            {
                Console.WriteLine("Була введена недійсна команда");
                Log.Write("Wrong command" + words[0] + words[1] + words[2]);
            }
        }

        void TryCommand (string[] words, ThreeNumberCommand command)
        {
            try
            {
                int x = int.Parse(words[1]);
                int y = int.Parse(words[2]);
                int z = int.Parse(words[3]);
                command(x, y, z);
            }
            catch
            {
                Console.WriteLine("Була введена недійсна команда");
                Log.Write("Wrong command" + words[0] + words[1] + words[2] + words[3]);
            }
        }

        void TryCommand (string[] words, SpawnCommand command)
        {
            try
            {
                int x = int.Parse(words[2]);
                int y = int.Parse(words[3]);
                command(words[1], x, y);
            }
            catch
            {
                Console.WriteLine("Була введена недійсна команда");
                Log.Write("Wrong command" + words[0] + words[1] + words[2] + words[3]);
            }
        }
    }

}
