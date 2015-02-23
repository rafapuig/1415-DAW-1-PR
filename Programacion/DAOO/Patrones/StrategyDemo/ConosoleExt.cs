using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo
{
    static class ConsoleExt
    {
        public static T GetValidatedInput<T>(string askMessage, IValidator<T> validator = null)
        {
            ValidationResult<T> result = null;

            validator = validator ?? new ParseValidator<T>();   //Si no se indica validador entonces utilizar un de Parsing (default strategy)

            Console.WriteLine(askMessage);

            while (!(result = validator.Validate(Console.ReadLine())).IsValid)
            {
                Console.WriteLine(result.ErrorMessage);
                Console.WriteLine("Intentalo de nuevo.");
            }

            //do
            //{
            //    string input = Console.ReadLine();
            //    result = validator.Validate(input);

            //    if (!result.IsValid)
            //    {
            //        Console.WriteLine(result.ErrorMessage);
            //        Console.WriteLine("Intentalo de nuevo.");
            //    }

            //} while (!result.IsValid);

            return result.Value;
        }

        public static T GetValidatedInput<T>(string askMessage, Predicate<T> validate, string errorMessage = null)
        {
            IValidator<T> validator = new CustomValidator<T>(validate, errorMessage);

            return GetValidatedInput(askMessage, validator);
        }

        public static T GetValidatedInput<T>(string askMessage, IEnumerable<Predicate<T>> validates, IEnumerable<string> errorMessages)
        {
            CompositeValidator<T> validator = new CompositeValidator<T>();

            IEnumerator<Predicate<T>> validateEnumerator = validates.AsEnumerable<Predicate<T>>().GetEnumerator();
            IEnumerator<string> errorMsgsEnumerator = errorMessages.AsEnumerable<string>().GetEnumerator();

            if (validates.Count() != errorMessages.Count()) 
                throw new ArgumentException("No coinciden numero de predicados y mensajes");

            while(validateEnumerator.MoveNext())
            {
                errorMsgsEnumerator.MoveNext();
                validator.AddValidator(new CustomValidator<T>(validateEnumerator.Current, errorMsgsEnumerator.Current));
            }           

            return GetValidatedInput(askMessage, validator);
        }

        public static int GetInt32Validated(string askMessage, Predicate<int> validate)
        {
            
            ValidationResult<int> result;
            IValidator<int> parseValidator = new ParseValidator<int>();
            
            do
            {
                result = parseValidator.Validate(Console.ReadLine());

                if (result.IsValid)
                {
                    if (!(result.IsValid = validate(result.Value)))
                    {
                        result.ErrorMessage = "KK";
                    }
                }

                if (!result.IsValid)
                {
                    Console.WriteLine(result.ErrorMessage);
                    Console.WriteLine("Intentalo de nuevo.");
                }

            } while (result.IsValid);

            return result.Value;

            //return GetValidatedInput<int>(askMessage, validator);
        }




    }
}
