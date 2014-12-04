using System;
using System.Runtime.InteropServices;

namespace Lerch.KeyPressTest
{
    public class KeyPressTest
    {
        [DllImport("user32.dll")]
        public static extern ushort GetKeyState(short nVirtKey);

        public const ushort keyDownBit = 0x80;

        public static void Main(string[] args)
        {
            long counter = 0;
            while (true)
            {
                
                if (IsKeyPressed(ConsoleKey.Escape))
                {
                    Console.WriteLine("Escape key detected");
                    break;
                }

                if (IsKeyPressed(ConsoleKey.UpArrow))
                {
                    Console.WriteLine("UP {0}", counter++);
                }
                else if (IsKeyPressed(ConsoleKey.DownArrow))
                {
                    Console.WriteLine("DOWN {0}", counter--);
                }
            }

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        public static bool IsKeyPressed(ConsoleKey key)
        {
            return ((GetKeyState((short)key) & keyDownBit) == keyDownBit);
        }
    }
}