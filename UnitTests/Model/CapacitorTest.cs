using System;
using NUnit.Framework;
using ImpedanceModel;

namespace UnitTests.Model
{
    [TestFixture]
    internal class CapacitorTest
    {
        //TODO: надо отдельно затестировать конструктор, свойство метод класса
        [TestCase(120, 12.3, TestName = "Тестирование при корректных данных w = 120, c = 12.3")]
        [TestCase(120, -12.3, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование сопротивления при ошибочном с = -120.")]
        [TestCase(120, 0, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование сопротивления при ошибочном c = 0.")]
        [TestCase(120, "qwerty", ExpectedException = typeof(ArgumentException), TestName = "Тестирование при ошибочном c не выраженном вещественным числом.")]
        [TestCase(120, double.NaN, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном c не являющимся числом")]
        [TestCase(120, double.PositiveInfinity, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном c, являющимся положительной бесконечностью")]
        [TestCase(120, double.NegativeInfinity, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном c, являющимсящимся отрицательной бесконечностью")]
        public void GetImpedanceTest(int w, double c)
        {
            var capacitor = new Capacitor(c);
            capacitor.GetImpedance(w);
        }
    }
}
