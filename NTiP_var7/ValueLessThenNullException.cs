using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiP_var7
{
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
