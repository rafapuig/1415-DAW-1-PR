using System;

namespace MisProgramas
{
    class ConvertTest
    {
        /// <summary>
        /// Para probar la clase Convert
        /// Los numeros introduccidos por teclado usan el punto como separado de miles 
        /// y la coma como separador decimal
        /// Si la entrada no tiene el formato correcto se lanza una excepcion del tipo FormatException
        /// </summary>
        static void Main()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;

            Console.Title = "Demo de Convert";

            Console.WriteLine("Culture name: {0}", culture.Name);
            Console.WriteLine("Number Decimal Separator: {0}", culture.NumberFormat.NumberDecimalSeparator);

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";

            culture = new System.Globalization.CultureInfo("en-US", false);           

            Console.WriteLine("Dame un numero:");
            string inputText = Console.ReadLine();
            
            double number; // = Convert.ToDouble(inputText);           
            number = Double.Parse(inputText, provider);

            Console.WriteLine("El numero introducido es: {0}", number); 
            Console.ReadKey();
        }
    }
}
