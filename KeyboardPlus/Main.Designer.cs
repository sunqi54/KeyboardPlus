namespace KeyboardPlus
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MenuItemNum = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCaps = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDiv1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LabelTitle = new System.Windows.Forms.Label();
            this.LabelSub = new System.Windows.Forms.Label();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuStatus1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStatus2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStatus3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Div1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.CBAuto = new System.Windows.Forms.CheckBox();
            this.CBScroll = new System.Windows.Forms.CheckBox();
            this.CBCaps = new System.Windows.Forms.CheckBox();
            this.CBNum = new System.Windows.Forms.CheckBox();
            this.MenuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuItemNum
            // 
            this.MenuItemNum.Name = "MenuItemNum";
            this.MenuItemNum.Size = new System.Drawing.Size(99, 23);
            this.MenuItemNum.Text = "Number Lock";
            // 
            // MenuItemCaps
            // 
            this.MenuItemCaps.Name = "MenuItemCaps";
            this.MenuItemCaps.Size = new System.Drawing.Size(80, 23);
            this.MenuItemCaps.Text = "Caps Lock";
            // 
            // MenuItemScroll
            // 
            this.MenuItemScroll.Name = "MenuItemScroll";
            this.MenuItemScroll.Size = new System.Drawing.Size(80, 23);
            this.MenuItemScroll.Text = "Scroll lock";
            // 
            // MenuItemDiv1
            // 
            this.MenuItemDiv1.Name = "MenuItemDiv1";
            this.MenuItemDiv1.Size = new System.Drawing.Size(6, 23);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(44, 23);
            this.MenuItemExit.Text = "退出";
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LabelTitle
            // 
            this.LabelTitle.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelTitle.Location = new System.Drawing.Point(0, 20);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(200, 23);
            this.LabelTitle.TabIndex = 1;
            this.LabelTitle.Text = "键盘助手";
            this.LabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelSub
            // 
            this.LabelSub.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelSub.Location = new System.Drawing.Point(0, 52);
            this.LabelSub.Name = "LabelSub";
            this.LabelSub.Size = new System.Drawing.Size(200, 23);
            this.LabelSub.TabIndex = 2;
            this.LabelSub.Text = "正在启动";
            this.LabelSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(110, 118);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(100, 30);
            this.ButtonClose.TabIndex = 3;
            this.ButtonClose.Text = "关闭";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStatus1,
            this.MenuStatus2,
            this.MenuStatus3,
            this.Div1,
            this.MenuSetting,
            this.MenuExit});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(181, 120);
            // 
            // MenuStatus1
            // 
            this.MenuStatus1.Name = "MenuStatus1";
            this.MenuStatus1.Size = new System.Drawing.Size(180, 22);
            this.MenuStatus1.Text = "设置 Number 状态";
            this.MenuStatus1.Click += new System.EventHandler(this.MenuStatus1_Click);
            // 
            // MenuStatus2
            // 
            this.MenuStatus2.Name = "MenuStatus2";
            this.MenuStatus2.Size = new System.Drawing.Size(180, 22);
            this.MenuStatus2.Text = "设置 Caps 状态";
            this.MenuStatus2.Click += new System.EventHandler(this.MenuStatus2_Click);
            // 
            // MenuStatus3
            // 
            this.MenuStatus3.Name = "MenuStatus3";
            this.MenuStatus3.Size = new System.Drawing.Size(180, 22);
            this.MenuStatus3.Text = "设置 Scroll 状态";
            this.MenuStatus3.Click += new System.EventHandler(this.MenuStatus3_Click);
            // 
            // Div1
            // 
            this.Div1.Name = "Div1";
            this.Div1.Size = new System.Drawing.Size(177, 6);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(180, 22);
            this.MenuExit.Text = "退出";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.Controls.Add(this.LabelTitle);
            this.Panel1.Controls.Add(this.LabelSub);
            this.Panel1.Location = new System.Drawing.Point(60, 30);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(200, 100);
            this.Panel1.TabIndex = 5;
            // 
            // Panel2
            // 
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.CBAuto);
            this.Panel2.Controls.Add(this.CBScroll);
            this.Panel2.Controls.Add(this.CBCaps);
            this.Panel2.Controls.Add(this.CBNum);
            this.Panel2.Controls.Add(this.ButtonClose);
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(320, 160);
            this.Panel2.TabIndex = 6;
            // 
            // CBAuto
            // 
            this.CBAuto.AutoSize = true;
            this.CBAuto.Location = new System.Drawing.Point(22, 25);
            this.CBAuto.Name = "CBAuto";
            this.CBAuto.Size = new System.Drawing.Size(84, 16);
            this.CBAuto.TabIndex = 7;
            this.CBAuto.Text = "开机自启动";
            this.CBAuto.UseVisualStyleBackColor = true;
            this.CBAuto.CheckedChanged += new System.EventHandler(this.CBAuto_CheckedChanged);
            // 
            // CBScroll
            // 
            this.CBScroll.AutoSize = true;
            this.CBScroll.Location = new System.Drawing.Point(212, 55);
            this.CBScroll.Name = "CBScroll";
            this.CBScroll.Size = new System.Drawing.Size(90, 16);
            this.CBScroll.TabIndex = 6;
            this.CBScroll.Text = "显示 Scroll";
            this.CBScroll.UseVisualStyleBackColor = true;
            this.CBScroll.CheckedChanged += new System.EventHandler(this.CBScroll_CheckedChanged);
            // 
            // CBCaps
            // 
            this.CBCaps.AutoSize = true;
            this.CBCaps.Location = new System.Drawing.Point(123, 55);
            this.CBCaps.Name = "CBCaps";
            this.CBCaps.Size = new System.Drawing.Size(78, 16);
            this.CBCaps.TabIndex = 5;
            this.CBCaps.Text = "显示 Caps";
            this.CBCaps.UseVisualStyleBackColor = true;
            this.CBCaps.CheckedChanged += new System.EventHandler(this.CBCaps_CheckedChanged);
            // 
            // CBNum
            // 
            this.CBNum.AutoSize = true;
            this.CBNum.Location = new System.Drawing.Point(22, 55);
            this.CBNum.Name = "CBNum";
            this.CBNum.Size = new System.Drawing.Size(90, 16);
            this.CBNum.TabIndex = 4;
            this.CBNum.Text = "显示 Number";
            this.CBNum.UseVisualStyleBackColor = true;
            this.CBNum.CheckedChanged += new System.EventHandler(this.CBNum_CheckedChanged);
            // 
            // MenuSetting
            // 
            this.MenuSetting.Name = "MenuSetting";
            this.MenuSetting.Size = new System.Drawing.Size(180, 22);
            this.MenuSetting.Text = "设置";
            this.MenuSetting.Click += new System.EventHandler(this.MenuSetting_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 160);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard Plus";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Menu.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelSub;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNum;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCaps;
        private System.Windows.Forms.ToolStripMenuItem MenuItemScroll;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripSeparator MenuItemDiv1;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuStatus1;
        private System.Windows.Forms.ToolStripMenuItem MenuStatus2;
        private System.Windows.Forms.ToolStripMenuItem MenuStatus3;
        private System.Windows.Forms.ToolStripSeparator Div1;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.CheckBox CBScroll;
        private System.Windows.Forms.CheckBox CBCaps;
        private System.Windows.Forms.CheckBox CBNum;
        private System.Windows.Forms.CheckBox CBAuto;
        private System.Windows.Forms.ToolStripMenuItem MenuSetting;
    }
}