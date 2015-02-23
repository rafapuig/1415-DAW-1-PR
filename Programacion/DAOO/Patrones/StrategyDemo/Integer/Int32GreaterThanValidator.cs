using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Integer
{
    class Int32GreaterThanValidator : Int32ParseValidator
    {
        int minValue;

        public override ValidationResult<int> Validate(string text)
        {
            ValidationResult<int> result = base.Validate(text);

            if (result.IsValid)
            {
                if (Validate(result.Value))
                    result.IsValid = true;

                else
                    result.ErrorMessage = string.Format("El valor debe ser superior a {0}", minValue);
            }

            return result;
        }

        protected virtual bool Validate(int value)
        {
            return value > minValue;
        }

    }
}
