using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo
{
    class CompositeValidator<T> : IValidator<T>
    {
        List<IValidator<T>> validators = new List<IValidator<T>>();

        public CompositeValidator() { }

        public CompositeValidator(params IValidator<T>[] validators)
        {
            foreach(var validator in validators)
            {
                AddValidator(validator);
            }
        }

        public void AddValidator(IValidator<T> validator)
        {
            validators.Add(validator);
        }

        public ValidationResult<T> Validate(string text)
        {
            ValidationResult<T> result = null;

            foreach(var validator in validators)
            {
                result = validator.Validate(text);
                if (!result.IsValid) break;                    
            }
            
            return result;
        }
    }
}
