using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo
{
    class GreaterThanValidator<T> : Validator<T> where T : IComparable<T>
    {
        T lowerValue;
        string errorMessageFormat = "El valor debe ser superior a {0}";

        public GreaterThanValidator(T lowerValue)
        {
            this.lowerValue = lowerValue;
        }

        public GreaterThanValidator(T lowerValue, string errorMessageFormat)
            :this(lowerValue)
        {
            this.errorMessageFormat = errorMessageFormat;
        }

        protected override string GetErrorMessage()
        {
            return string.Format(errorMessageFormat, lowerValue);
        }

        protected override bool PerformValidation(T value)
        {
            return value.CompareTo(this.lowerValue) == 1;
        }
    }
}
