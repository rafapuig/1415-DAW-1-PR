using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Validation
{
    interface IValidator<T, in TSource>
    {
        ValidationResult<T> Validate(TSource input);
    }

    abstract class Validator<T> : IValidator<T, string>
    {
        public abstract ValidationResult<T> Validate(string input);
    }
}
