using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiP_var7
{
    public class Inductance : IPassiveElement
    {
        private double _j;
        private double _w;
        private double _L;

        public double J
        {
            get => _j;
            set
            {
                if (value < 0) throw new ValueLessThenNullException("j can't be less then 0.");
                _j = value;
            }
        }

        public double W
        {
            get => _w;
            set
            {
                if (value < 0) throw new ValueLessThenNullException("w can't be less then 0.");
                _w = value;
            }
        }

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
        public Inductance(double jValue, double wValue, double LValue)
        {
            J = jValue;
            W = wValue;
            L = LValue;
        }

        public Inductance() { }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        public double ComplexImpedances()
        {
            return _j * _w * _L;
        }
    }
}
