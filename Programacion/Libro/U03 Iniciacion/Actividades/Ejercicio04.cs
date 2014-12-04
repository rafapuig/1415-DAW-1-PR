using System;

namespace Programacion.Iniciacion.Actividades
{
    /// <summary>
    /// Realizar un programa que pida al usuario su nombre y dos apellidos
    /// Una vez los haya introducido devera mostrarlos nombre tab apellido1 tab apellido2
    /// </summary>
    static class Ejercicio04
    {
        static void Main()
        {
            Console.Write("Introduce tu nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Introduce tu primer apellido: ");
            string primerApellido = Console.ReadLine();

            Console.Write("Introduce tu segundo apellido: ");
            string segundoApellido = Console.ReadLine();

            Console.WriteLine("{0}\t{1}\t{2}", nombre, primerApellido, segundoApellido);
        }
    }
}
