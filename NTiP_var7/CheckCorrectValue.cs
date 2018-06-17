using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO: убрать лишние юзинги
namespace NTiP_var7
{
    //TODO: название класса - от глагола. Неправильно
    //TODO: комментарий
    //TODO: где юнит-тесты на этот класс?
    public static class CheckCorrectValue
    {
        //TODO: комментарий
        public static void IsDouble(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new NegativeValueException("Данные не являются вещественным числом.");
        }

        //TODO: комментарий
        public static void IsLessThenNull(double value)
        {
            if (value <= 0)
                throw new NegativeValueException("Значение данного параметра не может быть меньше 0");
        }
    }
}
