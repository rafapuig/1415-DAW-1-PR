using System;

namespace Programacion.TiposCompuestos.Ejemplos
{    
    static class AleatoriosDemo
    {
        static Random alea = new Random();  //Objeto generador de numeros aleatorios      
        
        const int TotalNumeros = 49;    //Total de numeros que entran en la bolsa
        static int Quedan;  //Indica la cantidad de numeros que quedan en la bolsa
        static int[] Bolsa; //Array donde se almacenan los numeros generados

        //Constructor estatico, se ejecuta automaticamente antes de ningun otro metodo
        static AleatoriosDemo()
        {
            GenerarNumeros(out Bolsa, TotalNumeros);
            Quedan = Bolsa.Length;
        }

        static void GenerarNumeros(out int[] bolsa, int total)
        {
            bolsa = new int[total];

            for (int i = 0; i < bolsa.Length; i++)
            {
                bolsa[i] = i + 1;
            }
        }
        
        static void ReintroducirNumerosBolsa()
        {
            Quedan = TotalNumeros;
        }

        static int ExtraerNumero(this int[] bolsa)
        {
            if (Quedan == 0)
                throw new InvalidOperationException("No quedan numeros en la bolsa");

            int pos = alea.Next(Quedan);
            int valor = bolsa[pos];

            //Intercambiar posiciones entre el valor que sale y el ultimo
            int temp = bolsa[pos];
            bolsa[pos] = bolsa[Quedan - 1];
            bolsa[Quedan - 1] = temp;

            Quedan--;
            return valor;
        }



        static void Main()
        {
            Console.Title = "Segundo ejemplo de numeros aleatorios con arrays";
          
            int sorteos = 10;
            for (int n = 1; n <= sorteos; n++)
            {
                Console.Write("Sorteo nº {0,2}: ", n);
                ReintroducirNumerosBolsa();                
                RealizarSorteo(Bolsa, 6);
            }
            Console.ReadKey();
        }            

        static void RealizarSorteo(int[] bolsa, int extracciones)
        {            
            for (int i = 0; i < extracciones; i++)
            {
                int numero = bolsa.ExtraerNumero();
                Console.Write("{0,2}{1}", numero, i < extracciones - 1 ? ", " : "\n");
            }
        }

    }
}
