using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace cs_MouseController
{
    class cs_MouseController
    {

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public int dwExtraInfo;
        };

        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT
        {
            [FieldOffset(0)]
            public int type;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
        };

        [DllImport("user32.dll")]
        private extern static void SendInput(int nInputs, ref INPUT pInputs, int cbsize);

        private const int INPUT_MOUSE = 0;

        private const int MOUSEEVENTF_LEFTDOWN = 0x2;
        private const int MOUSEEVENTF_LEFTUP = 0x4;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public Point GetPosition()
        {
            return Cursor.Position;
        }

        public void SetPosition(Point position)
        {
            Cursor.Position = position;
        }

        public void LeftClick()
        {
            var mouse = new cs_MouseController();

            var inp = new INPUT();
            inp.type = INPUT_MOUSE;
            inp.mi.dx = 0;
            inp.mi.dy = 0;
            inp.mi.mouseData = 0;
            inp.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            inp.mi.time = 0;
            inp.mi.dwExtraInfo = 0;
            SendInput(1, ref inp, Marshal.SizeOf(inp));

            System.Threading.Thread.Sleep(100);

            inp.mi.dwFlags = MOUSEEVENTF_LEFTUP;
            SendInput(1, ref inp, Marshal.SizeOf(inp));
        }

        public void RightClick()
        {
            var mouse = new cs_MouseController();

            var inp = new INPUT();
            inp.type = INPUT_MOUSE;
            inp.mi.dx = 0;
            inp.mi.dy = 0;
            inp.mi.mouseData = 0;
            inp.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            inp.mi.time = 0;
            inp.mi.dwExtraInfo = 0;
            SendInput(1, ref inp, Marshal.SizeOf(inp));

            System.Threading.Thread.Sleep(100);

            inp.mi.dwFlags = MOUSEEVENTF_LEFTUP;
            SendInput(1, ref inp, Marshal.SizeOf(inp));
        }
    }
}