using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisProgramas
{
    class ConsoleDemo
    {
        static void Main()
        {
            Console.Title = "Demostracion de uso de la clase Console de .NET";
            
            //BufferWindowDemo();
            //ConsoleCursorSizeDemo();
            //ConsoleOutDemo();

            //Console.CursorLeft = 40;
            //Console.CursorTop = 10;
            //Console.CursorSize = 100;
            //key = Console.ReadKey(false);   //No intercepta, se muestra la tecla
            //key = Console.ReadKey(true);
            //key = Console.ReadKey(false);
            //key = Console.ReadKey();    //Equivale a llamar con argumento true
            //Console.SetWindowPosition(20, 30);
            //Console.WindowLeft = 500;
            //Console.WindowTop = 300;
            //Console.WindowWidth = Console.LargestWindowWidth;
            //Console.WindowHeight = Console.LargestWindowHeight;
  
            ShowConsoleStatistics();
            Console.ReadLine();
        }

        static void ConsoleReadKeyDemo()
        {           
            
        }

        private static void ConsoleOutDemo()
        {
            System.IO.TextWriter oldOut = Console.Out;

            using (System.IO.TextWriter w = System.IO.File.CreateText("output.txt"))
            {
                Console.SetOut(w);
                Console.WriteLine("Hola mundo, en fichero de texto");
                w.WriteLine("Y ahora una linea directamente desde la referencia a TextWriter");
            }

            Console.SetOut(oldOut);

            System.Diagnostics.Process.Start("output.txt");
        }

        private static void ConsoleCursorSizeDemo()
        {
            //int[] sizes = new int[] { 1, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            int[] sizes = { 1, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            int saveCursorSize = Console.CursorSize;
            Console.WriteLine("Este ejemplo incrementa el tamaño del cursor desde 1% hasta 100%");
            foreach (int size in sizes)
            {
                Console.CursorSize = size;
                Console.WriteLine("Tamaño del cursor = {0:P0}", (float)size / 100);
                Console.ReadKey();
            }
            Console.CursorSize = saveCursorSize;
        }

        static void BufferWindowDemo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
           
            Console.BufferWidth = 100;
            ConsoleKeyInfo key;

            bool moved = false;
            do
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    int pos = Console.WindowLeft - 1;
                    if (pos >= 0 && pos + Console.WindowWidth <= Console.BufferWidth)
                    {
                        Console.WindowLeft = pos;
                        moved = true;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    int pos = Console.WindowLeft + 1;
                    if (pos + Console.WindowWidth <= Console.BufferWidth)
                    {
                        Console.WindowLeft = pos;
                        moved = true;
                    }
                }
                if (moved)
                {
                    ShowConsoleStatistics();
                    moved = false;
                }
            } while (true);
        }

        static void ShowConsoleStatistics()
        {
            Console.WriteLine("Estadisticas de la Consola");
            Console.WriteLine("Buffer: {0} x {1}", Console.BufferHeight, Console.BufferWidth);
            Console.WriteLine("Window: {0} x {1}", Console.WindowHeight, Console.WindowWidth);
            Console.WriteLine("Window starts at: {0},{1}", Console.WindowLeft, Console.WindowTop);
            Console.WriteLine("Cursor Position: {0},{1}", Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("Cursor Visible: {0}", Console.CursorVisible.ToString().ToLowerInvariant());
        }
    }
}
