using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Strings
{
    class MinimumLengthValidator : IValidator<string>
    {
        int minimunLength;

        public MinimumLengthValidator(int minLength)
        {
            this.minimunLength = minLength;
        }

        public ValidationResult<string> Validate(string text)
        {
            ValidationResult<string> result = new ValidationResult<string>();

            if (!(result.IsValid = PerformValidation(text)))
            {
                result.ErrorMessage = GetErrorMessage();
            }
            return result;
        }

        protected string GetErrorMessage()
        {
            return string.Format("El texto debe tener una longitud minima de {0} caracteres", minimunLength);
        }

        protected bool PerformValidation(string text)
        {
            return text.Length >= this.minimunLength;
        }

    }
}
