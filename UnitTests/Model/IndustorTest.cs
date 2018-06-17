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
    //TODO: переименовать класс - грамматическая ошибка
    [TestFixture]
    class IndustorTest
    {
        //TODO: надо отдельно затестировать конструктор, свойство метод класса
        [Test] //TODO: при использовании TestCase атрибут Test уже не нужен
        [TestCase(120, 12.3, TestName = "Тестирование при корректных данных w = 120, l = 12.3")]
        [TestCase(120, -12.3, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование сопротивления при ошибочном l = -120.")]
        [TestCase(120, 0, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование сопротивления при ошибочном l = 0.")]
        [TestCase(120, "qwerty", ExpectedException = typeof(ArgumentException), TestName = "Тестирование при ошибочном l не выраженном вещественным числом.")]
        [TestCase(120, double.NaN, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном l не являющимся числом")]
        [TestCase(120, double.PositiveInfinity, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном l, являющимся положительной бесконечностью")]
        [TestCase(120, double.NegativeInfinity, ExpectedException = typeof(NegativeValueException), TestName = "Тестирование при ошибочном l, являющимся отрицательной бесконечностью")]
        public void GetImpedanceTest(int w, double l)
        {
            var inductor = new Inductor(l);
            inductor.GetImpedance(w);
        }
    }
}
