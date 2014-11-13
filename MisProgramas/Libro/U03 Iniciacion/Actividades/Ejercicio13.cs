using System;

namespace Programacion.Iniciacion.Actividades
{
    static class Ejercicio13
    {
        static void Main()
        {            
            int opcion;
            do
            {                
                opcion = MostrarMenu();

                if (opcion != 4)
                {
                    int tamaño = ObtenerTamaño();
                    
                    switch (opcion)
                    {
                        case 1:
                            Piramide1(tamaño);
                            break;
                        case 2:
                            Piramide2(tamaño);
                            break;
                        case 3:
                            Piramide3(tamaño);
                            break;
                    }
                }
                
            } while (opcion != 4);
        }
         
        static int MostrarMenu()
        {
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
        
        static void Piramide1(int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam - i; j++)               
                    Console.Write("@");
                
                Console.WriteLine();
            }
        }
        static void Piramide1v2(int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                    if (j < tam - i)
                        Console.Write("@");

                Console.WriteLine();
            }
        }
        static void Piramide1v3(int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                    Console.Write(j < tam - i ? "@" : " ");

                Console.WriteLine();
            }
        }

        static void Piramide2(int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam - 1 - i; j++)
                    Console.Write(" ");

                for (int j = 0; j < i + 1; j++)
                    Console.Write("@ ");

                Console.WriteLine();
            }
        }
        static void Piramide2v2(int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                    if (j < tam - 1 - i)
                        Console.Write(" ");
                    else
                        Console.Write("@ ");

                Console.WriteLine();
            }
        }
        static void Piramide2v3(int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                    Console.Write(j < tam - 1 - i ? " " : "@ ");
                Console.WriteLine();
            }
        }
        
        static void Piramide3(int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < i; j++)
                    Console.Write(" ");

                for (int j = 0; j < tam - i; j++)
                    Console.Write("@");

                Console.WriteLine();
            }
        }
        static void Piramide3v2(int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    if (j < i)
                        Console.Write(" ");
                    else
                        Console.Write("@");
                }
                Console.WriteLine();
            }
        }
        static void Piramide3v3(int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                    Console.Write(j < i ? " " : "@");

                Console.WriteLine();
            }
        }                     
    }
}
