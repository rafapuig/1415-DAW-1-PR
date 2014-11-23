using System;

namespace Programacion.TiposCompuestos.Ejemplos
{    
    class Bolsa
    {
        static Random alea = new Random();  //Objeto generador de numeros aleatorios      

        int totalNumeros; //Total de numeros que entran en la bolsa 
        public int TotalNumeros
        {
            get { return totalNumeros; }
        }
        
        int quedan;  //Indica la cantidad de numeros que quedan en la bolsa
        public int Quedan
        {
            get { return quedan; }
            private set { quedan = value; }
        }

        int[] bolsa; //Array donde se almacenan los numeros generados
        
        //Constructor de bolsas
        public Bolsa(int totalNumeros)
        {
            this.totalNumeros = totalNumeros;            
            GenerarNumeros();
            quedan = bolsa.Length;
        }

        private void GenerarNumeros()
        {
            bolsa = new int[this.TotalNumeros];

            for (int i = 0; i < bolsa.Length; i++)
            {
                bolsa[i] = i + 1;
            }
        }
                             
        public void ReintroducirNumeros()
        {
            Quedan = bolsa.Length;
        }

        public int ExtraerNumero()
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
    }

    static class BolsaDemo
    {
        static void Main()
        {
            Console.Title = "Segundo ejemplo de numeros aleatorios con arrays";

            Bolsa bolsa = new Bolsa(49);            

            int sorteos = 10;
            for (int n = 1; n <= sorteos; n++)
            {
                Console.Write("Sorteo nº {0,2}: ", n);
                bolsa.ReintroducirNumeros();
                RealizarSorteo(bolsa, 6);
            }
            Console.ReadKey();
        }
        
        static void RealizarSorteo(Bolsa bolsa, int extracciones)
        {
            for (int i = 0; i < extracciones; i++)
            {
                int numero = bolsa.ExtraerNumero();
                Console.Write("{0,2}{1}", numero, i < extracciones - 1 ? ", " : "\n");
            }
        }  
    }
}
