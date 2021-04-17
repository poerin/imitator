using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace imitator
{
    static class iMouse
    {
        [DllImport("user32.dll", EntryPoint = "mouse_event")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(int index);

        [Flags]
        internal enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }

        internal enum MouseAction
        {
            Move,
            LeftDouble,
            RightDouble,
            Left,
            Right,
            Middle,
            WheelUp,
            WheelDown
        }

        static internal void MouseCursorAction(MouseAction action, int x, int y)
        {
            Point point = Cursor.Position;
            switch (action)
            {
                case MouseAction.Move:
                    mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, x * 65536 / Screen.PrimaryScreen.Bounds.Width, y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, UIntPtr.Zero);
                    break;
                case MouseAction.LeftDouble:
                case MouseAction.RightDouble:
                    {
                        if (action == MouseAction.LeftDouble && GetSystemMetrics(23) == 0 || action == MouseAction.RightDouble && GetSystemMetrics(23) == 1)
                        {
                            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute | MouseEventFlag.LeftDown | MouseEventFlag.LeftUp, x * 65536 / Screen.PrimaryScreen.Bounds.Width, y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, UIntPtr.Zero);
                            mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
                            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, point.X * 65536 / Screen.PrimaryScreen.Bounds.Width, point.Y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, UIntPtr.Zero);
                        }
                        else
                        {
                            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute | MouseEventFlag.RightDown | MouseEventFlag.RightUp, x * 65536 / Screen.PrimaryScreen.Bounds.Width, y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, UIntPtr.Zero);
                            mouse_event(MouseEventFlag.RightDown | MouseEventFlag.RightUp, 0, 0, 0, UIntPtr.Zero);
                            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, point.X * 65536 / Screen.PrimaryScreen.Bounds.Width, point.Y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, UIntPtr.Zero);
                        }
                        break;
                    }
                case MouseAction.Left:
                case MouseAction.Right:
                    {
                        if (action == MouseAction.Left && GetSystemMetrics(23) == 0 || action == MouseAction.Right && GetSystemMetrics(23) == 1)
                        {
                            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute | MouseEventFlag.LeftDown | MouseEventFlag.LeftUp, x * 65536 / Screen.PrimaryScreen.Bounds.Width, y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, UIntPtr.Zero);
                            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, point.X * 65536 / Screen.PrimaryScreen.Bounds.Width, point.Y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, UIntPtr.Zero);
                        }
                        else
                        {
                            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute | MouseEventFlag.RightDown | MouseEventFlag.RightUp, x * 65536 / Screen.PrimaryScreen.Bounds.Width, y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, UIntPtr.Zero);
                            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, point.X * 65536 / Screen.PrimaryScreen.Bounds.Width, point.Y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, UIntPtr.Zero);
                        }
                        break;
                    }
                case MouseAction.Middle:
                    mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute | MouseEventFlag.MiddleDown | MouseEventFlag.MiddleUp, x * 65536 / Screen.PrimaryScreen.Bounds.Width, y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, UIntPtr.Zero);
                    mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, point.X * 65536 / Screen.PrimaryScreen.Bounds.Width, point.Y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, UIntPtr.Zero);
                    break;
            }
        }

        static internal void MouseWheelAction(MouseAction action)
        {
            switch (action)
            {
                case MouseAction.WheelUp:
                    mouse_event(MouseEventFlag.Wheel, 0, 0, 120, UIntPtr.Zero);
                    break;
                case MouseAction.WheelDown:
                    mouse_event(MouseEventFlag.Wheel, 0, 0, 4294967175, UIntPtr.Zero);
                    break;
            }
        }

    }
}