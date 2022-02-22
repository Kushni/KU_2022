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
        ConsoleKeyInfo key;
        delegate void OneNumberCommand(int firstNumber);
        delegate void TwoNumberCommand(int firstNumber, int secondNumber);
        delegate void ThreeNumberCommand(int firstNumber, int secondNumber, int thirdNumber);
        delegate void SpawnCommand(string modelUnit, int firstNumber, int secondNumber);

        public void Read()
        {
            string s = "";
            key = Console.ReadKey(true);
            Program.timer.Change(Timeout.Infinite, Timeout.Infinite);
            s = Console.ReadLine();
        }

        void GetTheCommand(string command)
        {
            command = command.Trim();
            command = command.ToLower();
            string[] commandWords = command.Split(" ");
            switch (commandWords.Length)
            {
                case 1:
                    OneNumberCommand thisCommand;
                    switch (commandWords[0])
                    {
                        case "help":
                            //Вызов команды help
                            break;
                        case "continue":
                            Program.timer.Change(0, 1000);
                            break;
                        case "seemap":
                            //
                            break;
                        case "infoall":
                            //
                            break;
                        default:
                            Console.WriteLine("Була введена недійсна команда");
                            break;
                    }
                    break;
                case 2:
                    switch (commandWords[0])
                    {
                        case "infounit":
                            //
                            break;
                        case "infocell":
                            //
                            break;
                        default:
                            Console.WriteLine("Була введена недійсна команда");
                            break;
                    }
                    break;
                case 3:
                    switch (commandWords[0])
                    {
                        case "goto":
                            //
                            break;
                        case "pack":
                            //
                            break;
                        case "unpack":
                            //
                            break;
                        default:
                            Console.WriteLine("Була введена недійсна команда");
                            break;
                    }
                    break;
                case 4:
                    //
                    break;
                default:
                    Console.WriteLine("Була введена недійсна команда");
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
                int x = int.Parse(words[2]);
                command(x);
            }
            catch
            {
                Console.WriteLine("Була введена недійсна команда");
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
            }
        }

        void TryCommand (string[] words, SpawnCommand command)
        {
            try
            {
                int x = int.Parse(words[2]);
                int y = int.Parse(words[3]);
                command(words[0], x, y);
            }
            catch
            {
                Console.WriteLine("Була введена недійсна команда");
            }
        }
    }

}
