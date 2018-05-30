using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiP_var7
{
    public class Capacitor : IPassiveElement
    {
        private double _j;
        private double _w;
        private double _C;

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
        public Capacitor(double jValue, double wValue, double CValue)
        {
            try
            {
                J = jValue;
                W = wValue;
                C = CValue;
            }
            catch (ValueLessThenNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Capacitor() { }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        public double ComplexImpedances()
        {
            return -_j / (_w * _C);
        }

    }
}
