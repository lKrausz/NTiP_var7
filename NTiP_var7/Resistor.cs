using System;
using System.Numerics;
using System.Runtime.Serialization;


namespace NTiP_var7
{
    /// <summary>
    /// Элемент цепи: Резистор
    /// </summary>
    [Serializable]
    public class Resistor : IElements
    {

        [DataMember]
        private double _r;

        /// <summary>
        /// Свойство для работы с параметрами
        /// </summary>
        public double Parametrs
        {
            get => _r;
            set
            {
                CheckCorrectValue.IsDouble(value);
                CheckCorrectValue.IsLessThenNull(value);
                _r = value;
            }

        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Resistor(double RValue)
        {
            Parametrs = RValue;
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
