using System;
using System.Numerics;
using NUnit.Framework;
using ImpedanceModel;

namespace UnitTests.Model
{
    [TestFixture]
    class ResistorTest
    {
        //TODO: надо отдельно затестировать конструктор, свойство метод класса
        [TestCase(12.3, TestName = "Тестирование при корректных данных w = 120, r = 12.3")]
        [TestCase(-12.3, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование сопротивления при ошибочном r = -120.")]
        [TestCase(0, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование сопротивления при ошибочном r = 0.")]
        [TestCase("qwerty", ExpectedException = typeof(ArgumentException),
            TestName = "Тестирование при ошибочном r не выраженном вещественным числом.")]
        [TestCase(double.NaN, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование при ошибочном r не являющимся числом")]
        [TestCase(double.PositiveInfinity, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование при ошибочном r, являющимся положительной бесконечностью")]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование при ошибочном r, являющимся отрицательной бесконечностью")]
        public void ConstructorTest(double r)
        {
            var resistor = new Resistor(r);
        }

        [TestCase(120, 12.3, ExpectedResult = (12.3, 0), TestName = "Тестирование при корректных данных w = 120, r = 12.3")]
        [TestCase(1, 5, ExpectedResult = 5, TestName = "Тестирование при корректных данных w = 1, r = 5")]
        public Complex GetImpedanceTest(int w, double r)
        {
            var resistor = new Resistor(r);
            return resistor.GetImpedance(w);
        }
    }
}
