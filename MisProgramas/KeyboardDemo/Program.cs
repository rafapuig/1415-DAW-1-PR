using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KeyboardDemo
{
    class Program
    {
        //Indica si debemos terminar el juego
        static bool Exit = false;

        //Intervalo en milisegundos que debe transcurrir entre actualizaciones del estado del modelo del juego
        const int UpdateRate = 1;
        const int FrameRate = 16;

        //Inidicar si estamos utilizando un doble buffer para crear la escena y luego volcarla a la consola una vez generada
        static bool DoubleBufferMode { get { return ConsoleDobleBuffer != null; } }

        //Doble buffer para la consola
        static DoubleBuffer.buffer ConsoleDobleBuffer = null;

        //Como vamos a dibujar las lineas de un grafico ascii (depende de si se usa doble buffer)
        static Action<int, int, string, ConsoleColor, ConsoleColor> DrawAsciiModelLine
        {
            get
            {
                if (DoubleBufferMode) return DrawLineInBuffer;  //Si estamos en modo doble buffer la estrategia es dibujarla en el buffer
                return DrawLine;    //Si no la estrategia es dibujar directamente en la consola
            }
        }

        //Como dibujar una linea en posicion x,y -> dibujarla en el buffer
        static Action<int, int, string, ConsoleColor, ConsoleColor> DrawLineInBuffer = (i, j, linea, foregroundColor, backgroundColor) =>
        {
            ConsoleDobleBuffer.Draw(linea, i, j, foregroundColor, backgroundColor);
        };

        //static short GetAttributeFromConsoleColors()
        //{
        //    return (short)(16 * (int)Console.BackgroundColor + (int)Console.ForegroundColor);
        //}

        

        //static void MainOld()
        //{
        //    System.Threading.TimerCallback updatingTime = state =>
        //    {
        //        Update();
        //        //Draw();
        //    };

        //    System.Threading.TimerCallback drawingTime = state =>
        //    {
        //        Draw();
        //        //new System.Threading.Thread(Draw);
        //    };           

        //    Initialize();
        //    Draw();

        //    var updateTimer = new System.Threading.Timer(updatingTime, null, 0, PeriodTime);
        //    var drawTimer = new System.Threading.Timer(drawingTime, null, 0, PeriodTime * 2);

        //    while (!Exit) {
        //        //Draw();
        //        //System.Threading.Thread.Sleep(PeriodTime);
        //    }

        //    //while (!Exit)
        //    //{
        //    //    Update();
        //    //    Draw();
        //    //    //System.Threading.Thread.Sleep(40);
        //    //}            
        //}
        
        static void Main()
        {  
            Initialize();
            Draw();

            //Activar los temporizadores para llamar a Update y Draw cuando se cumpla el intervalo de tiempo
            var updateTimer = new Timer(state => { Update(); }, null, 0, UpdateRate);

            //Thread drawer = new Thread(DrawWork);
            //drawer.Start();

            var drawTimer = new Timer(state => { Draw(); }, null, UpdateRate, FrameRate);  //PeriodTime * 4);

            //Esperar a que se pulse la tecla de salida
            while (!Exit) { } //Update();  }              
        
        }

        static void DrawWork()
        {
            var drawTimer = new Timer(state => { Draw(); }, null, 0, UpdateRate * 4);
            //while (true)
            //{
            //    DateTime nextTime = DateTime.Now.AddMilliseconds(100);

            //    while (DateTime.Now < nextTime) { }
            //    Draw();
            //}
            //while (true) { Draw(); }
        }

        

        //Inicializar el juego, se llama una vez para preparar los elementos del juego
        static void Initialize()
        {
            Console.Title = "Demo teclado";
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            

            //Dar un tamaño a la ventana de la consola (lo mas grande posible)
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;

            //Inicializar el doble buffer y el delegado para dibujar lineas segun sea el caso
            ConsoleDobleBuffer = new DoubleBuffer.buffer(Console.WindowWidth, Console.WindowHeight, Console.WindowWidth, Console.WindowHeight);
            

            //Decirle al modelo como debe obtener los valores de ancho y alto de espacio de la pantalla
            Modelo.GetViewPortWidth = () => Console.WindowWidth - 1;
            Modelo.GetViewPortHeight = () => Console.WindowHeight - 1;

            //Seleccionar la imagen ascci para representar al jugador
            Modelo.Player = AsciiModels.MilleniumFalconVertical;
            
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
                //Console.Beep(220, 22);
            }

            Modelo.MoverEnemigos();

            if (Win32API.IsKeyPressed(ConsoleKey.Escape))
                Exit = true;                    
        }


        //Dibujar el "mundo virual" o escena en la que transcurre el juego
        static void Draw()
        {  
            //Si no hay cambios en el modelo volver sin hacer nada
            if (!Modelo.HasChanged) return;

            if (DoubleBufferMode)
                ConsoleDobleBuffer.Clear(Console.BackgroundColor); //Aplicar este metodo para limpiar el doble buffer (donde se crea la escena)
            else
                Console.Clear();  //Cuando se dibuja directamente en la consola en lugar del doble buffer

            //Dibujar el siguiente frame a mostrar en la pantalla
            DrawFrame();

            if(DoubleBufferMode) ConsoleDobleBuffer.Print(); //Volcar el contenido del buffer en la pantalla (Consola) si usamos doble buffer
            
            //Cuando se termina el resfreco de pantalla la escena esta actualizada  
            Modelo.ResetChanges();
        }

        private static void DrawFrame()
        {
            string[] titulo = new string[] {
                    @" _____                         _______        _           _       ",
                    @"|  __ \                       |__   __|      | |         | |      ",
                    @"| |  | | ___ _ __ ___   ___      | | ___  ___| | __ _  __| | ___  ",
                    @"| |  | |/ _ \ '_ ` _ \ / _ \     | |/ _ \/ __| |/ _` |/ _` |/ _ \ ",
                    @"| |__| |  __/ | | | | | (_) |    | |  __/ (__| | (_| | (_| | (_) |",
                    @"|_____/ \___|_| |_| |_|\___/     |_|\___|\___|_|\__,_|\__,_|\___/ "};


            //Dibujar el rotulo de Demo Teclado centrado en la pantalla y arriba del todo
            DrawASCIIModel(
                (Console.WindowWidth - titulo[0].Length) / 2,
                0, titulo,
                ConsoleColor.Magenta, Console.BackgroundColor);


            //Dibuja unos enemigos por ahi            

            foreach(Enemigo e in Modelo.Enemigos)
            {
                DrawASCIIModel((int)e.PosX, (int)e.PosY, AsciiModels.EnemyShip, ConsoleColor.Yellow, Console.BackgroundColor);
            }

            //Dibujar el jugador
            DrawASCIIModel(Modelo.PlayerPosX, Modelo.PlayerPosY, Modelo.Player, ConsoleColor.White, Console.BackgroundColor);  

        }


        //Dibuja un modelo Ascii en la posicion X,Y indicada en el doble buffer o directamente en la consola
        static void DrawASCIIModel(int x, int y, string[] asciiChars, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            for (int i = 0; i < asciiChars.Length; i++)
            {
                DrawAsciiModelLine(x, y + i, asciiChars[i], foregroundColor, backgroundColor);
            }
        }


        //Dibujar una linea en posicion X,Y directamente en la pantalla sin usar doble buffer
        static void DrawLine(int x, int y, string line, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            ConsoleColor prevForegroundColor = Console.ForegroundColor;
            ConsoleColor prevBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.SetCursorPosition(x, y);
            Console.Write(line);

            Console.ForegroundColor = prevForegroundColor;
            Console.BackgroundColor = prevBackgroundColor;
        }


        ////Vesion sin delegados
        //static void DrawAsciiModel(int x, int y, string[] asciiModel, bool dobleBufferMode = true)
        //{
        //    for (int i = 0; i < asciiModel.Length; i++)
        //    {
        //        if(dobleBufferMode)
        //            ConsoleDobleBuffer.Draw(asciiModel[i], x, y + i, 7);
        //        else
        //        {
        //            Console.CursorLeft = x;
        //            Console.CursorTop = y + i;
        //            Console.Write(asciiModel[i]);
        //        }               
        //    }
        //}
    
    }
}
