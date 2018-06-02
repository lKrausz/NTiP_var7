using System.Numerics;


namespace NTiP_var7
{
    /// <summary>
    /// Элемент цепи: Конденсатор
    /// </summary>
    public class Capacitor : IPassiveElement
    {
        private double _C;

        public double C
        {
            get => _C;
            set
            {
                if (value < 0) throw new ValueLessThenNullException("C can't be less then 0.");
                _C = value;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Capacitor(double CValue)
        {
            C = CValue;
        }

        public Capacitor() { }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        public Complex ComplexImpedances(Complex j, double w)
        {
            return -j / (w * _C);
        }
    }
}
