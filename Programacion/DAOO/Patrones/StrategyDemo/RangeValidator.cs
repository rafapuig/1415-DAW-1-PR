using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo
{
    class RangeValidator<T> : Validator<T> where T : IComparable<T>
    {
        T lowerBound;
        T upperBound;
        string errorMessage = null;

        public RangeValidator(T lower, T upper)
        {
            this.lowerBound = lower;
            this.upperBound = upper;
        }

        public RangeValidator(T lower, T upper, string errorMessage)
            : this(lower, upper)
        {
            this.errorMessage = errorMessage;
        }

        protected override string GetErrorMessage()
        {
            string message = errorMessage ?? "El valor deber estar entre {0} y {1}";
            return string.Format(message, lowerBound, upperBound);
        }

        protected override bool PerformValidation(T value)
        {
            if (value.CompareTo(lowerBound) < 0) return false;    //If value < lower bound
            if (value.CompareTo(upperBound) > 0) return false;     //If value > upper bound
            return true;
        }
    }
}
