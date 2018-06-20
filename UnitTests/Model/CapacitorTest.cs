using System;
using System.Numerics;
using NUnit.Framework;
using ImpedanceModel;

namespace UnitTests.Model
{
    [TestFixture]
    internal class CapacitorTest
    {
        //TODO: надо отдельно затестировать конструктор, свойство метод класса
        //done?
        [TestCase(12.3, TestName = "Тестирование при корректных данных c = 12.3")]
        [TestCase(-12.3, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование сопротивления при ошибочном c = -120.")]
        [TestCase(0, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование сопротивления при ошибочном c = 0.")]
        [TestCase("qwerty", ExpectedException = typeof(ArgumentException),
            TestName = "Тестирование при ошибочном c не выраженном вещественным числом.")]
        [TestCase(double.NaN, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование при ошибочном c не являющимся числом")]
        [TestCase(double.PositiveInfinity, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование при ошибочном c, являющимся положительной бесконечностью")]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование при ошибочном c, являющимся отрицательной бесконечностью")]
        public void ConstructorTest(double c)
        {
            var capacitor = new Capacitor(c);
        }

        [TestCase(1, 1, 0, -1, TestName = "Тестирование при корректных данных w = 1, c = 1")]
        [TestCase(2, 5, 0, -0.1, TestName = "Тестирование при корректных данных w = 2, c = 5")]
        public void GetImpedanceTest(int w, double c, double real, double imaginary)
        {
            var capacitor = new Capacitor(c);
            var actual = capacitor.GetImpedance(w);
            var expected = new Complex(real, imaginary);
            Assert.AreEqual(expected.Real, actual.Real);
            Assert.AreEqual(expected.Imaginary, actual.Imaginary);
        }
    }
}
