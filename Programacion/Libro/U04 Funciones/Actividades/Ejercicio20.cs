using System;

namespace Programacion.Funciones.Actividades.Ejercicio20
{
    delegate string ObtenerBloqueDelegate(
        int ancho, int alto, int fila, int col, string bloque1, string bloque2);
        
    static class CUI
    {
        static void Main()
        {
            Console.Title = "Dibujar Formas";
            char opcion;
            do
            {
                int ancho, alto;
                opcion = MostrarMenu();

                switch (opcion)
                {
                    case 'c':
                        MostrarRectangulo(ancho = ObtenerDimension("lado"), ancho);
                        break;
                    case 't':
                        MostrarTriangulo(ObtenerDimension("base"));
                        break;
                    case 'r':
                        MostrarRectangulo(
                            ObtenerDimension("ancho"),
                            ObtenerDimension("alto"));
                        break;
                    case '5':
                        MostrarForma(
                            ObtenerDimension("ancho"),
                            ObtenerDimension("alto"), " ",
                            ObtenerLadrillo(),
                            (w, h, i, j, e, l) =>
                                i == 0 || i == h - 1 || j == 0 || j == w - 1 ? l : e);
                        break;
                    case 'h':
                        MostrarForma(ancho = ObtenerDimension("base"),
                            ancho - 1, " ",
                            ObtenerLadrillo(),
                            (w, h, i, j, e, l) =>
                               (i < (h + 1) / 2 ? j < w / 2 - 1 - i : j < i - (w / 2 - 1)) ? e : l + e);
                        break;

                    case 'b':
                        MostrarForma(ancho = ObtenerDimension("base"),
                            ancho * 2 - 1, " ",
                            ObtenerLadrillo(),
                            (w, h, i, j, e, l) =>
                               (i < (h + 1) / 2 ? j < (w - 1) - i : j < i - (w - 1)) ? e : l + e);
                        break;

                    case '1':
                        MostrarForma(ancho = ObtenerDimension("base"),
                            ancho, " ",
                            ObtenerLadrillo(),
                            Logica.ObtenerBloquePiramide1);
                        break;

                    case '2':
                        MostrarForma(ancho = ObtenerDimension("base"),
                            ancho, " ",
                            ObtenerLadrillo(),
                            Logica.ObtenerBloquePiramide2);
                        break;

                    case '3':
                        MostrarForma(ancho = ObtenerDimension("base"),
                            ancho, " ",
                            ObtenerLadrillo(),
                            Logica.ObtenerBloquePiramide3);
                        break;
                }

            } while (opcion != 's');
        }

        static char MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Elige el dibujo: ");
            Console.WriteLine("1. -Piramide 1");
            Console.WriteLine("2. -Piramide 2");
            Console.WriteLine("3. -Piramide 3");
            Console.WriteLine("C. -Dibujar cuadrado");
            Console.WriteLine("T. -Dibujo triangulo");
            Console.WriteLine("R.- Dibujo rectangulo");
            Console.WriteLine("B.- Dibujo rombo");
            Console.WriteLine("H.- Hexagono");
            Console.WriteLine("S.- Salir ");
            return char.ToLower(Console.ReadKey(true).KeyChar);
        }


        static int ObtenerDimension(string dimension)
        {
            int num;
            Console.Write("Introduce {0} del dibujo: ", dimension);
            while (!Int32.TryParse(Console.ReadLine(), out num) || num < 0)
                Console.Write("\nIncorrecto. Repite: ");
            return num;
        }
        
        static string ObtenerLadrillo()
        {           
            Console.Write("Introduce el caracter ladrillo (@): ");
            string entrada = Console.ReadLine();
            return entrada == "" ? "@" : entrada;
        }
        
        //static void MostrarForma(ObtenerBloqueDelegate obtenerBloque)
        //{
        //    string ladrillo = ObtenerLadrillo();
        //    int ancho = ObtenerAncho();
        //    int alto = ObtenerAlto();

        //    string forma = DibujarForma(ancho, alto, " ", ladrillo, obtenerBloque);

        //    Console.Clear();
        //    //Console.Write(forma); 

        //    string[] lineas = forma.Split('\n');
            
        //    //Console.CursorTop = 0;
        //    foreach (var linea in lineas)
        //    {
        //        //Console.CursorLeft = ancho;
        //        Console.WriteLine(linea);
        //    }

        //    //Console.CursorTop = ancho;
        //    //foreach (var linea in lineas)
        //    //{
        //    //    Console.CursorLeft = 0;
        //    //    Console.WriteLine(linea);
        //    //}

        //    //Console.CursorTop = ancho;
        //    //foreach (var linea in lineas)
        //    //{
        //    //    Console.CursorLeft = ancho * (obtenerBloque == ObtenerBloquePiramide2 ? 2 : 1);
        //    //    Console.WriteLine(linea);
        //    //}

        //    Console.ReadKey();
        //}

        static void MostrarRectangulo(int ancho, int alto)
        {
            string ladrillo = ObtenerLadrillo();

            string forma = Logica.DibujarForma(ancho, alto, " ", ladrillo,
                (w, h, i, j, e, l) => i == 0 || i == h - 1 || j == 0 || j == w - 1 ? l : e);

            MostrarForma(forma, (Console.WindowWidth - ancho) / 2, (Console.WindowHeight - alto) / 2);
        }

        static void MostrarTriangulo(int tam)
        {
            
            string ladrillo = ObtenerLadrillo();

            //string forma = DibujarForma(tam, tam, " ", ladrillo,
            //    (w, h, i, j, e, l) => j < w - 1 - i ? e : l + e);

            string forma = Logica.DibujarForma(tam, tam, " ", ladrillo, Logica.ObtenerBloquePiramide2);

            MostrarForma(forma);
        }

        static void MostrarForma(int ancho, int alto, string espacio, string ladrillo, ObtenerBloqueDelegate ob)
        {
            MostrarForma(Logica.DibujarForma(ancho, alto, espacio, ladrillo, ob));
        }


        static void MostrarForma(string forma)
        {
            Console.Clear();
            //Console.Write(forma); 

            string[] lineas = forma.Split('\n');

            //Console.CursorTop = 0;
            foreach (var linea in lineas)
            {
                //Console.CursorLeft = ancho;
                Console.WriteLine(linea);
            }

            Console.CursorVisible = false;
            Console.ReadKey();
            Console.CursorVisible = !Console.CursorVisible;            
        }

        static void MostrarForma(string forma, int x = 0, int y = 0)
        {
            Console.Clear();
            //Console.Write(forma); 

            string[] lineas = forma.Split('\n');

            Console.CursorTop = y;
            foreach (var linea in lineas)
            {
                Console.CursorLeft = x;
                Console.WriteLine(linea);
            }

            Console.CursorVisible = false;
            Console.ReadKey();
            Console.CursorVisible = !Console.CursorVisible;
        }
  
    }

    static class Logica
    {
        public static string ObtenerBloquePiramide1(
           int ancho, int alto, int fila, int col, string espacio, string ladrillo)
        {
            return col < ancho - fila ? ladrillo : espacio;
        }

        public static string ObtenerBloquePiramide2(
            int ancho, int alto, int fila, int col, string espacio, string ladrillo)
        {
            return col < ancho - 1 - fila ? espacio : ladrillo + espacio;
        }

        public static string ObtenerBloquePiramide3(
            int ancho, int alto, int fila, int col, string espacio, string ladrillo)
        {
            return col < fila ? espacio : ladrillo;
        }

        public static string DibujarForma(
            int ancho, int alto, string espacio, string bloque,
            ObtenerBloqueDelegate obtenerBloque)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int fila = 0; fila < alto; fila++)
            {
                for (int col = 0; col < ancho; col++)
                    sb.Append(obtenerBloque(ancho, alto, fila, col, espacio, bloque));

                sb.AppendLine();
            }
            return sb.ToString();
        }  

    }
}
