using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiP_var7
{
    public class Resistor : IPassiveElement
    {
        private double _R = 12.3;

        public double ComplexImpedances()
        {
            return _R;
        }
    }
}
