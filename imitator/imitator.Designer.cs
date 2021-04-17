namespace imitator
{
    partial class imitator
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("空白");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(imitator));
            this.tree = new System.Windows.Forms.TreeView();
            this.pnlKeys = new System.Windows.Forms.Panel();
            this.btnKeys = new System.Windows.Forms.Button();
            this.txtKeys = new System.Windows.Forms.TextBox();
            this.pnlMouse = new System.Windows.Forms.Panel();
            this.btnRightDouble = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnWheelDown = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnLeftDouble = new System.Windows.Forms.Button();
            this.btnWheelUp = new System.Windows.Forms.Button();
            this.btnMiddle = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.pnlTime = new System.Windows.Forms.Panel();
            this.lblMillisecond = new System.Windows.Forms.Label();
            this.lblPause = new System.Windows.Forms.Label();
            this.btnTime = new System.Windows.Forms.Button();
            this.numTime = new System.Windows.Forms.NumericUpDown();
            this.pnlLoop = new System.Windows.Forms.Panel();
            this.lblLoop = new System.Windows.Forms.Label();
            this.lblTimes = new System.Windows.Forms.Label();
            this.btnLoop = new System.Windows.Forms.Button();
            this.numLoop = new System.Windows.Forms.NumericUpDown();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblInsert = new System.Windows.Forms.Label();
            this.dudInsert = new System.Windows.Forms.DomainUpDown();
            this.pnlBackGround = new System.Windows.Forms.Panel();
            this.pnlKeys.SuspendLayout();
            this.pnlMouse.SuspendLayout();
            this.pnlTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            this.pnlLoop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLoop)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.pnlBackGround.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.AllowDrop = true;
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.tree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tree.FullRowSelect = true;
            this.tree.HideSelection = false;
            this.tree.Indent = 24;
            this.tree.Location = new System.Drawing.Point(12, 12);
            this.tree.Name = "tree";
            treeNode1.Name = "blank";
            treeNode1.Text = "空白";
            this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tree.ShowLines = false;
            this.tree.ShowPlusMinus = false;
            this.tree.ShowRootLines = false;
            this.tree.Size = new System.Drawing.Size(340, 424);
            this.tree.TabIndex = 0;
            // 
            // pnlKeys
            // 
            this.pnlKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlKeys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(245)))));
            this.pnlKeys.Controls.Add(this.btnKeys);
            this.pnlKeys.Controls.Add(this.txtKeys);
            this.pnlKeys.Location = new System.Drawing.Point(371, 12);
            this.pnlKeys.Name = "pnlKeys";
            this.pnlKeys.Size = new System.Drawing.Size(254, 60);
            this.pnlKeys.TabIndex = 1;
            // 
            // btnKeys
            // 
            this.btnKeys.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnKeys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnKeys.Location = new System.Drawing.Point(187, 14);
            this.btnKeys.Name = "btnKeys";
            this.btnKeys.Size = new System.Drawing.Size(45, 33);
            this.btnKeys.TabIndex = 1;
            this.btnKeys.TabStop = false;
            this.btnKeys.Text = "记录";
            this.btnKeys.UseMnemonic = false;
            this.btnKeys.UseVisualStyleBackColor = true;
            this.btnKeys.Click += new System.EventHandler(this.btnKeys_Click);
            // 
            // txtKeys
            // 
            this.txtKeys.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtKeys.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtKeys.Location = new System.Drawing.Point(23, 19);
            this.txtKeys.Name = "txtKeys";
            this.txtKeys.ReadOnly = true;
            this.txtKeys.Size = new System.Drawing.Size(156, 23);
            this.txtKeys.TabIndex = 0;
            this.txtKeys.TabStop = false;
            // 
            // pnlMouse
            // 
            this.pnlMouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.pnlMouse.Controls.Add(this.btnRightDouble);
            this.pnlMouse.Controls.Add(this.lblPosition);
            this.pnlMouse.Controls.Add(this.btnWheelDown);
            this.pnlMouse.Controls.Add(this.btnMove);
            this.pnlMouse.Controls.Add(this.btnLeftDouble);
            this.pnlMouse.Controls.Add(this.btnWheelUp);
            this.pnlMouse.Controls.Add(this.btnMiddle);
            this.pnlMouse.Controls.Add(this.btnRight);
            this.pnlMouse.Controls.Add(this.btnLeft);
            this.pnlMouse.Location = new System.Drawing.Point(371, 78);
            this.pnlMouse.Name = "pnlMouse";
            this.pnlMouse.Size = new System.Drawing.Size(254, 143);
            this.pnlMouse.TabIndex = 2;
            // 
            // btnRightDouble
            // 
            this.btnRightDouble.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRightDouble.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnRightDouble.Location = new System.Drawing.Point(68, 49);
            this.btnRightDouble.Name = "btnRightDouble";
            this.btnRightDouble.Size = new System.Drawing.Size(33, 45);
            this.btnRightDouble.TabIndex = 3;
            this.btnRightDouble.TabStop = false;
            this.btnRightDouble.Text = "右双";
            this.btnRightDouble.UseMnemonic = false;
            this.btnRightDouble.UseVisualStyleBackColor = true;
            this.btnRightDouble.Click += new System.EventHandler(this.btnRightDouble_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.BackColor = System.Drawing.Color.Black;
            this.lblPosition.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPosition.ForeColor = System.Drawing.Color.Ivory;
            this.lblPosition.Location = new System.Drawing.Point(20, 103);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(0, 26);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Click += new System.EventHandler(this.lblPosition_Click);
            // 
            // btnWheelDown
            // 
            this.btnWheelDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWheelDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnWheelDown.Location = new System.Drawing.Point(145, 100);
            this.btnWheelDown.Name = "btnWheelDown";
            this.btnWheelDown.Size = new System.Drawing.Size(70, 33);
            this.btnWheelDown.TabIndex = 8;
            this.btnWheelDown.TabStop = false;
            this.btnWheelDown.Text = "滚轮向下";
            this.btnWheelDown.UseMnemonic = false;
            this.btnWheelDown.UseVisualStyleBackColor = true;
            this.btnWheelDown.Click += new System.EventHandler(this.btnWheelDown_Click);
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnMove.Location = new System.Drawing.Point(31, 10);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(70, 33);
            this.btnMove.TabIndex = 1;
            this.btnMove.TabStop = false;
            this.btnMove.Text = "移动";
            this.btnMove.UseMnemonic = false;
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnLeftDouble
            // 
            this.btnLeftDouble.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeftDouble.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnLeftDouble.Location = new System.Drawing.Point(31, 49);
            this.btnLeftDouble.Name = "btnLeftDouble";
            this.btnLeftDouble.Size = new System.Drawing.Size(33, 45);
            this.btnLeftDouble.TabIndex = 2;
            this.btnLeftDouble.TabStop = false;
            this.btnLeftDouble.Text = "左双";
            this.btnLeftDouble.UseMnemonic = false;
            this.btnLeftDouble.UseVisualStyleBackColor = true;
            this.btnLeftDouble.Click += new System.EventHandler(this.btnLeftDouble_Click);
            // 
            // btnWheelUp
            // 
            this.btnWheelUp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWheelUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnWheelUp.Location = new System.Drawing.Point(145, 10);
            this.btnWheelUp.Name = "btnWheelUp";
            this.btnWheelUp.Size = new System.Drawing.Size(70, 33);
            this.btnWheelUp.TabIndex = 7;
            this.btnWheelUp.TabStop = false;
            this.btnWheelUp.Text = "滚轮向上";
            this.btnWheelUp.UseMnemonic = false;
            this.btnWheelUp.UseVisualStyleBackColor = true;
            this.btnWheelUp.Click += new System.EventHandler(this.btnWheelUp_Click);
            // 
            // btnMiddle
            // 
            this.btnMiddle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMiddle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnMiddle.Location = new System.Drawing.Point(164, 49);
            this.btnMiddle.Name = "btnMiddle";
            this.btnMiddle.Size = new System.Drawing.Size(33, 45);
            this.btnMiddle.TabIndex = 5;
            this.btnMiddle.TabStop = false;
            this.btnMiddle.Text = "中键";
            this.btnMiddle.UseMnemonic = false;
            this.btnMiddle.UseVisualStyleBackColor = true;
            this.btnMiddle.Click += new System.EventHandler(this.btnMiddle_Click);
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnRight.Location = new System.Drawing.Point(201, 49);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(33, 45);
            this.btnRight.TabIndex = 6;
            this.btnRight.TabStop = false;
            this.btnRight.Text = "右键";
            this.btnRight.UseMnemonic = false;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnLeft.Location = new System.Drawing.Point(127, 49);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(33, 45);
            this.btnLeft.TabIndex = 4;
            this.btnLeft.TabStop = false;
            this.btnLeft.Text = "左键";
            this.btnLeft.UseMnemonic = false;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // pnlTime
            // 
            this.pnlTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(49)))));
            this.pnlTime.Controls.Add(this.lblMillisecond);
            this.pnlTime.Controls.Add(this.lblPause);
            this.pnlTime.Controls.Add(this.btnTime);
            this.pnlTime.Controls.Add(this.numTime);
            this.pnlTime.Location = new System.Drawing.Point(371, 227);
            this.pnlTime.Name = "pnlTime";
            this.pnlTime.Size = new System.Drawing.Size(254, 60);
            this.pnlTime.TabIndex = 3;
            // 
            // lblMillisecond
            // 
            this.lblMillisecond.AutoSize = true;
            this.lblMillisecond.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblMillisecond.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.lblMillisecond.Location = new System.Drawing.Point(145, 22);
            this.lblMillisecond.Name = "lblMillisecond";
            this.lblMillisecond.Size = new System.Drawing.Size(32, 17);
            this.lblMillisecond.TabIndex = 2;
            this.lblMillisecond.Text = "毫秒";
            // 
            // lblPause
            // 
            this.lblPause.AutoSize = true;
            this.lblPause.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.lblPause.Location = new System.Drawing.Point(23, 22);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(32, 17);
            this.lblPause.TabIndex = 0;
            this.lblPause.Text = "停顿";
            // 
            // btnTime
            // 
            this.btnTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnTime.Location = new System.Drawing.Point(187, 14);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(45, 33);
            this.btnTime.TabIndex = 3;
            this.btnTime.TabStop = false;
            this.btnTime.Text = "记录";
            this.btnTime.UseMnemonic = false;
            this.btnTime.UseVisualStyleBackColor = true;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // numTime
            // 
            this.numTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.numTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTime.Location = new System.Drawing.Point(61, 19);
            this.numTime.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTime.Name = "numTime";
            this.numTime.Size = new System.Drawing.Size(78, 23);
            this.numTime.TabIndex = 1;
            this.numTime.TabStop = false;
            this.numTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTime.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // pnlLoop
            // 
            this.pnlLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLoop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(245)))), ((int)(((byte)(49)))));
            this.pnlLoop.Controls.Add(this.lblLoop);
            this.pnlLoop.Controls.Add(this.lblTimes);
            this.pnlLoop.Controls.Add(this.btnLoop);
            this.pnlLoop.Controls.Add(this.numLoop);
            this.pnlLoop.Location = new System.Drawing.Point(371, 293);
            this.pnlLoop.Name = "pnlLoop";
            this.pnlLoop.Size = new System.Drawing.Size(254, 70);
            this.pnlLoop.TabIndex = 4;
            // 
            // lblLoop
            // 
            this.lblLoop.AutoSize = true;
            this.lblLoop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.lblLoop.Location = new System.Drawing.Point(23, 25);
            this.lblLoop.Name = "lblLoop";
            this.lblLoop.Size = new System.Drawing.Size(37, 20);
            this.lblLoop.TabIndex = 0;
            this.lblLoop.Text = "循环";
            // 
            // lblTimes
            // 
            this.lblTimes.AutoSize = true;
            this.lblTimes.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.lblTimes.Location = new System.Drawing.Point(156, 25);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(23, 20);
            this.lblTimes.TabIndex = 2;
            this.lblTimes.Text = "次";
            // 
            // btnLoop
            // 
            this.btnLoop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnLoop.Location = new System.Drawing.Point(187, 19);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(45, 33);
            this.btnLoop.TabIndex = 3;
            this.btnLoop.TabStop = false;
            this.btnLoop.Text = "记录";
            this.btnLoop.UseMnemonic = false;
            this.btnLoop.UseVisualStyleBackColor = true;
            this.btnLoop.Click += new System.EventHandler(this.btnLoop_Click);
            // 
            // numLoop
            // 
            this.numLoop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numLoop.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numLoop.Location = new System.Drawing.Point(69, 19);
            this.numLoop.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numLoop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLoop.Name = "numLoop";
            this.numLoop.Size = new System.Drawing.Size(78, 33);
            this.numLoop.TabIndex = 1;
            this.numLoop.TabStop = false;
            this.numLoop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLoop.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlControl.Controls.Add(this.btnSave);
            this.pnlControl.Controls.Add(this.btnClear);
            this.pnlControl.Controls.Add(this.btnDelete);
            this.pnlControl.Controls.Add(this.lblInsert);
            this.pnlControl.Controls.Add(this.dudInsert);
            this.pnlControl.Location = new System.Drawing.Point(371, 369);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(254, 67);
            this.pnlControl.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnSave.Location = new System.Drawing.Point(197, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(45, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "保存";
            this.btnSave.UseMnemonic = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnClear.Location = new System.Drawing.Point(149, 17);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(45, 33);
            this.btnClear.TabIndex = 3;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "清空";
            this.btnClear.UseMnemonic = false;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnDelete.Location = new System.Drawing.Point(101, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(45, 33);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseMnemonic = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblInsert
            // 
            this.lblInsert.AutoSize = true;
            this.lblInsert.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblInsert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.lblInsert.Location = new System.Drawing.Point(66, 25);
            this.lblInsert.Name = "lblInsert";
            this.lblInsert.Size = new System.Drawing.Size(32, 17);
            this.lblInsert.TabIndex = 1;
            this.lblInsert.Text = "插入";
            // 
            // dudInsert
            // 
            this.dudInsert.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dudInsert.Items.Add("向上");
            this.dudInsert.Items.Add("向下");
            this.dudInsert.Location = new System.Drawing.Point(15, 22);
            this.dudInsert.Name = "dudInsert";
            this.dudInsert.ReadOnly = true;
            this.dudInsert.Size = new System.Drawing.Size(48, 23);
            this.dudInsert.TabIndex = 0;
            this.dudInsert.TabStop = false;
            this.dudInsert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlBackGround
            // 
            this.pnlBackGround.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBackGround.Controls.Add(this.tree);
            this.pnlBackGround.Location = new System.Drawing.Point(0, 0);
            this.pnlBackGround.Name = "pnlBackGround";
            this.pnlBackGround.Size = new System.Drawing.Size(364, 452);
            this.pnlBackGround.TabIndex = 6;
            // 
            // imitator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.ClientSize = new System.Drawing.Size(630, 460);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlLoop);
            this.Controls.Add(this.pnlTime);
            this.Controls.Add(this.pnlMouse);
            this.Controls.Add(this.pnlKeys);
            this.Controls.Add(this.pnlBackGround);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 490);
            this.Name = "imitator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模仿者";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.imitator_FormClosed);
            this.pnlKeys.ResumeLayout(false);
            this.pnlKeys.PerformLayout();
            this.pnlMouse.ResumeLayout(false);
            this.pnlMouse.PerformLayout();
            this.pnlTime.ResumeLayout(false);
            this.pnlTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).EndInit();
            this.pnlLoop.ResumeLayout(false);
            this.pnlLoop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLoop)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.pnlBackGround.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Panel pnlKeys;
        private System.Windows.Forms.Panel pnlMouse;
        private System.Windows.Forms.Panel pnlTime;
        private System.Windows.Forms.Panel pnlLoop;
        private System.Windows.Forms.TextBox txtKeys;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Button btnWheelDown;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnLeftDouble;
        private System.Windows.Forms.Button btnWheelUp;
        private System.Windows.Forms.Button btnMiddle;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnKeys;
        private System.Windows.Forms.Label lblMillisecond;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.Button btnTime;
        private System.Windows.Forms.NumericUpDown numTime;
        private System.Windows.Forms.Label lblLoop;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.NumericUpDown numLoop;
        private System.Windows.Forms.Button btnRightDouble;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Label lblInsert;
        private System.Windows.Forms.DomainUpDown dudInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlBackGround;


    }
}