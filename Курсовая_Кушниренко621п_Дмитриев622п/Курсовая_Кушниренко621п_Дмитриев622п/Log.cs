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

        static StreamWriter streamWriter = new StreamWriter(path, false);
        static string path = "Log.txt";

        static void Write(string text)
        {
            streamWriter.WriteLine(text);
        }
    }
}
