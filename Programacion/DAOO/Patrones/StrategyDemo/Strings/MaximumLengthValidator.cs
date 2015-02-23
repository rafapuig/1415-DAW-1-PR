using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo.Strings
{
    class MaximumLengthValidator : Validator<string>
    {

        int maximumLength;

        public MaximumLengthValidator(int maxLength)
        {
            this.maximumLength = maxLength;
        }

        protected override string GetErrorMessage()
        {
            return string.Format("El texto debe tener una longitud maxima de {0} caracteres", maximumLength);
        }

        protected override bool PerformValidation(string value)
        {
            return value.Length <= maximumLength;
        }
    }
}
