using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Funciones.Strings
{
    class StringsDemo
    {
        static void Main()
        {
            CompareTest();
            CompareTestIgnoreCase();
            CompareOrdinalTest();
            CompareTestStringComparisonCurrentCultureIgnoreCase();
            CompareTestStringComparisonTurkishCulture();
            CompareTestStringComparisonGermanCulture();
            Console.ReadKey();
        }

        static void MostrarResultadoComparacion(string izq, string der, int orden)
        {
            if (orden == 0) Console.WriteLine("Las cadenas {0} y {1} son iguales");
            else
            {
                string mayor = orden >0 ? izq : der;
                string menor = orden <0 ? izq : der;

                Console.WriteLine("La cadena {0} es mayor que {1}", mayor, menor);
            }

            Console.WriteLine("{0} {2} {1}",
                izq, der, orden > 0 ? ">" : orden < 0 ? "<" : "=");
            Console.WriteLine();
        }

        static void CompareTest()
        {
            string s1 = "ABCD";
            string s2 = "abcd";

            int orden = String.Compare(s1, s2);

            Console.WriteLine("String.Compare({0}, {1})", s1, s2);
            MostrarResultadoComparacion(s1, s2, orden);
           
        }

        static void CompareTestIgnoreCase()
        {
            string s1 = "ABCD";
            string s2 = "abcd";

            int orden = String.Compare(s1, s2, ignoreCase: true);

            Console.WriteLine("String.Compare({0}, {1}, ignoreCase: true)", s1, s2);
            MostrarResultadoComparacion(s1, s2, orden);         
        }

        static void CompareTestStringComparisonCurrentCultureIgnoreCase()
        {
            string s1 = "Jose";
            string s2 = "josé";

            int orden = String.Compare(s1, s2, StringComparison.CurrentCultureIgnoreCase);

            Console.WriteLine("String.Compare({0}, {1}, StringComparison.CurrentCultureIgnoreCase)", s1, s2);
            MostrarResultadoComparacion(s1, s2, orden);
        }



        static void CompareTestStringComparisonGermanCulture()
        {
            //http://msdn.microsoft.com/en-us/goglobal/bb896001.aspx

            string s1 = "Müller";
            string s2 = "Muller";



            int orden = String.Compare(s1, s2, System.Globalization.CultureInfo.GetCultureInfo("de-DE"), System.Globalization.CompareOptions.IgnoreCase);

            Console.WriteLine("String.Compare({0}, {1}, StringComparison.CurrentCultureIgnoreCase)", s1, s2);
            MostrarResultadoComparacion(s1, s2, orden);
        }
        static void CompareTestStringComparisonTurkishCulture()
        {
            //http://msdn.microsoft.com/en-us/goglobal/bb896001.aspx
            
            string s1 = "i";
            string s2 = "I";

            var sc = StringComparer.Create(System.Globalization.CultureInfo.GetCultureInfo("tr-TR"), false);
                        
            int orden = sc.Compare(s1,s2); //String.Compare()

            Console.WriteLine("String.Compare({0}, {1}, StringComparison.CurrentCultureIgnoreCase)", s1, s2);
            MostrarResultadoComparacion(s1, s2, orden);
        }

        static void CompareOrdinalTest()
        {
            string s1 = "ABCD";
            string s2 = "abcd";

            int orden = String.CompareOrdinal(s1, s2);
            
            Console.WriteLine("String.CompareOrdinal({0}, {1})", s1, s2);
            MostrarResultadoComparacion(s1, s2, orden);           

        }


    }
}
