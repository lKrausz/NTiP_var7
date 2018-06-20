using System;
using System.Numerics;
using System.Runtime.Serialization;


namespace ImpedanceModel
{
    /// <summary>
    /// Элемент цепи: Резистор
    /// </summary>
    [Serializable]
    public class Resistor : IElement
    {

        [DataMember]
        private double _r;

        /// <summary>
        /// Свойство для работы с параметрами
        /// </summary>
        public double Parameter
        {
            get => _r;
            set
            {
                ValidationTools.IsDouble(value);
                ValidationTools.IsLessThenNull(value);
                _r = value;
            }

        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Resistor(double RValue)
        {
            Parameter = RValue;
        }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        /// <remarks> Входные параметры не используются при рассчете комплексного сопротивления резистора.</remarks>
        public Complex GetImpedance(double w) 
        {
            return _r;
        }

        public override string ToString()
        {
            return "Resistor";
        }
    }
}
