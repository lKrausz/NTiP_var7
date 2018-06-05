using System.Numerics;


namespace NTiP_var7
{
    /// <summary>
    /// Элемент цепи: Резистор
    /// </summary>
    public class Resistor : IPassiveElement
    {
        //TODO: все замечания аналогичны катушке индуктивности
        private double _R;

        public double R
        {
            get => _R;
            set
            {
                if (value < 0) throw new ValueLessThenNullException("R can't be less then 0.");
                _R = value;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Resistor(double RValue)
        {
            R = RValue;
        }

        //TODO: зачем этот конструктор
        public Resistor() { }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        /// <remarks> Входные параметры не используются при рассчете комплексного сопротивления резистора.</remarks>
        public Complex ComplexImpedances(Complex j, double w) 
        {
            return _R;
        }
    }
}
