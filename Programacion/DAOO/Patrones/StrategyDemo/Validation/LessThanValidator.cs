using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Validation
{
    class LessThanValidator<T> : IValidator<T, T> where T : IComparable<T>
    {
        T maxValue;

        public ValidationResult<T> Validate(T input)
        {
            ValidationResult<T> result = new ValidationResult<T>();

            if (!(result.IsValid = (result.Value.CompareTo(maxValue) == -1)))
            {
                result.ErrorMessage = string.Format("No valido {0}", maxValue);
            }
            return result;
        }
    }
}
