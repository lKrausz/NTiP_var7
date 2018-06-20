using System;
using System.Numerics;
using System.Runtime.Serialization;


namespace ImpedanceModel
{
    /// <summary>
    /// Элемент цепи: Конденсатор
    /// </summary>
    [DataContract]
    public class Capacitor : IElement
    {
        [DataMember]
        private double _c;

        /// <summary>
        /// Свойство для работы с параметрами
        /// </summary>
        public double Parameter
        {
            get => _c;
            set
            {
                ValidationTools.IsDouble(value);
                ValidationTools.IsLessThenNull(value);
                _c = value;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Capacitor(double cValue)
        {
            Parameter = cValue;
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
