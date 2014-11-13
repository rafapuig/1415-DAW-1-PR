using System;

namespace Programacion.Iniciacion.Actividades.Revision.Ejercicio13.StringBuilder
{
    delegate string ObtenerBloqueDelegate(
        int tam, int fila, int col, string bloque1, string bloque2);

    /// <summary>
    /// Revision del ejercicio 13 del tema 3
    /// Usando un delegado que contiene la estrategia para decidir si el la fila i y columna j
    /// Se escribe un espacio o un ladrillo
    /// </summary>
    static class Ejercicio13
    {
        static void Main()
        {
            Console.Title = "Dibujar Formas";
            int opcion;
            do
            {
                opcion = MostrarMenu();

                switch (opcion)
                {
                    case 1:
                        MostrarForma(ObtenerBloquePiramide1);
                        break;
                    case 2:
                        MostrarForma(ObtenerBloquePiramide2);
                        break;
                    case 3:
                        MostrarForma(ObtenerBloquePiramide3);
                        break;
                    case 5: 
                        MostrarForma(
                            (t, i, j, e, l) => 
                                i == 0 || i == t - 1 || j == 0 || j == t - 1 ? l : e);
                        break;
                }

            } while (opcion != 4);
        }
        static int MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Elige el dibujo: ");
            Console.WriteLine("1. -Dibujo 1");
            Console.WriteLine("2. -Dibujo 2");
            Console.WriteLine("3.- Dibujo 3");
            Console.WriteLine("4.- Salir ");
            return Int32.Parse(Console.ReadLine());
        }
        static int ObtenerTamaño()
        {
            Console.Write("Introduce el tamaño del dibujo: ");
            return Int32.Parse(Console.ReadLine());
        }
        static string ObtenerLadrillo()
        {
            Console.Write("Introduce el caracter ladrillo: ");
            return Console.ReadLine();
        }
        static void MostrarForma(ObtenerBloqueDelegate obtenerBloque)
        {
            string ladrillo = ObtenerLadrillo();
            int tamaño = ObtenerTamaño();

            string forma = DibujarForma(tamaño, " ", ladrillo, obtenerBloque);

            Console.Clear();
            //Console.Write(forma); 

            string[] lineas = forma.Split('\n');
            
            Console.CursorTop = 0;
            foreach (var linea in lineas)
            {
                Console.CursorLeft = tamaño;
                Console.WriteLine(linea);
            }            

            Console.CursorTop = tamaño;
            foreach (var linea in lineas)
            {
                Console.CursorLeft = 0;
                Console.WriteLine(linea);
            }            

            Console.CursorTop = tamaño;
            foreach (var linea in lineas)
            {
                Console.CursorLeft = tamaño * (obtenerBloque == ObtenerBloquePiramide2 ? 2 : 1);
                Console.WriteLine(linea);
            }

            Console.ReadKey();
        }


        static string ObtenerBloquePiramide1(
            int tam, int fila, int col, string espacio, string ladrillo)
        {
            return col < tam - fila ? ladrillo : espacio;
        }

        static string ObtenerBloquePiramide2(
            int tam, int fila, int col, string espacio, string ladrillo)
        {
            return col < tam - 1 - fila ? espacio : ladrillo + espacio;
        }

        static string ObtenerBloquePiramide3(
            int tam, int fila, int col, string espacio, string ladrillo)
        {
            return col < fila ? espacio : ladrillo;
        }
        
        static string DibujarForma(
            int tam, string espacio, string bloque,
            ObtenerBloqueDelegate obtenerBloque)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int fila = 0; fila < tam; fila++)
            {
                for (int col = 0; col < tam; col++)
                    sb.Append(obtenerBloque(tam, fila, col, espacio, bloque));

                sb.AppendLine();
            }
            return sb.ToString();
        }  

    }
}
