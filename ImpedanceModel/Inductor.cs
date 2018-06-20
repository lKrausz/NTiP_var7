using System;
using System.Numerics;
using System.Runtime.Serialization;


namespace ImpedanceModel
{
    /// <summary>
    /// Элемент цепи: Катушка индуктивности
    /// </summary>
    [DataContract]
    public class Inductor : IElement
    {
        [DataMember]
        private double _l;

        /// <summary>
        /// Свойство для работы с параметрами
        /// </summary>
        public double Parameter
        {
            get => _l;
            set
            {
                ValidationTools.IsDouble(value);
                ValidationTools.IsLessThenNull(value);
                _l = value;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Inductor(double lValue)
        {
            Parameter = lValue;
        }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        public Complex GetImpedance( double w)
        {
            return Complex.ImaginaryOne * w * _l;
        }

        public override string ToString()
        {
            return "Inductor";
        }
    }
}
