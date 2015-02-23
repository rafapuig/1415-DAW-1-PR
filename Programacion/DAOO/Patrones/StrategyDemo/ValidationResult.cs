using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo
{
    class ValidationResult<T>
    {
        public T Value { get; set; }                //Value converted from parsing the input text
        public bool IsValid { get; set; }      //wether the value passes the validation conditions
        public string ErrorMessage { get; set; }    //Error message to out
    }
}
