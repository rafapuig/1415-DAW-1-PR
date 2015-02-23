using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Decorators
{
    class LessThanValidator<T> : IValidator<T> where T : IComparable<T>
    {
        IValidator<T> validator;

        public LessThanValidator(T maxValue)
        {
            validator = new ParseValidator<T>();
            validator = new LessThanDecorator<T>(validator, maxValue);
        }

        public ValidationResult<T> Validate(string text)
        {
            return this.validator.Validate(text);
        }
    }
}
