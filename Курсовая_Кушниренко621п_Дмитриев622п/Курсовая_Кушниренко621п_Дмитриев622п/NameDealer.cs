using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    class NameDealer
    {
        
        static internal string GetName()
        {
            Random random = new Random();
            string s = "";
            string path = "Names.txt";
            using (StreamReader streamReader = new StreamReader(path)) {
                int n = random.Next(15);
                ++n;
                for (int i = 0; i < n; ++i)
                {
                    s = streamReader.ReadLine();
                }
            }
            return s;
            
        }
    }
}
