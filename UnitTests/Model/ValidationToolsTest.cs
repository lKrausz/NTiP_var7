using System;
using ImpedanceModel;
using NUnit.Framework;

namespace UnitTests.Model
{
    [TestFixture]
    class ValidationToolsTest
    {
        [TestCase(120.12, TestName = "Тестирование при корректных данных: value = 120.12")]
        [TestCase(-120, TestName = "Тестирование при корректных данных: value = -120")]
        [TestCase("qwerty", ExpectedException = typeof(ArgumentException), TestName = "Тестирование при ошибочном value не выраженном вещественным числом")]
        [TestCase(double.NaN, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном value не являющимся числом")]
        [TestCase(double.PositiveInfinity, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном value, являющимся положительной бесконечностью")]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном value, являющимся отрицательной бесконечностью")]
        public static void IsDoubleTest(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new NegativeValueException("Данные не являются вещественным числом.");
        }

        [TestCase(120, TestName = "Тестирование при корректных данных: value = 120")]
        [TestCase(-120, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при некорректных данных: value = -120")]
        [TestCase(0, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при некорректных данных: value = 0")]
        public static void IsLessThenNullTest(double value)
        {
            if (value <= 0)
                throw new NegativeValueException("Значение данного параметра не может быть меньше 0");
        }
    }
}

