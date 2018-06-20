using System;
using System.Windows.Forms;

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
            MessageBox.Show(message, "Error");
        }

        public NegativeValueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
