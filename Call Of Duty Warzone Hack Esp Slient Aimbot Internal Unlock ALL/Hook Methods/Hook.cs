using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
namespace CoDExtHack.HookMethods
{
    class Hook
    {
        public static IntPtr GameWindowHandle;
        public static IntPtr GameProcessHandle;
        public static void HookWindow()
        {
            // Initialized waittime to 34 so it doesn't "lag".
            int waittime = 34;

            // Writing default Time & Message before enabling the loop because I removed it from the Write function by default. 
            ConsoleMethods.setConsole.Write(ConsoleColor.Yellow, "[ " + DateTime.Now + "] - " + "Waiting for call of duty 4... ");

            // Ok Uh, it a simple FindWindow searching method combined with a console loop. Nothing really complex. 
            while ((HookMethods.Hook.GameWindowHandle = Calling_Native_Methods.NativeMethods.FindWindow(null, "Call of Duty 4")) == IntPtr.Zero)
            {
                // Kinda pointless to comment dis no? 
                ConsoleMethods.setConsole.Write(ConsoleColor.Yellow, "/"); Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); System.Threading.Thread.Sleep(waittime); ConsoleMethods.setConsole.Write(ConsoleColor.Yellow, "-"); Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); System.Threading.Thread.Sleep(waittime); ConsoleMethods.setConsole.Write(ConsoleColor.Yellow, "\\"); Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); System.Threading.Thread.Sleep(waittime); ConsoleMethods.setConsole.Write(ConsoleColor.Yellow, "|"); Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); System.Threading.Thread.Sleep(waittime);
            }
            // The setCursorPosition used for the loop fuck up a bit the line so we created a new black line for an empty space before writing more text. 
            ConsoleMethods.setConsole.WriteLine(ConsoleColor.Black, " ");
            ConsoleMethods.setConsole.WriteLine(ConsoleColor.Green, "\"Call of duty 4\" Window initialized... ");

            // Getting the Process ID from Call of Duty 4 window. 
            int pID;
            Calling_Native_Methods.NativeMethods.GetWindowThreadProcessId(GameWindowHandle, out pID);
           
            // Now we got our Process ID, write it in the logs console.
            if(pID == 0)
                ConsoleMethods.setConsole.WriteLine(ConsoleColor.Red, "Ooops!? Couldn't get the process id! ");
            else
                ConsoleMethods.setConsole.WriteLine(ConsoleColor.Green, "\"Call of duty 4\" Process id: " + pID + "...");

            // Handle the Process and Get Read Permissions.
            GameProcessHandle = Calling_Native_Methods.NativeMethods.OpenProcess(Calling_Native_Methods.NativeMethods.PROCESS_VM_READ, false, pID);

            // Handle the Process and Get Read Permissions.
            if (GameProcessHandle == IntPtr.Zero) {
                ConsoleMethods.setConsole.WriteLine(ConsoleColor.Red, "Ooops!? Couldn't recieve read permission of the process: " + pID + "!");
                ConsoleMethods.setConsole.WriteLine(ConsoleColor.Yellow, "Please, make sure that you aren't running your game in administrator mode...");
            }
            else
                ConsoleMethods.setConsole.WriteLine(ConsoleColor.Green, "\"Call of duty 4\" Read permission: True...");

            WindowInformation();
        }
        // width height x y 
        public static readonly int[] ScreenCenter = new int[2];
        public static readonly int[] WindowPosition = new int[2];
        public static readonly int[] Resolution = new int[2];
        public static void WindowInformation()
        {
            Rectangle trueRect = CoDExtHack.Memory_and_Array.Utilities.GetTrueClientRect(CoDExtHack.HookMethods.Hook.GameWindowHandle);
            ScreenCenter[0] = trueRect.Width / 2; ScreenCenter[1] = trueRect.Height / 2;
            WindowPosition[0] = trueRect.X; WindowPosition[1] = trueRect.Y;
            Resolution[0] = trueRect.Width; Resolution[1] = trueRect.Height;

            string WindowWidth = trueRect.Width.ToString();
            string WindowHeight = trueRect.Height.ToString();
    
            ConsoleMethods.setConsole.WriteLine(ConsoleColor.Green, "\"Call of duty 4\" Window size: " + WindowWidth + " x " + WindowHeight);
        }

        public static void draw()
        {
           // Box1 = new TextBlock { FontSize = 10, Foreground = new SolidColorBrush(System.Drawing.Color.FromArgb(0x7F, 0xFF, 0xFF, 0xFF)) };
        }
    }
}
