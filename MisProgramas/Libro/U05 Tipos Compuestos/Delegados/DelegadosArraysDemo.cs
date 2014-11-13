using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Delegados
{
    delegate bool Condicion(int dato);
    delegate void Accion(int dato);
    class DelegadosArraysDemo
    {

        static void Main()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            RecorrerArrayYAccion(nums, 
                i => i % 2 == 0, 
                i => Console.WriteLine("Elemento Par encontrado {0}", i)
                );

            int suma = 0;
            RecorrerArrayYAccion(nums,
                i => i % 2 == 0,
                i => suma = suma + i
                );

            Console.WriteLine("La suma de los numeros pares es igual a {0}", suma);

            Console.ReadKey();

        }

        static void RecorrerArrayYAccion(int[] elems, Condicion condicion, Accion accion)
        {
            foreach (int item in elems)
            {
                if (condicion(item))
                    accion(item);
            }
        }

        static void RecorrerArrayYAccion(int[] elems, ref int result, Condicion condicion)
        {
            result = 0;
            foreach (int item in elems)
            {
                if (condicion(item))
                    result = result + item;
            } 
        }

        static void RecorrerArrayYSumarSiImpar(int[] elems, ref int result)
        {
            foreach(int item in elems)
            {
                if(item % 2 == 0)
                    result += item;
            }
        }

    }
}
