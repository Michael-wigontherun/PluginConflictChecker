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
        }

        public static void EndProgram()
        {
            Console.WriteLine("Press Enter to Close...");
            Console.ReadLine();
        }
    }
}
