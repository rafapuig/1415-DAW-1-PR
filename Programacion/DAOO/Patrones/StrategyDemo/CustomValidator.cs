using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo
{
    class CustomValidator<T> : Validator<T>
    {
        Predicate<T> validate;
        string errorMessage;

        public CustomValidator(Predicate<T> validate, string errorMessage = null)
        {
            this.validate = validate;
            this.errorMessage = errorMessage ?? "El valor introducido no es valido";
        }

        protected override string GetErrorMessage()
        {
            return this.errorMessage;
        }

        protected override bool PerformValidation(T value)
        {
            return validate != null ? validate(value) : true;
        }
    }
}
