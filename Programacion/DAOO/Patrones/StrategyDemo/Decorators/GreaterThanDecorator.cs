using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Decorators
{
    class GreaterThanDecorator<T> : ValidatorDecorator<T> where T : IComparable<T>
    {
        T minValue;

        public GreaterThanDecorator(IValidator<T> validator, T minimum)
            : base(validator) { this.minValue = minimum; }
     

        protected override string GetErrorMessage()
        {
            return string.Format("El valor es debe ser mayor que {0}", minValue);
        }

        protected override bool Validate(T value)
        {
            return value.CompareTo(minValue) == 1;
        }
    }
}
