using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;


namespace KeyboardPlus
{
    class Hook
    {
        // 导入WIN32API
        // 设置系统级钩子
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        // 卸载钩子
        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(int idHook);
        // 调用下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);
        // 获取当前线程ID
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
        // 获取当前句柄
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);
        // 获取按键的状态
        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        // 键盘转码
        [DllImport("user32.dll")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);
        //
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        HookProc KeyboardHookProcedure;
        //键盘结构
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;      // 虚拟键
            public int scanCode;    // 扫描码
            public int flags;       // 键标志
            public int time;        // 时间戳
            public int dwExtraInfo;
        }
        public event KeyEventHandler KeyDownEvent;
        public event KeyPressEventHandler KeyPressEvent;
        public event KeyEventHandler KeyUpEvent;
        // Windows SDK,Winuser.h
        public const int WH_KEYBOARD = 2;   // 线程键盘钩子，消息分发后
        public const int WH_KEYBOARD_LL = 13;   // 全局键盘钩子,消息分发前
        // 消息
        private const int WM_KEYDOWN = 0x100;   //KEYDOWN
        private const int WM_KEYUP = 0x101; //KEYUP
        private const int WM_SYSKEYDOWN = 0x104;    //SYSKEYDOWN
        private const int WM_SYSKEYUP = 0x105;  //SYSKEYUP
        // 变量
        public static int hHook = 0;

        // 启动键盘钩子
        public void Start()
        {
            if (hHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                hHook = SetWindowsHookEx(
                    WH_KEYBOARD_LL, // int idHook
                    KeyboardHookProcedure,  // HookProc lpfn
                    GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName), // IntPtr hInstance
                    0 // int threadId
                );
                if (hHook == 0)
                {
                    Stop();
                }
            }
        }

        public void Stop()
        {
            if (hHook != 0)
            {
                UnhookWindowsHookEx(hHook);
                hHook = 0;
            }
        }

        // 键盘监听函数
        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // 侦听键盘事件
            if ((nCode >= 0) && (KeyDownEvent != null || KeyUpEvent != null || KeyPressEvent != null))
            {
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                // 触发键盘按下事件
                if (KeyDownEvent != null && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyDownEvent(this, e);
                }
                // 触发键盘按压
                if (KeyPressEvent != null && wParam == WM_KEYDOWN)
                {
                    byte[] keyState = new byte[256];
                    GetKeyboardState(keyState);
                    byte[] inBuffer = new byte[2];
                    if (ToAscii(MyKeyboardHookStruct.vkCode, MyKeyboardHookStruct.scanCode, keyState, inBuffer, MyKeyboardHookStruct.flags) == 1)
                    {
                        KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
                        KeyPressEvent(this, e);
                    }
                }
                // 触发键盘弹起
                if (KeyUpEvent != null && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyUpEvent(this, e);
                }
            }
            return CallNextHookEx(hHook, nCode, wParam, lParam);
        }
        
        // End
        ~Hook()
        {
            Stop();
        }
    }
}
