using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Decorators
{
    class RangeValidator<T> : IValidator<T> where T : IComparable<T>
    {
        IValidator<T> validator;

        public RangeValidator(T minValue, T maxValue)
        {
            validator = new ParseValidator<T>();
            //validator = new GreaterThanDecorator<T>(validator, minValue);
            //validator = new LessThanDecorator<T>(validator, maxValue); 
            validator = new LambdaDecorator<T>(validator,
                x => x.CompareTo(minValue) >= 0,
                string.Format("El valor es debe ser mayor o igual que {0}", minValue));
            
            validator = new LambdaDecorator<T>(validator,
                x => x.CompareTo(maxValue) <= 0,
                string.Format("El valor es debe ser menor o igual que {0}", maxValue));
        }

        public ValidationResult<T> Validate(string text)
        {
            return this.validator.Validate(text);
        }
    }
}
