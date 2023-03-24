using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace ConsoleUI
{
    internal class ConsoleUtils
    {
        public static void WaitForKey()
        {
     
            WriteLine("\n(Press any key to continue...)");
            ReadKey(true);
        }

        public static void QuitApplication()
        {

            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }
    }
}
