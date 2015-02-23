using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo
{
    interface IValidator<T>
    {
        ValidationResult<T> Validate(string text);
    }
}

/*
 * Queda por resolver si mejoraria com un validador cuya entrada no sea string
 * de modo que ya no sea necesario hacer un parsing de la entrada cada vez
 */
