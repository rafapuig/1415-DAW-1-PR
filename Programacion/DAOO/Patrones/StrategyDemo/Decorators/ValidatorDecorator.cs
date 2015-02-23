using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Decorators
{
    class ValidatorDecorator<T> : IValidator<T>
    {
        protected IValidator<T> validator;

        public ValidatorDecorator(IValidator<T> validator)
        {
            this.validator = validator;
        }

        public virtual ValidationResult<T> Validate(string text)
        {
            ValidationResult<T> result = this.validator.Validate(text);

            if (!result.IsValid) return result;

            if (!(result.IsValid = Validate(result.Value)))
            {
                result.ErrorMessage = GetErrorMessage();
            }
            return result;
        }

        protected virtual string GetErrorMessage()
        {
            return "Valor introducido no valido";
        }

        protected virtual bool Validate(T value)
        {
            return true;
        }

    }
}
