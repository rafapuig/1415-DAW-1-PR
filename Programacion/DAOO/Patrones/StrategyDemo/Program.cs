using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestInt32CastValidator();
            //TestParseValidator();
            //TestDefaultValidation();
            //TestGreaterThanValidator();            
            //TestRangeValidator();
            //TestCustomValidator();
            //TestCompositeValidator();
            //TestLessThanValidatorDecorator();  
            //TestDecoratorValidator();
            //TestGetValidatedInputFromPredicate();
            //TestGetValidatedInputFromPredicates();

            //IValidator<int> validator = new RangeValidator(1, 100, "Experimentos entre <minValue> y <maxValue>");
            //int numero = GetNumber("Cuantas veces quieres repetir el experimento: ", validator);
            //Console.WriteLine("El numero es: {0}", numero);
            
            Console.ReadKey();
        }

        static void TestInt32CastValidator()
        {
            IValidator<int> validator = new Integer.Int32ParseValidator();

            int numero = GetValidatedInt32("Introduce un numero entero", validator);

            Console.WriteLine("El numero es: {0}", numero);            
        }

        static void TestParseValidator()
        {
            IValidator<double> validator = new ParseValidator<double>();

            double numero = ConsoleExt.GetValidatedInput("Introduce un numero double", validator);

            Console.WriteLine("El numero es: {0}", numero);
        }
        
        static void TestDefaultValidation()
        { 
            string message = string.Format("Introduce un numero entero");

            int numero = ConsoleExt.GetValidatedInput<int>(message);

            Console.WriteLine("El numero es: {0}", numero);
        }
        
        static void TestGreaterThanValidator()
        {
            double minimo = 1000.0;

            IValidator<double> validator = new GreaterThanValidator<double>(minimo, "El valor no supera {0}");

            string message = string.Format("Introduce un numero double mayor que {0}", minimo);

            double numero = ConsoleExt.GetValidatedInput(message, validator);

            Console.WriteLine("El numero es: {0}", numero);
        }
        
        static void TestRangeValidator()
        {
            int minimo = 0;
            int maximo = 100;

            IValidator<int> validator = new RangeValidator<int>(0, 100);

            string message = string.Format("Introduce un numero entre {0} y {1}", minimo, maximo);

            double numero = ConsoleExt.GetValidatedInput(message, validator);

            Console.WriteLine("El numero es: {0}", numero);
        }

        static void TestCustomValidator()
        {
            int minimo = 0;
            int maximo = 100;

            IValidator<int> validator = new CustomValidator<int>(
                x => x >= minimo && x <= maximo,
                string.Format("El valor debe estar comprendido entre {0} {1}", minimo, maximo));

            string message = string.Format("Introduce un numero entre {0} y {1}", minimo, maximo);

            double numero = ConsoleExt.GetValidatedInput(message, validator);

            Console.WriteLine("El numero es: {0}", numero);
        }

        static void TestCompositeValidator()
        {
            IValidator<string> maxLength = new StrategyDemo.Strings.MaximumLengthValidator(8);
            IValidator<string> minLength = new StrategyDemo.Strings.MinimumLengthValidator(5);

            IValidator<string> rangeValidator = new CompositeValidator<string>(minLength, maxLength);

            string text = ConsoleExt.GetValidatedInput("Texto entre 5 y 8 caracteres", rangeValidator);

            Console.WriteLine("Texto: {0}", text);
        }

       

        static void TestLessThanValidatorDecorator()
        {
            double maximo = 1000.0;

            IValidator<double> validator = new StrategyDemo.Decorators.LessThanValidator<double>(maximo);

            string message = string.Format("Introduce un numero double menor que {0}", maximo);

            double numero = ConsoleExt.GetValidatedInput(message, validator);

            Console.WriteLine("El numero es: {0}", numero);
        }

        static void TestDecoratorValidator()
        {
            double minimo = 500.0;
            double maximo = 1000.0;

            IValidator<double> validator = new StrategyDemo.Decorators.RangeValidator<double>(minimo, maximo);

            string message = string.Format("Introduce un numero double entre {0} y {1}", minimo, maximo);

            double numero = ConsoleExt.GetValidatedInput(message, validator);

            Console.WriteLine("El numero es: {0}", numero);
        }


        static void TestGetValidatedInputFromPredicate()
        {
            int minimo = 0;
            int maximo = 100;

            string message = string.Format("Introduce un numero entre {0} y {1}", minimo, maximo);

            int numero = ConsoleExt.GetValidatedInput(message,
                (int x) => x >= minimo && x <= maximo,
                string.Format("El valor introducido debe estar entre {0} y {1}", minimo, maximo));

            Console.WriteLine("El numero es: {0}", numero);
        }

        static void TestGetValidatedInputFromPredicates()
        {
            int num;
            int min = 50;
            int max = 100;

            num = ConsoleExt.GetValidatedInput<int>(
                   string.Format("Introduce un numero mayor que {0} y menor que {1}", min, max),
                   new Predicate<int>[] { 
                       (int x) => x >= min, 
                       (int x) => x <= max 
                   },
                   new[] { 
                       string.Format("El valor tiene que ser mayor o igual que {0}", min), 
                       string.Format("El valor tiene que ser menor o igual que {0}", max)
                   });

            Console.WriteLine("El numero es {0}", num);

        }



        static int GetValidatedInt32(string askMessage, IValidator<int> validator)
        {          
            ValidationResult<int> result = null;

            Console.WriteLine(askMessage);

            //while (!(result = validator.Validate(Console.ReadLine())).ValidationOk)
            //{
            //    Console.WriteLine(result.Message);
            //    Console.WriteLine("Intentalo de nuevo.");
            //}

            do
            {
                result = validator.Validate(Console.ReadLine());

                if (!result.IsValid)
                {
                    Console.WriteLine(result.ErrorMessage);
                    Console.WriteLine("Intentalo de nuevo.");
                }

            } while (!result.IsValid);        

            return result.Value;
        }

        

        //static T GetValidatedInput<T>(string askMessage, Predicate<T> validator)
        //{
        //    ValidationResult<T> result = null;

        //    Console.WriteLine(askMessage);

        //    do
        //    {
        //        result = validator.Validate(Console.ReadLine());

        //        if (!result.ValidationOk)
        //        {
        //            Console.WriteLine(result.Message);
        //            Console.WriteLine("Intentalo de nuevo.");
        //        }

        //    } while (!result.ValidationOk);

        //    return result.Value;
        //}


    }
}
