using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemo
{
    class ParseValidator<T> : IValidator<T>
    {
        public virtual ValidationResult<T> Validate(string text)
        {
            ValidationResult<T> result = new ValidationResult<T>();


            //if (typeof(T) == typeof(Int32))
            //{
            //    //ValidationResult<int> intResult = new ValidationResult<int>();

            //    int value;
            //    if (!Int32.TryParse(text, out value))
            //    {
            //        result.ErrorMessage = "No se puede convertir en " + typeof(T).Name;
            //        result.IsValid = false;
            //    }
            //    else
            //    {
            //        result.Value = (T)(object)value;
            //        result.IsValid = true;
            //    }

            //    //return intResult;

            //    return result;

            //}

            //IConvertible c;

            //IFormatProvider provider;

            //c.ToType(typeof(T), provider);

            //try
            //{
            //    result.Value = (T)Convert.ChangeType(text, typeof(T)); // text string IConvertible
            //    result.IsValid = true;
            //}
            //catch (Exception)
            //{
            //    result.ErrorMessage = "No se puede convertir en " + typeof(T).Name;
            //}

            //return result;

            T parsedValue;

            if (!(result.IsValid = text.TryParse(out parsedValue)))
            {
                result.ErrorMessage = "No se puede convertir en " + typeof(T).Name;
            }

            result.Value = parsedValue;

            return result;

        }


        


//        var parserFuncs = new Dictionary<Type, Func<string, object>>() {
//    { typeof(int), p => (int) int.Parse(p) },
//    { typeof(bool), p => (bool) bool.Parse(p) },
//    { typeof(long), p => (long) long.Parse(p) },
//    { typeof(short), p => (short) short.Parse(p) },
//    { typeof(DateTime), p => (DateTime) DateTime.Parse(p) }
//    /* ...same for all the other primitive types */
//};

//return (T) parserFuncs[typeof(T)](value);
    }

    static class StringExt
    {
        public static bool TryParse<T>(this string value, out T newValue, T defaultValue = default(T)) //where T : IConvertible
        {
            newValue = defaultValue;
            try
            {
                newValue = (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static T Parse<T>(this string value) where T : IConvertible //,struct
        {

            return (T)Convert.ChangeType(value, typeof(T));
        }

    }

}
