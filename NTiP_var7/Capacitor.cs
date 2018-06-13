using System;
using System.Numerics;
using System.Runtime.Serialization;


namespace NTiP_var7
{
    /// <summary>
    /// Элемент цепи: Конденсатор
    /// </summary>
    [Serializable]
    public class Capacitor : IElements
    {
        [DataMember]
        private double _c;

        /// <summary>
        /// Свойство для работы с параметрами
        /// </summary>
        public double Parametrs
        {
            get => _c;
            set
            {
                CheckCorrectValue.IsDouble(value);
                CheckCorrectValue.IsLessThenNull(value);
                _c = value;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Capacitor(double cValue)
        {
            Parametrs = cValue;
        }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        public Complex GetImpedance(double w)
        {
            return -Complex.ImaginaryOne / (w * _c);
        }

        public override string ToString()
        {
            return "Capacitor";
        }
    }
}
