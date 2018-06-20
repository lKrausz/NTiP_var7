using System;
using System.Numerics;
using NUnit.Framework;
using ImpedanceModel;

namespace UnitTests.Model
{
    [TestFixture]
    class InductorTest
    {
        //TODO: надо отдельно затестировать конструктор, свойство метод класса
        //done?
        [TestCase(12.3, TestName = "Тестирование при корректных данных l = 12.3")]
        [TestCase(-12.3, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование сопротивления при ошибочном l = -120.")]
        [TestCase(0, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование сопротивления при ошибочном l = 0.")]
        [TestCase("qwerty", ExpectedException = typeof(ArgumentException),
            TestName = "Тестирование при ошибочном l не выраженном вещественным числом.")]
        [TestCase(double.NaN, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование при ошибочном l не являющимся числом")]
        [TestCase(double.PositiveInfinity, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование при ошибочном l, являющимся положительной бесконечностью")]
        [TestCase(double.NegativeInfinity, ExpectedException = typeof(NegativeValueException),
            TestName = "Тестирование при ошибочном l, являющимся отрицательной бесконечностью")]
        public void ConstructorTest(double l)
        {
            var inductor = new Inductor(l);
        }

        [TestCase(1, 12.3, 0, 12.3, TestName = "Тестирование при корректных данных w = 120, l = 12.3")]
        [TestCase(10, 5, 0, 50, TestName = "Тестирование при корректных данных w = 1, l = 5")]
        public void GetImpedanceTest(int w, double l, double real, double imaginary)
        {
            var inductor = new Inductor(l);
            var actual = inductor.GetImpedance(w);
            var expected = new Complex(real, imaginary);
            Assert.AreEqual(expected.Real, actual.Real);
            Assert.AreEqual(expected.Imaginary, actual.Imaginary);
        }
    }
}
