using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiP_var7
{
    public class Capacitor : IPassiveElement
    {
        private double _j = 0.7;
        private double _w = 3.45;
        private double _C = 9.7;

        public double ComplexImpedances()
        {
            return -_j / (_w * _C);
        }
    }
}
