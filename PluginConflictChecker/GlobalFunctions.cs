using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginConflictChecker
{
    public static class GF
    {
        public static void WriteLine(string line)
        {
            Console.WriteLine(line);
            if (DevWriteBool)
            {
                using (StreamWriter stream = File.AppendText("DevWrite.txt"))
                {
                    stream.WriteLine(line);
                }
            }
        }

        public static bool DevWriteBool = false;
        public static void DevWrite(string line)
        {
            if (DevWriteBool)
            {
                //Console.WriteLine(line);
                using (StreamWriter stream = File.AppendText("DevWrite.txt"))
                {
                    stream.WriteLine(line);
                }
            }
        }

        public static void EndProgram()
        {
            Console.WriteLine("Press Enter to Close...");
            Console.ReadLine();
        }
    }
}
