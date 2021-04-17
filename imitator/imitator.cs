using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace imitator
{
    sealed public partial class imitator : Form
    {
        enum MousePositionState
        {
            Absolute = 0,
            Current = 1,
            Starting = 2
        }

        List<Keys> currentKeys = new List<Keys>();
        List<int> currentKeyCodes = new List<int>();
        bool finish = false;
        int controlTime = 0;
        int exit = 0;
        Size FormSize;
        FormWindowState FormState;
        MousePositionState mousePositionState;
        static internal Point mouseStartingPosition;
        static private XmlDocument Data = new XmlDocument();
        static private XmlNode ActionTree;
        bool Running = false;
        Thread thread;
        IntPtr hook;

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
        public struct KeyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        #endregion

        #region 鼠标穿透
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
        const int GWL_EXSTYLE = -20;
        const int WS_EX_TRANSPARENT = 0x20;
        const int WS_EX_LAYERED = 0x80000;
        #endregion


        public imitator()
        {
            InitializeComponent();
            proc += new HookHandlerDelegate(HookCallback);
            using (Process curPro = Process.GetCurrentProcess())
            using (ProcessModule curMod = curPro.MainModule)
            {
                hook = SetWindowsHookExW(13, proc, GetModuleHandle(curMod.ModuleName), 0);
            }
            mousePositionState = MousePositionState.Absolute;
            lblPosition.Text = "绝对位置";
            dudInsert.SelectedIndex = 1;
            ActionTree = Data.CreateNode(XmlNodeType.Element, "ActionTree", "");
            Data.AppendChild(ActionTree);
            tree.DragEnter += tree_DragEnter;
            tree.DragDrop += tree_DragDrop;
        }


        private string RenameKey(string name)
        {
            if (name.Contains("Control"))
            {
                name = "Ctrl";
            }
            else if (name.Contains("Shift"))
            {
                name = "Shift";
            }
            else if (name.Contains("Menu"))
            {
                name = "Alt";
            }
            else if (name.Contains("Win"))
            {
                name = "Win";
            }
            return name;
        }

        internal void ExitTheard()
        {
            Running = false;
            this.WindowState = FormState;
            pnlBackGround.Size = new Size(this.Width - 260, this.Height);
            SetWindowLong(this.Handle, GWL_EXSTYLE, 0);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimumSize = new Size(640, 490);
            this.Size = FormSize;
            pnlControl.Visible = true;
            pnlLoop.Visible = true;
            pnlTime.Visible = true;
            pnlMouse.Visible = true;
            pnlKeys.Visible = true;
            this.TopMost = false;
            this.Opacity = 1;
            this.Focus();
            thread.Abort();
        }

        private int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            KeyboardHookStruct keyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

            Keys currentKey = ((Keys)keyboardHookStruct.vkCode);
            if ((currentKey == Keys.ControlKey) || currentKey == Keys.LControlKey || currentKey == Keys.RControlKey)
            {
                if (mousePositionState == MousePositionState.Absolute)
                {
                    lblPosition.Text = (Cursor.Position.X + "," + Cursor.Position.Y);
                }
                if (wParam == (IntPtr)256 || (wParam == (IntPtr)260))
                {
                    controlTime = keyboardHookStruct.time;
                }
            }
            if (txtKeys.Focused && nCode >= 0 && (wParam == (IntPtr)256 || wParam == (IntPtr)257 || (wParam == (IntPtr)260) || (wParam == (IntPtr)261)))
            {
                if (currentKeyCodes.Count == 0)
                {
                    finish = false;
                    currentKeys.Clear();
                }
                if (((wParam == (IntPtr)256) || (wParam == (IntPtr)260)) && !currentKeyCodes.Contains(keyboardHookStruct.vkCode) && finish == false)
                {
                    if (currentKeyCodes.Count == 0)
                    {
                        txtKeys.Text = RenameKey(currentKey.ToString());
                    }
                    else
                    {
                        txtKeys.Text += " + " + RenameKey(currentKey.ToString());
                    }
                    txtKeys.SelectionStart = txtKeys.TextLength;
                    currentKeyCodes.Add(keyboardHookStruct.vkCode);
                    currentKeys.Add(currentKey);
                }
                else if ((wParam == (IntPtr)257 || (wParam == (IntPtr)261)) && currentKeyCodes.Contains(keyboardHookStruct.vkCode))
                {
                    finish = true;
                    currentKeyCodes.Remove(keyboardHookStruct.vkCode);
                }
                return 1;
            }
            if (currentKey == Keys.Enter && (wParam == (IntPtr)256 || (wParam == (IntPtr)260)) && controlTime + 200 > keyboardHookStruct.time && controlTime + 40 < keyboardHookStruct.time)
            {
                controlTime = 0;
                if (Running == false)
                {
                    if (this.ContainsFocus)
                    {
                        Running = true;
                        pnlKeys.Visible = false;
                        pnlMouse.Visible = false;
                        pnlTime.Visible = false;
                        pnlLoop.Visible = false;
                        pnlControl.Visible = false;
                        FormSize = this.Size;
                        FormState = this.WindowState;
                        this.WindowState = FormWindowState.Maximized;
                        this.MinimumSize = new Size(0, 0);
                        this.FormBorderStyle = FormBorderStyle.None;
                        pnlBackGround.Size = new Size(this.Width - 18, this.Height - 34);
                        this.Opacity = 0.75;
                        this.TopMost = true;
                        SetWindowLong(this.Handle, GWL_EXSTYLE, GetWindowLong(this.Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED);
                        pnlBackGround.Focus();
                        Thread.Sleep(200);
                        thread = new Thread(new ThreadStart(Act));
                        thread.Start();
                    }
                }
                return 1;
            }
            if (currentKey == Keys.Escape && (wParam == (IntPtr)256 || wParam == (IntPtr)257 || (wParam == (IntPtr)260) || (wParam == (IntPtr)261)))
            {
                if (Running == true)
                {
                    if (exit == 8)
                    {
                        exit = 0;
                        ExitTheard();
                    }
                    if (wParam == (IntPtr)256 || wParam == (IntPtr)260)
                    {
                        exit++;
                    }
                    if (wParam == (IntPtr)257 || wParam == (IntPtr)261)
                    {
                        exit = 0;
                    }
                }
                if (this.ContainsFocus && pnlBackGround.Focused != true)
                {
                    return 1;
                }
                return CallNextHookEx(hook, nCode, wParam, lParam);
            }
            return CallNextHookEx(hook, nCode, wParam, lParam);
        }

        private void Act()
        {
            mouseStartingPosition = Cursor.Position;
            foreach (XmlElement item in ActionTree.ChildNodes)
            {
                ExecuteAction(item);
            }
            this.Invoke(new Action(ExitTheard));
        }

        private void RefreshTree(XmlElement xe, TreeNodeCollection trees)
        {
            for (int i = 0; i < trees.Count; i++)
            {
                if (trees[i].Nodes.Count != 0)
                {
                    RefreshTree(xe, trees[i].Nodes);
                }
                if (trees[i].Tag == xe)
                {
                    tree.SelectedNode = trees[i];
                }
            }
        }

        private void FillTree(XmlElement XE)
        {
            XmlElement xe = (XmlElement)XE.CloneNode(false);
            switch (xe.GetAttribute("Type"))
            {
                case "Keys":
                    {
                        string keys = "";
                        string[] codes = xe.GetAttribute("Value").Split(',');
                        foreach (string key in codes)
                        {
                            keys += (RenameKey(((Keys)(byte.Parse(key))).ToString()) + " + ");
                        }
                        keys = keys.Remove(keys.Length - 3);
                        InsertLeaf("键盘：" + keys, xe, false);
                        break;
                    }
                case "Mouse":
                    {
                        string position = xe.GetAttribute("Position");
                        switch (xe.GetAttribute("Key"))
                        {
                            case "Move":
                                {
                                    InsertLeaf("鼠标[移动]：" + GetPositionTitle(position), xe, false);
                                    break;
                                }
                            case "LeftDouble":
                                {
                                    InsertLeaf("鼠标[左键双击]：" + GetPositionTitle(position), xe, false);
                                    break;
                                }
                            case "RightDouble":
                                {
                                    InsertLeaf("鼠标[右键双击]：" + GetPositionTitle(position), xe, false);
                                    break;
                                }
                            case "Left":
                                {
                                    InsertLeaf("鼠标[左键]：" + GetPositionTitle(position), xe, false);
                                    break;
                                }
                            case "Right":
                                {
                                    InsertLeaf("鼠标[右键]：" + GetPositionTitle(position), xe, false);
                                    break;
                                }
                            case "Middle":
                                {
                                    InsertLeaf("鼠标[中键]：" + GetPositionTitle(position), xe, false);
                                    break;
                                }
                            case "WheelUp":
                                {
                                    InsertLeaf("鼠标[滚轮向上]", xe, false);
                                    break;
                                }
                            case "WheelDown":
                                {
                                    InsertLeaf("鼠标[滚轮向下]", xe, false);
                                    break;
                                }
                        }
                        break;
                    }
                case "Time":
                    {
                        InsertLeaf("停顿：" + xe.GetAttribute("Value"), xe, false);
                        break;
                    }
                case "Loop":
                    {
                        TreeNode node = InsertLeaf("循环：" + xe.GetAttribute("Times"), xe, true);
                        if (XE.HasChildNodes)
                        {
                            for (int i = 0; i < XE.ChildNodes.Count; i++)
                            {
                                FillTree((XmlElement)XE.ChildNodes[i]);
                            }
                        }
                        tree.SelectedNode = node;
                        break;
                    }
            }
        }

        private void ExecuteAction(XmlElement xe)
        {
            this.Invoke(new Action<XmlElement, TreeNodeCollection>(RefreshTree), new object[] { xe, tree.Nodes });
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
                                x = mouseStartingPosition.X;
                                y = mouseStartingPosition.Y;
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

        private XmlNode FindSelecteAction(ref bool isTree)
        {
            XmlNode xe = ActionTree;
            TreeNode node = tree.SelectedNode;
            List<int> hint = new List<int>();
            while (true)
            {
                if (node.Text == "空白")
                {
                    hint.Add(-1);
                }
                else
                {
                    hint.Add(node.Index);
                }
                if (node.Level != 0)
                {
                    node = node.Parent;
                }
                else
                {
                    break;
                }
            }
            for (int i = hint.Count - 1; i > -1; i--)
            {
                if (hint[i] == -1 && i == 0)
                {
                    isTree = true;
                }
                else
                {
                    xe = xe.ChildNodes.Item(hint[i]);
                }
            }
            return xe;
        }

        private TreeNode InsertLeaf(string message, XmlElement xe, bool root)
        {
            bool isTree = false;
            XmlNode selecteAction = FindSelecteAction(ref isTree);
            if (isTree)
            {
                selecteAction.AppendChild(xe);
            }
            else
            {
                if (dudInsert.SelectedIndex == 0)
                {
                    selecteAction.ParentNode.InsertBefore(xe, selecteAction);
                }
                else
                {
                    selecteAction.ParentNode.InsertAfter(xe, selecteAction);
                }
            }
            TreeNode node;
            TreeNode blank = new TreeNode("空白");
            if (root)
            {
                node = new TreeNode(message, new TreeNode[] { blank });
            }
            else
            {
                node = new TreeNode(message);
            }
            TreeNodeCollection parent = null;
            if (tree.SelectedNode.Level == 0)
            {
                parent = tree.Nodes;
            }
            else
            {
                parent = tree.SelectedNode.Parent.Nodes;
            }
            node.Tag = xe;
            parent.Insert(tree.SelectedNode.Index + dudInsert.SelectedIndex, node);
            if (dudInsert.SelectedIndex == 1 && node.PrevNode.Text == "空白")
            {
                parent.Remove(node.PrevNode);
            }
            else if (dudInsert.SelectedIndex == 0 && node.NextNode.Text == "空白")
            {
                parent.Remove(node.NextNode);
            }
            if (root)
            {
                tree.SelectedNode = blank;
            }
            else
            {
                tree.SelectedNode = node;
            }
            return node;
        }


        private void btnKeys_Click(object sender, EventArgs e)
        {
            if (currentKeys.Count != 0)
            {
                string keys = ((byte)currentKeys[0]).ToString();
                for (int i = 1; i < currentKeys.Count; i++)
                {
                    keys += "," + (byte)currentKeys[i];
                }
                XmlElement xe = Data.CreateElement("Action");
                xe.SetAttribute("Type", "Keys");
                xe.SetAttribute("Value", keys);
                InsertLeaf("键盘：" + txtKeys.Text, xe, false);
                txtKeys.Focus();
            }
        }

        string GetPositionText()
        {
            switch (mousePositionState)
            {
                case MousePositionState.Absolute:
                    return lblPosition.Text;
                case MousePositionState.Current:
                    return "+,+";
                case MousePositionState.Starting:
                    return "*,*";
                default:
                    return lblPosition.Text;
            }
        }

        string GetPositionTitle(string text)
        {
            if (text == "+,+")
            {
                return "当前位置";
            }

            if (text == "*,*")
            {
                return "起始位置";
            }

            return text;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (lblPosition.Text == "绝对位置")
            {
                MessageBox.Show("请按 Ctrl 键后移动鼠标以设置绝对位置。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XmlElement xe = Data.CreateElement("Action");
            xe.SetAttribute("Type", "Mouse");
            xe.SetAttribute("Key", "Move");
            xe.SetAttribute("Position", GetPositionText());
            InsertLeaf("鼠标[移动]：" + GetPositionTitle(GetPositionText()), xe, false);
        }

        private void btnLeftDouble_Click(object sender, EventArgs e)
        {
            if (lblPosition.Text == "绝对位置")
            {
                MessageBox.Show("请按 Ctrl 键后移动鼠标以设置绝对位置。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XmlElement xe = Data.CreateElement("Action");
            xe.SetAttribute("Type", "Mouse");
            xe.SetAttribute("Key", "LeftDouble");
            xe.SetAttribute("Position", GetPositionText());
            InsertLeaf("鼠标[左键双击]：" + GetPositionTitle(GetPositionText()), xe, false);
        }

        private void btnRightDouble_Click(object sender, EventArgs e)
        {
            if (lblPosition.Text == "绝对位置")
            {
                MessageBox.Show("请按 Ctrl 键后移动鼠标以设置绝对位置。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XmlElement xe = Data.CreateElement("Action");
            xe.SetAttribute("Type", "Mouse");
            xe.SetAttribute("Key", "RightDouble");
            xe.SetAttribute("Position", GetPositionText());
            InsertLeaf("鼠标[右键双击]：" + GetPositionTitle(GetPositionText()), xe, false);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (lblPosition.Text == "绝对位置")
            {
                MessageBox.Show("请按 Ctrl 键后移动鼠标以设置绝对位置。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XmlElement xe = Data.CreateElement("Action");
            xe.SetAttribute("Type", "Mouse");
            xe.SetAttribute("Key", "Left");
            xe.SetAttribute("Position", GetPositionText());
            InsertLeaf("鼠标[左键]：" + GetPositionTitle(GetPositionText()), xe, false);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (lblPosition.Text == "绝对位置")
            {
                MessageBox.Show("请按 Ctrl 键后移动鼠标以设置绝对位置。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XmlElement xe = Data.CreateElement("Action");
            xe.SetAttribute("Type", "Mouse");
            xe.SetAttribute("Key", "Right");
            xe.SetAttribute("Position", GetPositionText());
            InsertLeaf("鼠标[右键]：" + GetPositionTitle(GetPositionText()), xe, false);
        }

        private void btnMiddle_Click(object sender, EventArgs e)
        {
            if (lblPosition.Text == "绝对位置")
            {
                MessageBox.Show("请按 Ctrl 键后移动鼠标以设置绝对位置。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XmlElement xe = Data.CreateElement("Action");
            xe.SetAttribute("Type", "Mouse");
            xe.SetAttribute("Key", "Middle");
            xe.SetAttribute("Position", GetPositionText());
            InsertLeaf("鼠标[中键]：" + GetPositionTitle(GetPositionText()), xe, false);
        }

        private void btnWheelUp_Click(object sender, EventArgs e)
        {
            XmlElement xe = Data.CreateElement("Action");
            xe.SetAttribute("Type", "Mouse");
            xe.SetAttribute("Key", "WheelUp");
            InsertLeaf("鼠标[滚轮向上]", xe, false);
        }

        private void btnWheelDown_Click(object sender, EventArgs e)
        {
            XmlElement xe = Data.CreateElement("Action");
            xe.SetAttribute("Type", "Mouse");
            xe.SetAttribute("Key", "WheelDown");
            InsertLeaf("鼠标[滚轮向下]", xe, false);
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            XmlElement xe = Data.CreateElement("Action");
            xe.SetAttribute("Type", "Time");
            xe.SetAttribute("Value", numTime.Value.ToString());
            InsertLeaf("停顿：" + numTime.Value, xe, false);
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            XmlElement xe = Data.CreateElement("Action");
            xe.SetAttribute("Type", "Loop");
            xe.SetAttribute("Times", numLoop.Value.ToString());
            InsertLeaf("循环：" + numLoop.Value, xe, true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode != null)
            {
                bool isTree = false;
                XmlNode selecteAction = FindSelecteAction(ref isTree);
                if (!(isTree == true))
                {
                    selecteAction.ParentNode.RemoveChild(selecteAction);
                }
                TreeNodeCollection parent = null;
                if (tree.SelectedNode.Level == 0)
                {
                    parent = tree.Nodes;
                }
                else
                {
                    parent = tree.SelectedNode.Parent.Nodes;
                }
                parent.Remove(tree.SelectedNode);
                if (parent.Count == 0)
                {
                    TreeNode blank = new TreeNode("空白");
                    parent.Add(blank);
                    tree.SelectedNode = blank;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ActionTree.RemoveAll();
            tree.Nodes.Clear();
            TreeNode blank = new TreeNode("空白");
            tree.Nodes.Add(blank);
            tree.SelectedNode = blank;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "模仿者文件(*.ido)|*.ido|可扩展标记文件(*.xml)|*.xml";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Data.Save(saveFile.FileName);
            }
        }

        private void tree_DragEnter(object sender, DragEventArgs e)
        {
            string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            FileInfo file = new FileInfo(path);
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && (file.Extension == ".xml" || file.Extension.ToLower() == ".ido"))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tree_DragDrop(object sender, DragEventArgs e)
        {
            dudInsert.SelectedIndex = 1;
            ActionTree.RemoveAll();
            tree.Nodes.Clear();
            TreeNode blank = new TreeNode("空白");
            tree.Nodes.Add(blank);
            tree.SelectedNode = blank;
            try
            {
                Data.Load(((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString());
                XmlNode node = Data.SelectSingleNode("ActionTree");
                if (node.HasChildNodes)
                {
                    for (int i = 0; i < node.ChildNodes.Count; i++)
                    {
                        FillTree((XmlElement)node.ChildNodes[i]);
                    }
                }
                Data.ReplaceChild(ActionTree, node);
            }
            catch
            {
                ActionTree.RemoveAll();
                Data.RemoveAll();
                Data.AppendChild(ActionTree);
                tree.Nodes.Clear();
                tree.Nodes.Add(blank);
                tree.SelectedNode = blank;
            }
        }

        private void lblPosition_Click(object sender, EventArgs e)
        {
            switch (mousePositionState)
            {
                case MousePositionState.Absolute:
                    mousePositionState = MousePositionState.Current;
                    lblPosition.Text = "当前位置";
                    break;
                case MousePositionState.Current:
                    mousePositionState = MousePositionState.Starting;
                    lblPosition.Text = "起始位置";
                    break;
                case MousePositionState.Starting:
                    mousePositionState = MousePositionState.Absolute;
                    lblPosition.Text = "绝对位置";
                    break;
            }
        }

        private void imitator_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnhookWindowsHookEx(hook);
        }

    }
}