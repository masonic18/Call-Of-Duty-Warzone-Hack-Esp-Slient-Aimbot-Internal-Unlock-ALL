using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


// Changed the console folder to ConsoleMethods\ so we know where stuff are.
namespace CoDExtHack.ConsoleMethods
{
    // I also switched ConsoleDo to setConsole because it more professional
    // and wrote 2 write function ( writeline and write ) because both method are different. 
    class setConsole
    {
        
        public static void WriteLine(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("[ " + DateTime.Now + "] - " + message);
            Console.ResetColor();
        }
        public static void Write(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
