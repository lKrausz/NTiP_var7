using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiP_var7
{
    public class Resistor : IPassiveElement
    {
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

        public Resistor() { }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        public double ComplexImpedances()
        {
            return _R;
        }
    }
}
