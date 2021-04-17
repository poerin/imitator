using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace imitator
{
    class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Process[] ProcessList = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (ProcessList.Length > 1)
            {
                Application.Exit();
                return;
            }

            if (args.Length > 0)
            {
                try
                {
                    Program program = new Program();
                    proc += new HookHandlerDelegate(program.HookCallback);
                    using (Process curPro = Process.GetCurrentProcess())
                    using (ProcessModule curMod = curPro.MainModule)
                    {
                        hook = SetWindowsHookExW(13, proc, GetModuleHandle(curMod.ModuleName), 0);
                    }
                    XmlDocument Data = new XmlDocument();
                    Data.Load(args[0]);
                    program.ActionTree = Data.SelectSingleNode("ActionTree");
                    program.thread = new Thread(new ThreadStart(program.Act));
                    program.thread.Start();
                    Application.Run();
                }
                catch
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                imitator i = new imitator();
                Application.Run(i);
            }

        }


        #region 按键拦截
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookExW(int idHook, HookHandlerDelegate lpfn, IntPtr hmod, uint dwThreadID);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(IntPtr idHook);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(String modulename);
        public delegate int HookHandlerDelegate(int nCode, IntPtr wparam, IntPtr lparam);
        internal static HookHandlerDelegate proc;
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        #endregion


        XmlNode ActionTree;
        Thread thread;
        static int exit = 0;
        static IntPtr hook;

        private void Act()
        {
            imitator.mouseStartingPosition = Cursor.Position;
            foreach (XmlElement item in ActionTree.ChildNodes)
            {
                ExecuteAction(item);
            }
            UnhookWindowsHookEx(hook);
            Environment.Exit(0);
        }

        private int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            KeyboardHookStruct keyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

            Keys currentKey = ((Keys)keyboardHookStruct.vkCode);
            if (currentKey == Keys.Escape && (wParam == (IntPtr)256 || wParam == (IntPtr)257 || (wParam == (IntPtr)260) || (wParam == (IntPtr)261)))
            {
                if (exit == 3)
                {
                    Environment.Exit(0);
                }
                if (wParam == (IntPtr)256 || wParam == (IntPtr)260)
                {
                    exit++;
                }
                if (wParam == (IntPtr)257 || wParam == (IntPtr)261)
                {
                    exit = 0;
                }
                return CallNextHookEx(hook, nCode, wParam, lParam);
            }
            return CallNextHookEx(hook, nCode, wParam, lParam);
        }

        private void ExecuteAction(XmlElement xe)
        {
            Thread.Sleep(10);
            switch (xe.GetAttribute("Type"))
            {
                case "Keys":
                    {
                        List<Keys> keys = new List<Keys>();
                        string[] codes = xe.GetAttribute("Value").Split(',');
                        foreach (string key in codes)
                        {
                            keys.Add((Keys)(byte.Parse(key)));
                        }
                        iKeys.PressKey(keys);
                        break;
                    }
                case "Mouse":
                    {
                        int x = 0, y = 0;
                        if (xe.HasAttribute("Position"))
                        {
                            string message = xe.GetAttribute("Position");

                            if (message == "+,+")
                            {
                                x = Cursor.Position.X;
                                y = Cursor.Position.Y;
                            }
                            else if (message == "*,*")
                            {
                                x = imitator.mouseStartingPosition.X;
                                y = imitator.mouseStartingPosition.Y;
                            }
                            else
                            {
                                string[] position = message.Split(',');

                                if (!int.TryParse(position[0], out x))
                                {
                                    x = Cursor.Position.X;
                                }
                                if (!int.TryParse(position[1], out y))
                                {
                                    y = Cursor.Position.Y;
                                }
                            }
                        }
                        switch (xe.GetAttribute("Key"))
                        {
                            case "Move":
                                {
                                    iMouse.MouseCursorAction(iMouse.MouseAction.Move, x, y);
                                    break;
                                }
                            case "LeftDouble":
                                {
                                    iMouse.MouseCursorAction(iMouse.MouseAction.LeftDouble, x, y);
                                    break;
                                }
                            case "RightDouble":
                                {
                                    iMouse.MouseCursorAction(iMouse.MouseAction.RightDouble, x, y);
                                    break;
                                }
                            case "Left":
                                {
                                    iMouse.MouseCursorAction(iMouse.MouseAction.Left, x, y);
                                    break;
                                }
                            case "Right":
                                {
                                    iMouse.MouseCursorAction(iMouse.MouseAction.Right, x, y);
                                    break;
                                }
                            case "Middle":
                                {
                                    iMouse.MouseCursorAction(iMouse.MouseAction.Middle, x, y);
                                    break;
                                }
                            case "WheelUp":
                                {
                                    iMouse.MouseWheelAction(iMouse.MouseAction.WheelUp);
                                    break;
                                }
                            case "WheelDown":
                                {
                                    iMouse.MouseWheelAction(iMouse.MouseAction.WheelDown);
                                    break;
                                }
                        }
                        break;
                    }
                case "Time":
                    {
                        Thread.Sleep(int.Parse(xe.GetAttribute("Value")));
                        break;
                    }
                case "Loop":
                    {
                        for (int i = 0; i < int.Parse(xe.GetAttribute("Times")); i++)
                        {
                            foreach (XmlElement item in xe.ChildNodes)
                            {
                                ExecuteAction(item);
                            }
                        }
                        break;
                    }
            }
        }

    }
}