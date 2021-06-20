using System;
using System.Runtime.InteropServices;


namespace Ikst.GlobalHotkey
{
    internal class NativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern int RegisterHotKey(IntPtr hWnd, int id, int modKey, int vKey);

        [DllImport("user32.dll")]
        internal static extern int UnregisterHotKey(IntPtr hWnd, int id);
    }
}
