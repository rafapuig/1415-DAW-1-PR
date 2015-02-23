using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Integer
{
    class Int32ParseValidator : IValidator<int>
    {
        public virtual ValidationResult<int> Validate(string text)
        {
            int value;
            ValidationResult<int> result = new ValidationResult<int>();

            if (!Int32.TryParse(text, out value))
                result.ErrorMessage = string.Format("El texto <{0}> de la entrada no tiene formato de numero entero.", text);
            else
            {
                result.Value = value;
                result.IsValid = true;
            }

            return result;
        }
    }
}
