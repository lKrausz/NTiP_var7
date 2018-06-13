using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiP_var7
{
    public static class CheckCorrectValue
    {
        public static void IsDouble(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new NegativeValueException("Данные не являются вещественным числом.");
        }

        public static void IsLessThenNull(double value)
        {
            if (value <= 0)
                throw new NegativeValueException("Значение данного параметра не может быть меньше 0");
        }
    }
}
