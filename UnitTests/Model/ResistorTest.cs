using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NTiP_var7;

namespace UnitTests.Model
{
    [TestFixture]
    class ResistorTest
    {
        [Test]
        [TestCase(120, 12.3, TestName = "Тестирование при корректных данных w = 120, r = 12.3")]
        [TestCase(120, -12.3, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование сопротивления при ошибочном r = -120.")]
        [TestCase(120, 0, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование сопротивления при ошибочном r = 0.")]
        [TestCase(120, "qwerty", ExpectedException = typeof(ArgumentException), TestName = "Тестирование при ошибочном r не выраженном вещественным числом.")]
        [TestCase(120, double.NaN, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном r не являющимся числом")]
        [TestCase(120, double.PositiveInfinity, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном r, являющимся положительной бесконечностью")]
        [TestCase(120, double.NegativeInfinity, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном r, являющимся отрицательной бесконечностью")]
        public void GetImpedanceTest(int w, double r)
        {
            var resistor = new Resistor(r);
            resistor.GetImpedance(w);
        }
    }
}
