using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CoDExtHack.Calling_Native_Methods
{
    class NativeMethods
    {
        // Importing "Kernel32.dll" To call AllocConsole();
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        // Importing "Kernels32.dll" to call FreeConsole();
        [DllImport("Kernel32")]
        public static extern void FreeConsole();

        // Importing "user32.dll" to call FindWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        
        // Importing "user32.dll" to call GetWindowThreadProcessID();
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        
        // Importing "kernel32.dll" to call OpenProcess();
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        // Importing "user32.dll" to call GetWindowLong();
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int index);

        // Importing "user32.dll" to call SetWindowLong();
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        // Importing "kernel32.dll" to call ReadProcessMemory();
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, UIntPtr dwSize, out UIntPtr lpNumberOfBytesRead);

        // Importing "user32.dll" to call GetWindowRect();
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        // Importing "user32.dll" to call GetClientRect();
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        // Initializing some memory var;
        public static uint PROCESS_VM_OPERATION = 0x8;
        public static uint PROCESS_VM_READ = 0x10;
        public static uint PROCESS_VM_WRITE = 0x20;
        public static uint PROCESS_ALL_ACCESS = 0x1F0FFF;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_EXSTYLE = -20;
        public static int INVALID_HANDLE_VALUE = -1;
        

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left, top, right, bottom;
        }

        public static void SetWindowTransparent(IntPtr hwnd)
        {
            SetWindowLong(hwnd, GWL_EXSTYLE, GetWindowLong(hwnd, GWL_EXSTYLE) | WS_EX_TRANSPARENT);
        }
    }
}
