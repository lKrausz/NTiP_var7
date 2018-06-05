using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiP_var7
{
    //TODO: очень длинное название класса (и к тому же неправильное, так как не может быть значения меньше Null). 
    // NegativeValueException - название лаконичнее и понятнее.
    public class ValueLessThenNullException : Exception
    {
        public ValueLessThenNullException()
        {
        }

        public ValueLessThenNullException(string message)
            : base(message)
        {
        }

        public ValueLessThenNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
