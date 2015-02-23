using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Decorators
{
    class LambdaDecorator<T> : ValidatorDecorator<T>
    {
        Predicate<T> validate;

        string errorMessage = null;

        public LambdaDecorator(IValidator<T> validator, Predicate<T> validate, string errorMessage = null)
            : base(validator)
        {
            this.validate = validate;
            this.errorMessage = errorMessage;
        }

        protected override string GetErrorMessage()
        {
            return (errorMessage != null) ? this.errorMessage : base.GetErrorMessage();
        }

        protected override bool Validate(T value)
        {
            return validate != null ? validate(value) : true;
        }
    }
    
}
