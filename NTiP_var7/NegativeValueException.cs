using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiP_var7
{
    //TODO: очень длинное название класса (и к тому же неправильное, так как не может быть значения меньше Null). 
    // NegativeValueException - название лаконичнее и понятнее.
    //done
    public class NegativeValueException : Exception
    {
        public NegativeValueException()
        {
        }

        public NegativeValueException(string message)
            : base(message)
        {
        }

        public NegativeValueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
