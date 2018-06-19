using System;

namespace ImpedanceModel
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
