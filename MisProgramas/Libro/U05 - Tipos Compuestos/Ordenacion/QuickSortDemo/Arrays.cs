using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Ordenacion
{
    delegate void MostrarOrdenacionQuickSort<T>(T[] items, int central, int primero, int ultimo, int i, int j);

    static class Arrays
    {
        public static void QuickSort<T>(this T[] items, int primero, int ultimo,
            Action comparacion = null, 
            Action asignacion = null, 
            MostrarOrdenacionQuickSort<T> show = null)
            where T:System.IComparable<T>
        {
            int central = (primero + ultimo) / 2;
            T pivote = items[central];

            int i = primero;
            int j = ultimo;

            do
            {
                if (comparacion != null) comparacion();
                while (items[i].CompareTo( pivote) <0) i++;

                if (comparacion != null) comparacion();
                while (items[j].CompareTo(pivote)>0) j--;

                if (show != null) show(items, central, primero, ultimo, i, j);

                if (i <= j)
                {

                    T temp = items[i]; if (asignacion != null) asignacion();
                    items[i] = items[j]; if (asignacion != null) asignacion();
                    items[j] = temp; if (asignacion != null) asignacion();
                    i++;
                    j--;
                }

            } while (i <= j);

            if (primero < j) QuickSort(items, primero, j, comparacion, asignacion, show);
            if (i < ultimo) QuickSort(items, i, ultimo, comparacion, asignacion, show);
        }
    }

}
