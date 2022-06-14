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
        // 导入API       
        [DllImport("user32.dll", EntryPoint = "GetKeyboardState")]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        [DllImport("user32.dll", EntryPoint = "GetKeyState")]
        public static extern short GetKeyState(int keyCode);
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        // 按键状态
        private const int KEYEVENTF_EXTENDEDKEY = 0x1;
        private const int KEYEVENTF_KEYUP = 0x2;
        // 键值
        private const int VK_NUMLOCK = 0x90;
        private const int VK_CAPITAL = 0x14;
        private const int VK_SCROLL = 0x91;
        private const int VK_BROWSER_HOME = 0xAC;
        private const int VK_VOLUME_MUTE = 0xAD;
        private const int VK_VOLUME_DOWN = 0xAE;
        private const int VK_VOLUME_UP = 0xAF;
        private const int VK_MEDIA_NEXT_TRACK = 0xB0;
        private const int VK_MEDIA_PREV_TRACK = 0xB1;
        private const int VK_MEDIA_STOP = 0xB2; // UNUSED
        private const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        private const int VK_LAUNCH_MAIL = 0xB4;
        private const int VK_LAUNCH_MEDIA_SELECT = 0xB5; // UNUSED
        private const int VK_LAUNCH_APP1 = 0xB6; // UNUSED
        private const int VK_LAUNCH_APP2 = 0xB7; // UNUSED
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
        private static bool EnFunKey = false;
        private static bool IsCbMasked = false;
        private static int[] FunKeys = new int[8];
        private static int[] FunKeysVK = new int[8] {
            VK_VOLUME_MUTE,VK_VOLUME_DOWN,VK_VOLUME_UP,VK_MEDIA_PLAY_PAUSE,
            VK_MEDIA_PREV_TRACK,VK_MEDIA_NEXT_TRACK,VK_BROWSER_HOME,VK_LAUNCH_MAIL
        };
        //
        private static Hook KeyBoardHook;

        // 主程序初始化
        public Main()
        {
            InitializeComponent();
        }
        // 主程序加载
        private void Main_Load(object sender, EventArgs e)
        {
            // Data initialize
            #region
            for (int i = 0; i < FunKeys.Length; i++)
            {
                FunKeys[i] = 0; // CLOSE
            }
            FunKeys[0] = 4; // MUTE
            FunKeys[1] = 5; // VOL DOWN
            FunKeys[2] = 6; // VOL UP
            FunKeys[3] = 7; // PLAY
            FunKeys[4] = 8; // PREV
            FunKeys[5] = 9; // NEXT
            #endregion
            // Setting
            this.LoadSetting();
            this.LoadAuto();
            // Notify
            #region
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
            #endregion
            // ComboBox
            #region
            CbFun1.Items.Add("未设置");
            CbFun2.Items.Add("未设置");
            CbFun3.Items.Add("未设置");
            CbFun4.Items.Add("未设置");
            CbFun5.Items.Add("未设置");
            CbFun6.Items.Add("未设置");
            CbFun7.Items.Add("未设置");
            CbFun8.Items.Add("未设置");
            for (int k = 1; k <= 12; k++)
            {
                CbFun1.Items.Add("Ctrl+F" + k);
                CbFun2.Items.Add("Ctrl+F" + k);
                CbFun3.Items.Add("Ctrl+F" + k);
                CbFun4.Items.Add("Ctrl+F" + k);
                CbFun5.Items.Add("Ctrl+F" + k);
                CbFun6.Items.Add("Ctrl+F" + k);
                CbFun7.Items.Add("Ctrl+F" + k);
                CbFun8.Items.Add("Ctrl+F" + k);
            }
            this.UpdateCbFunIndex();
            CbFun1.Enabled = EnFunKey;
            CbFun2.Enabled = EnFunKey;
            CbFun3.Enabled = EnFunKey;
            CbFun4.Enabled = EnFunKey;
            CbFun5.Enabled = EnFunKey;
            CbFun6.Enabled = EnFunKey;
            CbFun7.Enabled = EnFunKey;
            CbFun8.Enabled = EnFunKey;
            #endregion
            // Refresh
            Panel1.Visible = true;      // Welcome show
            Panel2.Visible = false;     // Panel show
            CBAuto.Checked = EnAuto;
            CBNum.Checked = EnNum;
            CBCaps.Checked = EnCaps;
            CBScroll.Checked = EnScroll;
            CBFun.Checked = EnFunKey;
            this.RefreshIcons();
            // Hook
            KeyBoardHook = new Hook();
            KeyBoardHook.KeyDownEvent += new KeyEventHandler(Keyboard_KeyDown);
            if (EnFunKey)
            {
                KeyBoardHook.Start();
            }
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
            KeyBoardHook.Stop();
        }
        // 主定时
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Refresh keyboard key status
            this.RefreshState();
            // Initialize over
            if (IsInit == false)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                this.Visible = false;
                IsInit = true;
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
                MenuFun.Text = "多媒体功能键  " + (EnFunKey ? "已开启" : "已关闭");
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
            this.SimKeyPress(VK_NUMLOCK);
        }
        private void MenuStatus2_Click(object sender, EventArgs e)
        {
            this.SimKeyPress(VK_CAPITAL);
        }
        private void MenuStatus3_Click(object sender, EventArgs e)
        {
            this.SimKeyPress(VK_SCROLL);
        }
        private void MenuFun_Click(object sender, EventArgs e)
        {
            if (EnFunKey)
            {
                CBFun.Checked = false;
                MenuFun.Text = "多媒体功能键  " + "已关闭";
            }
            else
            {
                CBFun.Checked = true;
                MenuFun.Text = "多媒体功能键  " + "已开启";
            }
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
        private void CBAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (IsInit)
            {
                CheckBox CB = (CheckBox)sender;
                EnAuto = CB.Checked;
                this.SaveAuto();
                this.LoadAuto();
            }
        }
        private void CBNum_CheckedChanged(object sender, EventArgs e)
        {
            if (IsInit)
            {
                CheckBox CB = (CheckBox)sender;
                EnNum = CB.Checked;
                this.RefreshIcons();
                this.SaveSetting();
            }
        }
        private void CBCaps_CheckedChanged(object sender, EventArgs e)
        {
            if (IsInit)
            {
                CheckBox CB = (CheckBox)sender;
                EnCaps = CB.Checked;
                this.RefreshIcons();
                this.SaveSetting();
            }
        }
        private void CBScroll_CheckedChanged(object sender, EventArgs e)
        {
            if (IsInit)
            {
                CheckBox CB = (CheckBox)sender;
                EnScroll = CB.Checked;
                this.RefreshIcons();
                this.SaveSetting();
            }
        }
        private void CBFun_CheckedChanged(object sender, EventArgs e)
        {
            if (IsInit)
            {
                CheckBox CB = (CheckBox)sender;
                EnFunKey = CB.Checked;
                CbFun1.Enabled = EnFunKey;
                CbFun2.Enabled = EnFunKey;
                CbFun3.Enabled = EnFunKey;
                CbFun4.Enabled = EnFunKey;
                CbFun5.Enabled = EnFunKey;
                CbFun6.Enabled = EnFunKey;
                CbFun7.Enabled = EnFunKey;
                CbFun8.Enabled = EnFunKey;
                if (EnFunKey)
                {
                    KeyBoardHook.Start();
                }
                else
                {
                    KeyBoardHook.Stop();
                }
                this.SaveSetting();
            }
        }
        private void CbFun_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mask
            if (IsInit && !IsCbMasked)
            {
                ComboBox CB = (ComboBox)sender;
                int idx = -1;
                switch (CB.Name)
                {
                    case "CbFun1": idx = 0; break;
                    case "CbFun2": idx = 1; break;
                    case "CbFun3": idx = 2; break;
                    case "CbFun4": idx = 3; break;
                    case "CbFun5": idx = 4; break;
                    case "CbFun6": idx = 5; break;
                    case "CbFun7": idx = 6; break;
                    case "CbFun8": idx = 7; break;
                }
                // check
                if (idx > -1)
                {
                    FunKeys[idx] = CB.SelectedIndex;
                    this.CheckFunKeys(idx);
                    this.UpdateCbFunIndex();
                    this.SaveSetting();
                }
            }
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
        // 模拟按键
        private void SimKeyPress(int Key)
        {
            keybd_event((byte)Key, 0, 0, (UIntPtr)0);
            keybd_event((byte)Key, 0, KEYEVENTF_KEYUP, (UIntPtr)0);
            Application.DoEvents();
        }
        // 多媒体功能
        private void CheckFunKeys(int first)
        {
            // 1st loop
            for (int i=0;i<FunKeys.Length;i++)
            {
                if (i != first && FunKeys[i] > 0 && FunKeys[i] == FunKeys[first])
                {
                    FunKeys[i] = 0;
                }
            }
            // 2nd loop
            for (int m=0;m<FunKeys.Length;m++)
            {
                for (int n = m + 1; n < FunKeys.Length; n++)
                {
                    if (FunKeys[m] > 0 && FunKeys[n] == FunKeys[m])
                    {
                        FunKeys[m] = 0;
                    }
                }
            }
        }
        private void UpdateCbFunIndex() {
            IsCbMasked = true;
            CbFun1.SelectedIndex = FunKeys[0];
            CbFun2.SelectedIndex = FunKeys[1];
            CbFun3.SelectedIndex = FunKeys[2];
            CbFun4.SelectedIndex = FunKeys[3];
            CbFun5.SelectedIndex = FunKeys[4];
            CbFun6.SelectedIndex = FunKeys[5];
            CbFun7.SelectedIndex = FunKeys[6];
            CbFun8.SelectedIndex = FunKeys[7];
            IsCbMasked = false;
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
                    EnFunKey = KeyRoot.GetValue("EnableFun").ToString() == "1" ? true : false;
                    for (int i = 0; i < FunKeys.Length; i++)
                    {
                        string kk = "FunKeys_" + i.ToString();
                        string vv = KeyRoot.GetValue(kk).ToString();
                        int v;
                        bool r = int.TryParse(vv, out v);
                        FunKeys[i] = r ? v : 0;
                    }
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
                KeyRoot.SetValue("EnableFun", EnFunKey ? 1 : 0);
                for (int i = 0; i < FunKeys.Length; i++)
                {
                    string kk = "FunKeys_" + i.ToString();
                    KeyRoot.SetValue(kk, FunKeys[i]);
                }
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
        // 键盘监听
        private void Keyboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode >= Keys.F1 && e.KeyCode <= Keys.F12)
            {
                // Key value
                int kval = 0;
                switch (e.KeyCode)
                {
                    case Keys.F1: kval = 1; break;
                    case Keys.F2: kval = 2; break;
                    case Keys.F3: kval = 3; break;
                    case Keys.F4: kval = 4; break;
                    case Keys.F5: kval = 5; break;
                    case Keys.F6: kval = 6; break;
                    case Keys.F7: kval = 7; break;
                    case Keys.F8: kval = 8; break;
                    case Keys.F9: kval = 9; break;
                    case Keys.F10: kval = 10; break;
                    case Keys.F11: kval = 11; break;
                    case Keys.F12: kval = 12; break;
                }
                // VKey
                for (int i = 0; i < FunKeys.Length; i++)
                {
                    if (FunKeys[i] > 0 && FunKeys[i] == kval)
                    {
                        this.SimKeyPress(FunKeysVK[i]);
                    }
                }
            }
        }
        // End
    }
}
