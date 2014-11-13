using System;

namespace Programacion.TiposCompuestos.Ordenacion
{
    delegate void ShowEstadoIntermedioDelegate<T>(T[] items, int minIndex, int ordenandoIndex);

    static class SelecionDirecta
    {
        public static void Ordenar(this int[] items)
        {
            //Poner en cada posicion i el valor que corresponde
            for (int i = 0; i < items.Length; i++)
            {
                //Asumir de partida que el valor menor de la parte aun no ordenada
                //del array esta en la primera posicion de la parte aun no ordenada
                int notOrderedLowerValueIndex = i;
                //Recorrer el resto del vector para encontrar otro menor
                for (int j = i + 1; j < items.Length; j++)
                    //Si se encuentra un valor menor en la posicion j
                    if (items[j] < items[notOrderedLowerValueIndex])
                        notOrderedLowerValueIndex = j;  //nueva posicion del mejor j

                //Si el valor de la posicion i no estaba en su sitio
                //porque hemos encontrado en una posicion distinta otro valor aun
                //menor intercambiar las posiciones
                if (i != notOrderedLowerValueIndex)
                {
                    int aux = items[i];
                    items[i] = items[notOrderedLowerValueIndex];
                    items[notOrderedLowerValueIndex] = aux;
                }
            }
        }

        public static void Ordenar<T>(this T[] items) where T : IComparable<T>
        {
            //Poner en cada posicion i el valor que corresponde
            for (int i = 0; i < items.Length; i++)
            {
                //Asumir de partida que el valor menor de la parte aun no ordenada
                //del array esta en la primera posicion de la parte aun no ordenada
                int notOrderedLowerValueIndex = i;
                //Recorrer el resto del vector para encontrar otro menor
                for (int j = i + 1; j < items.Length; j++)
                    //Si se encuentra un valor menor en la posicion j
                    if (items[j].CompareTo(items[notOrderedLowerValueIndex]) < 0)
                        notOrderedLowerValueIndex = j;  //nueva posicion del menor j

                //Si el valor de la posicion i no estaba en su sitio
                //porque hemos encontrado en una posicion distinta otro valor aun
                //menor intercambiar las posiciones
                if (i != notOrderedLowerValueIndex)
                {
                    T aux = items[i];
                    items[i] = items[notOrderedLowerValueIndex];
                    items[notOrderedLowerValueIndex] = aux;
                }
            }
        }

        public static void Ordenar<T>(this T[] items, 
            Action comparacion = null, 
            Action asignacion = null, 
            ShowEstadoIntermedioDelegate<T> show = null)
            where T : IComparable<T>
        {
            //Poner en cada posicion i el valor que corresponde
            for (int i = 0; i < items.Length; i++)
            {
                //Asumir de partida que el valor menor de la parte aun no ordenada
                //del array esta en la primera posicion de la parte aun no ordenada
                int notOrderedLowerValueIndex = i;
                //Recorrer el resto del vector para encontrar otro menor
                for (int j = i + 1; j < items.Length; j++)
                {
                    if (comparacion != null) comparacion();
                    //Si se encuentra un valor menor en la posicion j
                    if (items[j].CompareTo(items[notOrderedLowerValueIndex])<0)
                        notOrderedLowerValueIndex = j;  //nueva posicion del mejor j
                }

                if (show != null) show(items, notOrderedLowerValueIndex, i);
                //Si el valor de la posicion i no estaba en su sitio
                //porque hemos encontrado en una posicion distinta otro valor aun
                //menor intercambiar las posiciones
                if (i != notOrderedLowerValueIndex)
                {
                    if (asignacion != null) asignacion();
                    T aux = items[i];

                    if (asignacion != null) asignacion();
                    items[i] = items[notOrderedLowerValueIndex];

                    if (asignacion != null) asignacion();
                    items[notOrderedLowerValueIndex] = aux;
                }
            }
        }

    }

}
