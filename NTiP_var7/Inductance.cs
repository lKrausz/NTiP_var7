using System.Numerics;


namespace NTiP_var7
{
    /// <summary>
    /// Элемент цепи: Индуктивность
    /// </summary>
    public class Inductance : IPassiveElement
    {
        private double _L;

        public double L
        {
            get => _L;
            set
            {
                if (value < 0) throw new ValueLessThenNullException("L can't be less then 0.");
                _L = value;
            }
        }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Inductance(double LValue)
        {
            L = LValue;
        }

        public Inductance() { }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        public Complex ComplexImpedances(Complex j, double w)
        {
            return j * w * _L;
        }
    }
}
