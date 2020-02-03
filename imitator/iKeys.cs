using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace imitator
{
    static class iKeys
    {
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(byte vk, byte scan, int flags, int extraInfo);

        static internal void PressKey(List<Keys> keys)
        {
            foreach (Keys key in keys)
            {
                keybd_event((byte)key, 0, 0, 0);
            }
            keys.Reverse();
            foreach (Keys key in keys)
            {
                keybd_event((byte)key, 0, 2, 0);
            }
        }

    }
}