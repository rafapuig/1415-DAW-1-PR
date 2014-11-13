using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Ordenacion
{
    static class InsercionDirecta
    {

        public static void Ordenar(this int[] items)
        {
            for (int i = 1; i < items.Length; i++)
            {
                int j = i;
                int aux = items[i];
                while (j > 0 && aux < items[j - 1])
                {
                    items[j] = items[j - 1];
                    j--;
                }
                items[j] = aux;
            }
        }

        public static void Ordenar<T>(this T[] items) where T : System.IComparable<T>
        {
            for (int i = 1; i < items.Length; i++)
            {
                int j = i;
                T aux = items[i];
                while (j > 0 && aux.CompareTo(items[j - 1]) < 0)
                {
                    items[j] = items[j - 1];
                    j--;
                }
                items[j] = aux;
            }
        }

        public static void Ordenar<T>(this T[] items,
            Action comparacion = null,
            Action asignacion = null)
            where T : System.IComparable<T>
        {
            for (int i = 1; i < items.Length; i++)
            {
                int j = i;

                if (asignacion != null) asignacion();
                T aux = items[i];

                while (j > 0 && aux.CompareTo(items[j - 1]) < 0)
                {
                    if (comparacion != null) comparacion();

                    if (asignacion != null) asignacion();
                    items[j] = items[j - 1];
                    
                    j--;
                }

                if (asignacion != null) asignacion();
                items[j] = aux;
            }
        }

    }
}
