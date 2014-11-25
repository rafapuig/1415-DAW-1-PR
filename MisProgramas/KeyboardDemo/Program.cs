using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace KeyboardDemo
{
    class Program
    {
        //Indica si debemos terminar el juego
        static bool Exit = false;

        //Itervalo en milisegundos que debe transcurrir entre actualizaciones del estado del modelo del juego
        const int PeriodTime = 8;
          

        static void Main()
        {
            System.Threading.TimerCallback updatingTime = state =>
            {
                Update();
                //Draw();
            };

            System.Threading.TimerCallback drawingTime = state =>
            {
                Draw();
                //new System.Threading.Thread(Draw);
            };           

            Initialize();
            Draw();

            var updateTimer = new System.Threading.Timer(updatingTime, null, 0, PeriodTime);
            var drawTimer = new System.Threading.Timer(drawingTime, null, 0, PeriodTime * 2);

            while (!Exit) {
                //Draw();
                //System.Threading.Thread.Sleep(PeriodTime);
            }

            //while (!Exit)
            //{
            //    Update();
            //    Draw();
            //    //System.Threading.Thread.Sleep(40);
            //}            
        }        

        //Inicializar el juego, se llama una vez para preparar los elementos del juego
        static void Initialize()
        {
            Console.Title = "Demo teclado";
            Console.CursorVisible = false;

            //Dar un tamaño a la ventana de la consola
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;            

            //Decirle al modelo como debe obtener los valores de acho y alto de espacio de la pantalla
            Modelo.GetViewPortWidth = () => Console.WindowWidth - 1;
            Modelo.GetViewPortHeight = () => Console.WindowHeight - 1;

            //Seleccionar la imagen ascci para representar al jugador
            Modelo.Player = AsciiModels.Plane;
            
            //Posicionar el jugador en medio de la pantalla
            Modelo.Mover(
                (Modelo.GetViewPortWidth() - Modelo.PlayerWidth) / 2,
                (Modelo.GetViewPortHeight() - Modelo.PlayerHeight) / 2);  
        }   
       

        //Actualizar el modelo segun las entradas del usuario mediante el teclado
        static void Update()
        {
            int deltaX = 0;
            int deltaY = 0;  

            if (Win32API.IsKeyPressed(ConsoleKey.RightArrow)) deltaX = 1;
            if (Win32API.IsKeyPressed(ConsoleKey.LeftArrow)) deltaX = -1;
            if (Win32API.IsKeyPressed(ConsoleKey.UpArrow)) deltaY = -1;
            if (Win32API.IsKeyPressed(ConsoleKey.DownArrow)) deltaY = 1;

            if (deltaX != 0 || deltaY != 0)
            {
                Modelo.Mover(deltaX, deltaY);
                Console.Beep(220, 22);
            }

            if (Win32API.IsKeyPressed(ConsoleKey.Escape))
                Exit = true;                    
        }


        //Dibujar el "mundo virual" o escena en la que transcurre el juego
        static void Draw()
        {        
            if (!Modelo.HasChanged) return;

            Console.Clear();

            string[] titulo = new string[] {
                    @" _____                         _______        _           _       ",
                    @"|  __ \                       |__   __|      | |         | |      ",
                    @"| |  | | ___ _ __ ___   ___      | | ___  ___| | __ _  __| | ___  ",
                    @"| |  | |/ _ \ '_ ` _ \ / _ \     | |/ _ \/ __| |/ _` |/ _` |/ _ \ ",
                    @"| |__| |  __/ | | | | | (_) |    | |  __/ (__| | (_| | (_| | (_) |",
                    @"|_____/ \___|_| |_| |_|\___/     |_|\___|\___|_|\__,_|\__,_|\___/ "};


            DrawAsciiModel(
                (Console.WindowWidth - titulo[0].Length) / 2,
                0, titulo);
            
            ////Console.CursorLeft = Modelo.PlayerPosX;
            //Console.CursorTop = Modelo.PlayerPosY;         

            //for (int i = 0; i < Modelo.PlayerHeight; i++)
            //{
            //    Console.CursorLeft = Modelo.PlayerPosX;
            //    Console.Write(Modelo.Player[i]);
            //    if (i < Modelo.PlayerHeight - 1) Console.CursorTop++;
            //}

            DrawAsciiModel(Modelo.PlayerPosX, Modelo.PlayerPosY, Modelo.Player);

            //Cuando se termina el resfreco de pantalla la escena esta actualizada  
            Modelo.ResetChanges();

        }

        //Dibuja un modelo Ascii en la posicion X,Y indicada
        static void DrawAsciiModel(int x, int y, string[] asciiModel)
        {
            for (int i = 0; i < asciiModel.Length; i++)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y + i;
                Console.Write(asciiModel[i]);                
            }
        }
    
    }
}
