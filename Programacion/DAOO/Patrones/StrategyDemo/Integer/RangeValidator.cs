using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo
{
    class RangeValidator : IValidator<Int32>
    {
        int minValue, maxValue;
        string errorMessageFormat = "El numero debe estar entre {0} y {1}";

        public RangeValidator(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public RangeValidator(int minValue, int maxValue, string outOfRangeErrorMessageFormat)
            : this(minValue, maxValue)
        {
            SetErrorMessageFormat(outOfRangeErrorMessageFormat);
        }

        private void SetErrorMessageFormat(string errorMessageFormat)
        {
            errorMessageFormat = errorMessageFormat.Replace("<minValue>", "{0}");
            errorMessageFormat = errorMessageFormat.Replace("<maxValue>", "{1}");
            this.errorMessageFormat = errorMessageFormat;
        }

        public ValidationResult<int> Validate(string text)
        {
            int value;
            ValidationResult<int> result = new ValidationResult<int>();

            if (!Int32.TryParse(text, out value))           
                result.ErrorMessage = string.Format("El texto <{0}> de la entrada no tiene formato de numero entero.", text);           
            else
            {
                result.Value = value;

                if (value >= minValue && value <= maxValue)                
                    result.IsValid = true;                
                else
                    result.ErrorMessage = string.Format(errorMessageFormat, minValue, maxValue);                
            }

            return result;
        }
    }
}
