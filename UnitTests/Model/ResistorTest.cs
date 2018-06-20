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
        //done?
        [TestCase(12.3, TestName = "Тестирование при корректных данных r = 12.3")]
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

        [TestCase(120, 12.3, 12.3, 0, TestName = "Тестирование при корректных данных w = 120, r = 12.3")]
        [TestCase(1, 5, 5, 0, TestName = "Тестирование при корректных данных w = 1, r = 5")]
        public void GetImpedanceTest(int w, double r, double real, double imaginary)
        {
            var resistor = new Resistor(r);
            var actual = resistor.GetImpedance(w);
            var expected = new Complex(real, imaginary);
            Assert.AreEqual(expected.Real, actual.Real);
            Assert.AreEqual(expected.Imaginary, actual.Imaginary);
        }
    }
}
