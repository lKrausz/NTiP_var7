using System;
using System.Numerics;
using System.Runtime.Serialization;


namespace NTiP_var7
{
    /// <summary>
    /// Элемент цепи: Катушка индуктивности
    /// </summary>
    [Serializable]
    public class Inductor : IElements
    {
        [DataMember]
        private double _l;

        /// <summary>
        /// Свойство для работы с параметрами
        /// </summary>
        public double Parametrs
        {
            get => _l;
            set
            {
                CheckCorrectValue.IsDouble(value);
                CheckCorrectValue.IsLessThenNull(value);
                _l = value;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Inductor(double lValue)
        {
            Parametrs = lValue;
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
