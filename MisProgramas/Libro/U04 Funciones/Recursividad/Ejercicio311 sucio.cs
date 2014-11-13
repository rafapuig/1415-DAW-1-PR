using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Programacion.Iniciacion.Actividades.Revisiones.Ejercicio11
{
    static class Ejercicio11
    {
        static void Main()
        {
            int numero;
            string entrada;
            bool esNumero;
            Console.WriteLine("Escribe un numero: ");
            while (!(esNumero = Int32.TryParse(entrada = Console.ReadLine(), out numero)) || numero < 0)
            {
                Console.Write("La entrada {0} no es correcta. ");
                if (!esNumero) Console.WriteLine("No se puede convertir a numero.");
                else if (numero < 0) Console.WriteLine("El numero es menor que 0.");
            }

            RecorrerCifras(numero);

            //MostrarCifras(numero);
            Console.ReadKey();
        }


        static void MostrarCifras(int numero)
        {
            foreach (int cifra in Cifras(numero))
            {
                Console.Write("{0}-", cifra);
            }
            Console.CursorLeft -= 1;
            Console.WriteLine(" ");

            CifraMasAlta(numero, numero, MostrarCifra);
        }

        static void MostrarCifra(int cifra, bool ultima)
        {
            Console.Write("{0}{1}", cifra, !ultima ? "-" : "");
        }


        //static void CifraMasAlta(int cifra, int cifras, int pot = 1)
        //{
        //    if (cifra < 10)
        //    {
        //        Console.Write("{0}{1}", cifra, pot == 1 ? "" : "-");
        //        cifras = cifras - cifra * pot;
        //        if (cifras > 0) CifraMasAlta(cifras, cifras, 1);
        //    }
        //    else
        //    {
        //        CifraMasAlta(cifra / 10, cifras, pot *= 10);
        //    }
        //}

        static void CifraMasAlta(int cifra, int cifras, Action<int, bool> accion, int pot = 1)
        {
            if (cifra < 10)
            {
                //Console.Write("{0}{1}", cifra, pot == 1 ? "" : "-");
                //yield return cifra;
                accion(cifra, pot == 1);
                cifras = cifras - cifra * pot;
                while (cifras < (pot /= 10)) accion(0, pot == 1);
                if (cifras > 0) CifraMasAlta(cifras, cifras, accion, 1);
                else if (pot >= 10) CifraMasAlta(0, 0, accion, pot / 10);
            }
            else
            {
                CifraMasAlta(cifra / 10, cifras, accion, pot *= 10);
            }
        }

        static IEnumerable<int> Cifras(int numero)
        {
            int cifra;  //Al final del bucle interno tendrá la cifra correspondiente a la iteracion actual
            int restoCifras = numero;    //Al final del bucle interno contiene el numero restando las cifras procesadas
            int potencia = 1;
            
            while (restoCifras >= 10)
            {
                cifra = restoCifras;
                potencia = 1;
                while (cifra >= 10)
                {
                    cifra = cifra / 10;
                    potencia *= 10;
                }
                //Console.Write("{0}-", cifra);
                yield return cifra;
                restoCifras -= cifra * potencia;
                while (restoCifras < (potencia /= 10)) yield return 0;
            }
            yield return restoCifras;
            
            while (potencia > 10)
            {
                potencia /= 10;
                yield return 0;
            }
        }


        static void RecorrerCifras(int num)
        {
            int potencia = 0;
            int cifra = GetCifraMasSignificativaRecursivo(num, ref potencia);
            for (int i = potencia; i >= 0; i--)
            {
                cifra = (int)(num / Math.Pow(10, i)) % 10;
                MostrarCifra(cifra, i == 0);
            }
        }

        static void RecorrerCifrasv2(int num)
        {
            int potencia = 0;
            int cifra = GetCifraMasSignificativaRecursivo(num, ref potencia);
            for (int i = potencia; i >= 0; i--)
            {
                cifra = (int)(num / Math.Pow(10, i)) % 10;
                MostrarCifra(cifra, i == 0);
            }
        }

       
        static int GetPotencia10CifraMasSignificativa(int num)
        {
            int contador = 0;
            
            while (num > 10)
            {
                num /= 10;
                contador++;
            }

            //for (contador = 0; num > 10; contador++) num /= 10;

            return contador;   
        }

        static int GetPotenciaCifraMasSignificativaRecursivo(int num, int pot = 1)
        {
            if (num < 10) return 0;
            else 
                return GetPotenciaCifraMasSignificativaRecursivo(num / 10, pot *= 10);                    
        } 

        static int GetCifraMasSignificativaRecursivo(int num, ref int potencia10)
        {
            if (num < 10) return num;
            else
            {
                potencia10++;
                return GetCifraMasSignificativaRecursivo(num / 10, ref potencia10);
            }
        }    
    }

    //static class IntHelper
    //{
    //    class IntCifrasEnumerator : IEnumerator<int>
    //    {
    //        int cifras;
    //        int cifra;
    //        int pot = 1;

    //        IntCifrasEnumerator(int numero)
    //        {
    //            cifra = cifras = numero;
    //        }

    //        public int Current
    //        {
    //            get { throw new NotImplementedException(); }
    //        }

    //        public void Dispose()
    //        {
    //            throw new NotImplementedException();
    //        }

    //        object System.Collections.IEnumerator.Current
    //        {
    //            get { throw new NotImplementedException(); }
    //        }

    //        public bool MoveNext()
    //        {
    //            int cifra = cma(cifras);
                
    //        }

    //        public void Reset()
    //        {
    //            throw new NotImplementedException();
    //        }

    //        int cma(int num, ref int pot)
    //        {
    //            if (num < 10) return num;
    //            else
    //            {
    //                pot = pot * 10;
    //                return cma(num / 10, ref pot);
    //            }
    //        }


    //        void CifraMasAlta(int cifra, int cifras, Action<int> accion, int pot = 1)
    //        {
    //            if (cifra < 10)
    //            {
    //                //Console.Write("{0}{1}", cifra, pot == 1 ? "" : "-");
    //                //yield return cifra;
    //                accion(cifra);
    //                cifras = cifras - cifra * pot;
    //                if (cifras > 0) CifraMasAlta(cifras, cifras, accion, 1);
    //            }
    //            else
    //            {
    //                CifraMasAlta(cifra / 10, cifras, accion, pot *= 10);
    //            }
    //        } 

    //    }
    //}
    
}
