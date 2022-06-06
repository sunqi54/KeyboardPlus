using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace KeyboardPlus
{
    public partial class Main : Form
    {
        //导入API       
        [DllImport("user32.dll", EntryPoint = "GetKeyboardState")]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        [DllImport("user32.dll", EntryPoint = "GetKeyState")]
        public static extern short GetKeyState(int keyCode);
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        //按键状态
        private const int KEYEVENTF_EXTENDEDKEY = 0x1;
        private const int KEYEVENTF_KEYUP = 0x2;
        //键值
        private const int VK_NUMLOCK = 0x90;
        private const int VK_CAPITAL = 0x14;
        private const int VK_SCROLL = 0x91;
        // 修饰键
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }
        // 动态控件
        private static NotifyIcon IconNum = new NotifyIcon();
        private static NotifyIcon IconCaps = new NotifyIcon();
        private static NotifyIcon IconScroll = new NotifyIcon();
        private static NotifyIcon IconDefault = new NotifyIcon();
        // 变量
        private static bool IsInit = false;
        private static bool EnAuto = false;
        private static bool EnNum = true;
        private static bool EnCaps = true;
        private static bool EnScroll = true;
        private static bool NumLock = false;
        private static bool CapsLock = false;
        private static bool ScrollLock = false;

        // 主程序初始化
        public Main()
        {
            InitializeComponent();
        }
        // 主程序加载
        private void Main_Load(object sender, EventArgs e)
        {
            // Setting
            this.LoadSetting();
            this.LoadAuto();
            // Scroll icon
            IconScroll.Visible = EnScroll;
            IconScroll.Text = "";
            IconScroll.Icon = Properties.Resources.icon_scroll_unlock;
            IconScroll.ContextMenuStrip = this.Menu;
            IconScroll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseClick);
            IconScroll.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseDoubleClick);
            // Caps icon
            IconCaps.Visible = EnCaps;
            IconCaps.Text = "";
            IconCaps.Icon = Properties.Resources.icon_caps_unlock;
            IconCaps.ContextMenuStrip = this.Menu;
            IconCaps.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseClick);
            IconCaps.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseDoubleClick);
            // Num icon
            IconNum.Visible = EnNum;
            IconNum.Text = "";
            IconNum.Icon = Properties.Resources.icon_num_unlock;
            IconNum.ContextMenuStrip = this.Menu;
            IconNum.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseClick);
            IconNum.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseDoubleClick);
            // Default Icon
            IconDefault.Visible = !(EnScroll || EnCaps || EnNum);
            IconDefault.Text = "";
            IconDefault.Icon = Properties.Resources.icon_default;
            IconDefault.ContextMenuStrip = this.Menu;
            IconDefault.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseClick);
            IconDefault.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseDoubleClick);
            // Refresh
            IsInit = false;
            Panel1.Visible = true;      // welcome
            Panel2.Visible = false;     // ctrl
            CBAuto.Checked = EnAuto;
            CBNum.Checked = EnNum;
            CBCaps.Checked = EnCaps;
            CBScroll.Checked = EnScroll;
            this.RefreshIcons();
            // Start
            Timer.Interval = 100;
            Timer.Enabled = true;
        }
        // 主窗体关闭
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Timer.Enabled = false;
            IconNum.Visible = false;
            IconCaps.Visible = false;
            IconScroll.Visible = false;
            IconDefault.Visible = false;
        }
        // 主定时
        private void Timer_Tick(object sender, EventArgs e)
        {
            // 周期化刷新
            this.RefreshState();
            // 初始化界面显示
            if (IsInit == false)
            {
                IsInit = true;
                Panel1.Visible = false;
                Panel2.Visible = true;
                this.Visible = false;
            }
        }
        // 图标点击
        private void Icon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 图标设定
                if (NumLock)
                {
                    MenuStatus1.Image = Properties.Resources.icon_num_lock.ToBitmap();
                }
                else
                {
                    MenuStatus1.Image = Properties.Resources.icon_num_unlock.ToBitmap();
                }
                if (CapsLock)
                {
                    MenuStatus2.Image = Properties.Resources.icon_caps_lock.ToBitmap();
                }
                else
                {
                    MenuStatus2.Image = Properties.Resources.icon_caps_unlock.ToBitmap();
                }
                if (ScrollLock)
                {
                    MenuStatus3.Image = Properties.Resources.icon_scroll_lock.ToBitmap();
                }
                else
                {
                    MenuStatus3.Image = Properties.Resources.icon_scroll_unlock.ToBitmap();
                }
                // 条目设定
                MenuStatus1.Enabled = EnNum;
                MenuStatus2.Enabled = EnCaps;
                MenuStatus3.Enabled = EnScroll;
                // 显示菜单
                Menu.Show();
            }
        }
        private void Icon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            Panel1.Visible = false;
            Panel2.Visible = true;
            this.Visible = true;
            this.Focus();
        }
        // 菜单点击
        private void MenuStatus1_Click(object sender, EventArgs e)
        {
            keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            Application.DoEvents();
        }
        private void MenuStatus2_Click(object sender, EventArgs e)
        {
            keybd_event(VK_CAPITAL, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            keybd_event(VK_CAPITAL, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            Application.DoEvents();
        }
        private void MenuStatus3_Click(object sender, EventArgs e)
        {
            keybd_event(VK_SCROLL, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            keybd_event(VK_SCROLL, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            Application.DoEvents();
        }
        private void MenuSetting_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            this.Visible = true;
            this.Focus();
        }
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // 界面操作
        private void CBNum_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CB = (CheckBox)sender;
            EnNum = CB.Checked;
            this.RefreshIcons();
            this.SaveSetting();
        }
        private void CBCaps_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CB = (CheckBox)sender;
            EnCaps = CB.Checked;
            this.RefreshIcons();
            this.SaveSetting();
        }
        private void CBScroll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CB = (CheckBox)sender;
            EnScroll = CB.Checked;
            this.RefreshIcons();
            this.SaveSetting();
        }
        private void CBAuto_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CB = (CheckBox)sender;
            EnAuto = CB.Checked;
            this.SaveAuto();
            this.LoadAuto();
            CBAuto.Checked = EnAuto;
        }
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        // 刷新图标
        private void RefreshIcons()
        {
            // 复位状态 暂不使用
            // IconScroll.Visible = false;
            // IconCaps.Visible = false;
            // IconNum.Visible = false;
            // 逐个开启
            IconScroll.Visible = EnScroll;
            IconCaps.Visible = EnCaps;
            IconNum.Visible = EnNum;
            IconDefault.Visible = !(EnScroll || EnCaps || EnNum);
        }
        // 刷新键盘
        private void RefreshState()
        {
            bool KeyNum, KeyCaps, KeyScroll;
            // 状态检查
            KeyNum = EnNum ? (GetKeyState(VK_NUMLOCK) != 0x0 ? true : false) : false;
            KeyCaps = EnCaps ? (GetKeyState(VK_CAPITAL) != 0x0 ? true : false) : false;
            KeyScroll = EnScroll ? (GetKeyState(VK_SCROLL) != 0x0 ? true : false) : false;
            // 状态切换
            if (KeyScroll != ScrollLock)
            {
                ScrollLock = KeyScroll;
                IconScroll.Icon = KeyScroll ? Properties.Resources.icon_scroll_lock : Properties.Resources.icon_scroll_unlock;
                IconScroll.Text = KeyScroll ? "Scroll On" : "";
            }
            if (KeyCaps != CapsLock)
            {
                CapsLock = KeyCaps;
                IconCaps.Icon = KeyCaps ? Properties.Resources.icon_caps_lock : Properties.Resources.icon_caps_unlock;
                IconCaps.Text = KeyCaps ? "Caps Lock" : "";
            }
            if (NumLock != KeyNum)
            {
                NumLock = KeyNum;
                IconNum.Icon = KeyNum ? Properties.Resources.icon_num_lock : Properties.Resources.icon_num_unlock;
                IconNum.Text = KeyNum ? "Number Lock" : "";
            }
        }
        // 存储设置
        private void LoadSetting()
        {
            try
            {
                RegistryKey KeyRoot = Registry.LocalMachine.OpenSubKey("SOFTWARE\\KeyboardPlus");
                if (KeyRoot != null)
                {
                    EnNum = KeyRoot.GetValue("EnableNum").ToString() == "1" ? true : false;
                    EnCaps = KeyRoot.GetValue("EnableCaps").ToString() == "1" ? true : false;
                    EnScroll = KeyRoot.GetValue("EnableScroll").ToString() == "1" ? true : false;
                    KeyRoot.Close();
                }
            }
            catch
            { }
        }
        private void SaveSetting() {
            try
            {
                RegistryKey KeyRoot = Registry.LocalMachine.CreateSubKey("SOFTWARE\\KeyboardPlus");
                KeyRoot.SetValue("EnableNum", EnNum ? 1 : 0);
                KeyRoot.SetValue("EnableCaps", EnCaps ? 1 : 0);
                KeyRoot.SetValue("EnableScroll", EnScroll ? 1 : 0);
                KeyRoot.Close();
            }
            catch
            { }
        }
        private void LoadAuto()
        {
            EnAuto = false;
            try
            {
                RegistryKey KeyRoot = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                if (KeyRoot != null)
                {
                    EnAuto = KeyRoot.GetValue("KeyboardPlus") == null ? false : true;
                    KeyRoot.Close();
                }
            }
            catch
            { }
        }
        private void SaveAuto()
        {
            string Path = Application.ExecutablePath;
            if (EnAuto)
            {
                try
                {
                    RegistryKey KeyRoot = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    KeyRoot.SetValue("KeyboardPlus", Path);
                    KeyRoot.Close();
                }
                catch
                { }
            }
            else
            {
                try
                {
                    RegistryKey KeyRoot = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    KeyRoot.DeleteValue("KeyboardPlus");
                    KeyRoot.Close();
                }
                catch
                { }
            }
        }

        // End
    }
}
