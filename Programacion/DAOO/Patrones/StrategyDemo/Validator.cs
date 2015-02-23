using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo
{
    abstract class Validator<T> : IValidator<T>
    {        

        public ValidationResult<T> Validate(string text)
        {
            //ValidationResult<T> result = null;

            //if (typeof(T) != typeof(string))
            //{
            //    ParseValidator<T> parseValidator = new ParseValidator<T>();
            //    result = parseValidator.Validate(text);
            //}
            //else
            //{
            //    result = new ValidationResult<T>();
            //    result.Value = (T)(object)text;
            //    result.ValidationOk = true;
            //}

            ParseValidator<T> parseValidator = new ParseValidator<T>();
            ValidationResult<T> result = parseValidator.Validate(text);
           

            if (result.IsValid)
            {
                if (!(result.IsValid = PerformValidation(result.Value)))
              
                    result.ErrorMessage = this.GetErrorMessage();               
            }
            return result;
        }

        protected abstract string GetErrorMessage();


        protected abstract bool PerformValidation(T value);

    }
}
