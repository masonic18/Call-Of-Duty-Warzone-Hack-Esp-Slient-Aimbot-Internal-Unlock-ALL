using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoDExtHack.Memory_and_Array
{
    class Utilities
    {
        public static Rectangle GetTrueClientRect(IntPtr hwnd)
        {
            Calling_Native_Methods.NativeMethods.RECT wndRect, clientRect;
            Calling_Native_Methods.NativeMethods.GetClientRect(hwnd, out wndRect);
            Calling_Native_Methods.NativeMethods.GetClientRect(hwnd, out clientRect);

            int wndWidth = wndRect.right - wndRect.left;
            int wndHeight = wndRect.bottom - wndRect.top;
            int clientWidth = clientRect.right - clientRect.left;
            int clientHeight = clientRect.bottom - clientRect.top;

            int chromeWidth = (wndWidth - clientWidth) / 2;
            return new Rectangle(wndRect.left + chromeWidth, wndRect.top + wndHeight - clientHeight - chromeWidth, clientWidth, clientHeight);
        }
    }
}
