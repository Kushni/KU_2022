using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class Log
    {

        //static string path = @"C:\Users\prost\OneDrive\Документи\GitHub\KU_2022\Курсовая_Кушниренко621п_Дмитриев622п\Курсовая_Кушниренко621п_Дмитриев622п\bin\Debug\net5.0\Log.txt";
        //Path.GetFullPath(@"Log.txt");
        //static StreamWriter streamWriter = new StreamWriter(path);

        static internal bool debugMode = false; 

        static public void Write(string text)
        {
            string path = "Log.txt";
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(text);
            }

            if (debugMode) Console.WriteLine(text);
            //streamWriter.Write(text);
        }

        static internal void Clear()
        {
            string path = "Log.txt";
            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                streamWriter.Write("");
            }
        }
    }
}
