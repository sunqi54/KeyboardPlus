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
            this.MenuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.LbFun8 = new System.Windows.Forms.Label();
            this.CbFun8 = new System.Windows.Forms.ComboBox();
            this.LbFun7 = new System.Windows.Forms.Label();
            this.CbFun7 = new System.Windows.Forms.ComboBox();
            this.LbFun6 = new System.Windows.Forms.Label();
            this.CbFun6 = new System.Windows.Forms.ComboBox();
            this.LbFun5 = new System.Windows.Forms.Label();
            this.CbFun5 = new System.Windows.Forms.ComboBox();
            this.CbFun4 = new System.Windows.Forms.ComboBox();
            this.CbFun3 = new System.Windows.Forms.ComboBox();
            this.CbFun2 = new System.Windows.Forms.ComboBox();
            this.LbFun4 = new System.Windows.Forms.Label();
            this.LbFun3 = new System.Windows.Forms.Label();
            this.LbFun2 = new System.Windows.Forms.Label();
            this.LbFun1 = new System.Windows.Forms.Label();
            this.CbFun1 = new System.Windows.Forms.ComboBox();
            this.LbTitle = new System.Windows.Forms.Label();
            this.CBAuto = new System.Windows.Forms.CheckBox();
            this.CBScroll = new System.Windows.Forms.CheckBox();
            this.CBCaps = new System.Windows.Forms.CheckBox();
            this.CBNum = new System.Windows.Forms.CheckBox();
            this.CBFun = new System.Windows.Forms.CheckBox();
            this.Div2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFun = new System.Windows.Forms.ToolStripMenuItem();
            this.LbTip1 = new System.Windows.Forms.Label();
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
            this.LabelTitle.Text = "键盘辅助工具";
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
            this.ButtonClose.Location = new System.Drawing.Point(110, 235);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(100, 30);
            this.ButtonClose.TabIndex = 100;
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
            this.Div2,
            this.MenuFun,
            this.Div1,
            this.MenuSetting,
            this.MenuExit});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(181, 148);
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
            // MenuSetting
            // 
            this.MenuSetting.Name = "MenuSetting";
            this.MenuSetting.Size = new System.Drawing.Size(180, 22);
            this.MenuSetting.Text = "设置";
            this.MenuSetting.Click += new System.EventHandler(this.MenuSetting_Click);
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
            this.Panel1.Location = new System.Drawing.Point(60, 90);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(200, 100);
            this.Panel1.TabIndex = 5;
            // 
            // Panel2
            // 
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.LbTip1);
            this.Panel2.Controls.Add(this.CBFun);
            this.Panel2.Controls.Add(this.LbFun8);
            this.Panel2.Controls.Add(this.CbFun8);
            this.Panel2.Controls.Add(this.LbFun7);
            this.Panel2.Controls.Add(this.CbFun7);
            this.Panel2.Controls.Add(this.LbFun6);
            this.Panel2.Controls.Add(this.CbFun6);
            this.Panel2.Controls.Add(this.LbFun5);
            this.Panel2.Controls.Add(this.CbFun5);
            this.Panel2.Controls.Add(this.CbFun4);
            this.Panel2.Controls.Add(this.CbFun3);
            this.Panel2.Controls.Add(this.CbFun2);
            this.Panel2.Controls.Add(this.LbFun4);
            this.Panel2.Controls.Add(this.LbFun3);
            this.Panel2.Controls.Add(this.LbFun2);
            this.Panel2.Controls.Add(this.LbFun1);
            this.Panel2.Controls.Add(this.CbFun1);
            this.Panel2.Controls.Add(this.LbTitle);
            this.Panel2.Controls.Add(this.CBAuto);
            this.Panel2.Controls.Add(this.CBScroll);
            this.Panel2.Controls.Add(this.CBCaps);
            this.Panel2.Controls.Add(this.CBNum);
            this.Panel2.Controls.Add(this.ButtonClose);
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(320, 280);
            this.Panel2.TabIndex = 1;
            // 
            // LbFun8
            // 
            this.LbFun8.Location = new System.Drawing.Point(166, 193);
            this.LbFun8.Name = "LbFun8";
            this.LbFun8.Size = new System.Drawing.Size(53, 12);
            this.LbFun8.TabIndex = 1;
            this.LbFun8.Text = "电子邮件";
            this.LbFun8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CbFun8
            // 
            this.CbFun8.FormattingEnabled = true;
            this.CbFun8.Location = new System.Drawing.Point(225, 189);
            this.CbFun8.Name = "CbFun8";
            this.CbFun8.Size = new System.Drawing.Size(77, 20);
            this.CbFun8.TabIndex = 38;
            this.CbFun8.SelectedIndexChanged += new System.EventHandler(this.CbFun_SelectedIndexChanged);
            // 
            // LbFun7
            // 
            this.LbFun7.Location = new System.Drawing.Point(166, 165);
            this.LbFun7.Name = "LbFun7";
            this.LbFun7.Size = new System.Drawing.Size(53, 12);
            this.LbFun7.TabIndex = 1;
            this.LbFun7.Text = "浏览器";
            this.LbFun7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CbFun7
            // 
            this.CbFun7.FormattingEnabled = true;
            this.CbFun7.Location = new System.Drawing.Point(225, 161);
            this.CbFun7.Name = "CbFun7";
            this.CbFun7.Size = new System.Drawing.Size(77, 20);
            this.CbFun7.TabIndex = 37;
            this.CbFun7.SelectedIndexChanged += new System.EventHandler(this.CbFun_SelectedIndexChanged);
            // 
            // LbFun6
            // 
            this.LbFun6.Location = new System.Drawing.Point(166, 137);
            this.LbFun6.Name = "LbFun6";
            this.LbFun6.Size = new System.Drawing.Size(53, 12);
            this.LbFun6.TabIndex = 1;
            this.LbFun6.Text = "下一曲";
            this.LbFun6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CbFun6
            // 
            this.CbFun6.FormattingEnabled = true;
            this.CbFun6.Location = new System.Drawing.Point(225, 133);
            this.CbFun6.Name = "CbFun6";
            this.CbFun6.Size = new System.Drawing.Size(77, 20);
            this.CbFun6.TabIndex = 36;
            this.CbFun6.SelectedIndexChanged += new System.EventHandler(this.CbFun_SelectedIndexChanged);
            // 
            // LbFun5
            // 
            this.LbFun5.Location = new System.Drawing.Point(166, 109);
            this.LbFun5.Name = "LbFun5";
            this.LbFun5.Size = new System.Drawing.Size(53, 12);
            this.LbFun5.TabIndex = 1;
            this.LbFun5.Text = "上一曲";
            this.LbFun5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CbFun5
            // 
            this.CbFun5.FormattingEnabled = true;
            this.CbFun5.Location = new System.Drawing.Point(225, 105);
            this.CbFun5.Name = "CbFun5";
            this.CbFun5.Size = new System.Drawing.Size(77, 20);
            this.CbFun5.TabIndex = 35;
            this.CbFun5.SelectedIndexChanged += new System.EventHandler(this.CbFun_SelectedIndexChanged);
            // 
            // CbFun4
            // 
            this.CbFun4.FormattingEnabled = true;
            this.CbFun4.Location = new System.Drawing.Point(79, 189);
            this.CbFun4.Name = "CbFun4";
            this.CbFun4.Size = new System.Drawing.Size(77, 20);
            this.CbFun4.TabIndex = 34;
            this.CbFun4.SelectedIndexChanged += new System.EventHandler(this.CbFun_SelectedIndexChanged);
            // 
            // CbFun3
            // 
            this.CbFun3.FormattingEnabled = true;
            this.CbFun3.Location = new System.Drawing.Point(79, 161);
            this.CbFun3.Name = "CbFun3";
            this.CbFun3.Size = new System.Drawing.Size(77, 20);
            this.CbFun3.TabIndex = 33;
            this.CbFun3.SelectedIndexChanged += new System.EventHandler(this.CbFun_SelectedIndexChanged);
            // 
            // CbFun2
            // 
            this.CbFun2.FormattingEnabled = true;
            this.CbFun2.Location = new System.Drawing.Point(79, 133);
            this.CbFun2.Name = "CbFun2";
            this.CbFun2.Size = new System.Drawing.Size(77, 20);
            this.CbFun2.TabIndex = 32;
            this.CbFun2.SelectedIndexChanged += new System.EventHandler(this.CbFun_SelectedIndexChanged);
            // 
            // LbFun4
            // 
            this.LbFun4.Location = new System.Drawing.Point(20, 193);
            this.LbFun4.Name = "LbFun4";
            this.LbFun4.Size = new System.Drawing.Size(53, 12);
            this.LbFun4.TabIndex = 1;
            this.LbFun4.Text = "播放暂停";
            this.LbFun4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LbFun3
            // 
            this.LbFun3.Location = new System.Drawing.Point(20, 165);
            this.LbFun3.Name = "LbFun3";
            this.LbFun3.Size = new System.Drawing.Size(53, 12);
            this.LbFun3.TabIndex = 1;
            this.LbFun3.Text = "音量增加";
            this.LbFun3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LbFun2
            // 
            this.LbFun2.Location = new System.Drawing.Point(20, 137);
            this.LbFun2.Name = "LbFun2";
            this.LbFun2.Size = new System.Drawing.Size(53, 12);
            this.LbFun2.TabIndex = 1;
            this.LbFun2.Text = "音量减小";
            this.LbFun2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LbFun1
            // 
            this.LbFun1.Location = new System.Drawing.Point(20, 109);
            this.LbFun1.Name = "LbFun1";
            this.LbFun1.Size = new System.Drawing.Size(53, 12);
            this.LbFun1.TabIndex = 1;
            this.LbFun1.Text = "静音";
            this.LbFun1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CbFun1
            // 
            this.CbFun1.FormattingEnabled = true;
            this.CbFun1.Location = new System.Drawing.Point(79, 105);
            this.CbFun1.Name = "CbFun1";
            this.CbFun1.Size = new System.Drawing.Size(77, 20);
            this.CbFun1.TabIndex = 31;
            this.CbFun1.SelectedIndexChanged += new System.EventHandler(this.CbFun_SelectedIndexChanged);
            // 
            // LbTitle
            // 
            this.LbTitle.Location = new System.Drawing.Point(192, 3);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(123, 23);
            this.LbTitle.TabIndex = 1;
            this.LbTitle.Text = "键盘辅助工具";
            this.LbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CBAuto
            // 
            this.CBAuto.AutoSize = true;
            this.CBAuto.Location = new System.Drawing.Point(22, 16);
            this.CBAuto.Name = "CBAuto";
            this.CBAuto.Size = new System.Drawing.Size(84, 16);
            this.CBAuto.TabIndex = 11;
            this.CBAuto.Text = "开机自启动";
            this.CBAuto.UseVisualStyleBackColor = true;
            this.CBAuto.CheckedChanged += new System.EventHandler(this.CBAuto_CheckedChanged);
            // 
            // CBScroll
            // 
            this.CBScroll.AutoSize = true;
            this.CBScroll.Location = new System.Drawing.Point(212, 46);
            this.CBScroll.Name = "CBScroll";
            this.CBScroll.Size = new System.Drawing.Size(90, 16);
            this.CBScroll.TabIndex = 23;
            this.CBScroll.Text = "显示 Scroll";
            this.CBScroll.UseVisualStyleBackColor = true;
            this.CBScroll.CheckedChanged += new System.EventHandler(this.CBScroll_CheckedChanged);
            // 
            // CBCaps
            // 
            this.CBCaps.AutoSize = true;
            this.CBCaps.Location = new System.Drawing.Point(123, 46);
            this.CBCaps.Name = "CBCaps";
            this.CBCaps.Size = new System.Drawing.Size(78, 16);
            this.CBCaps.TabIndex = 22;
            this.CBCaps.Text = "显示 Caps";
            this.CBCaps.UseVisualStyleBackColor = true;
            this.CBCaps.CheckedChanged += new System.EventHandler(this.CBCaps_CheckedChanged);
            // 
            // CBNum
            // 
            this.CBNum.AutoSize = true;
            this.CBNum.Location = new System.Drawing.Point(22, 46);
            this.CBNum.Name = "CBNum";
            this.CBNum.Size = new System.Drawing.Size(90, 16);
            this.CBNum.TabIndex = 21;
            this.CBNum.Text = "显示 Number";
            this.CBNum.UseVisualStyleBackColor = true;
            this.CBNum.CheckedChanged += new System.EventHandler(this.CBNum_CheckedChanged);
            // 
            // CBFun
            // 
            this.CBFun.AutoSize = true;
            this.CBFun.Location = new System.Drawing.Point(22, 75);
            this.CBFun.Name = "CBFun";
            this.CBFun.Size = new System.Drawing.Size(108, 16);
            this.CBFun.TabIndex = 24;
            this.CBFun.Text = "模拟多媒体键盘";
            this.CBFun.UseVisualStyleBackColor = true;
            this.CBFun.CheckedChanged += new System.EventHandler(this.CBFun_CheckedChanged);
            // 
            // Div2
            // 
            this.Div2.Name = "Div2";
            this.Div2.Size = new System.Drawing.Size(177, 6);
            // 
            // MenuFun
            // 
            this.MenuFun.Name = "MenuFun";
            this.MenuFun.Size = new System.Drawing.Size(180, 22);
            this.MenuFun.Text = "多媒体功能键";
            this.MenuFun.Click += new System.EventHandler(this.MenuFun_Click);
            // 
            // LbTip1
            // 
            this.LbTip1.ForeColor = System.Drawing.Color.Gray;
            this.LbTip1.Location = new System.Drawing.Point(20, 212);
            this.LbTip1.Name = "LbTip1";
            this.LbTip1.Size = new System.Drawing.Size(282, 23);
            this.LbTip1.TabIndex = 101;
            this.LbTip1.Text = "提示：模拟键盘依赖系统和应用，可能响应不正常";
            this.LbTip1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 280);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard Plus";
            this.TopMost = true;
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
        private System.Windows.Forms.ComboBox CbFun4;
        private System.Windows.Forms.ComboBox CbFun3;
        private System.Windows.Forms.ComboBox CbFun2;
        private System.Windows.Forms.Label LbFun4;
        private System.Windows.Forms.Label LbFun3;
        private System.Windows.Forms.Label LbFun2;
        private System.Windows.Forms.Label LbFun1;
        private System.Windows.Forms.ComboBox CbFun1;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Label LbFun8;
        private System.Windows.Forms.ComboBox CbFun8;
        private System.Windows.Forms.Label LbFun7;
        private System.Windows.Forms.ComboBox CbFun7;
        private System.Windows.Forms.Label LbFun6;
        private System.Windows.Forms.ComboBox CbFun6;
        private System.Windows.Forms.Label LbFun5;
        private System.Windows.Forms.ComboBox CbFun5;
        private System.Windows.Forms.CheckBox CBFun;
        private System.Windows.Forms.ToolStripSeparator Div2;
        private System.Windows.Forms.ToolStripMenuItem MenuFun;
        private System.Windows.Forms.Label LbTip1;
    }
}