using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Decorators
{
    class LessThanDecorator<T> : ValidatorDecorator<T> where T:IComparable<T>
    {
        T maxValue;

        public LessThanDecorator(IValidator<T> validator, T maximum)
            : base(validator) { this.maxValue = maximum; }


        protected override string GetErrorMessage()
        {
            return string.Format("El valor es debe ser menor que {0}", maxValue);
        }

        protected override bool Validate(T value)
        {
            return value.CompareTo(maxValue) == -1;
        }
    }
}
