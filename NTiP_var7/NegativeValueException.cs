using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiP_var7
{
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
