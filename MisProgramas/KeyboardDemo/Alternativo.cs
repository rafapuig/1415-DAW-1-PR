using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardDemo
{
    class Alternativo
    {
        static void MainX()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);

                    //Controlador
                    Modelo.PlayerPosX += 1;

                    Draw();

                    if (cki.Key == ConsoleKey.Escape) break;

                }
                //Draw();   //Aqui produce mucho parpadeo
            }
        }

        static void Draw()
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.CursorLeft = Modelo.PlayerPosX;
            Console.CursorTop = Modelo.PlayerPosY;

            Console.Write(Modelo.Player);
        }
    
    }
}
