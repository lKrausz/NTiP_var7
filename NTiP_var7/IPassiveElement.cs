using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTiP_var7
{
    public interface IPassiveElement
    {
        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        double ComplexImpedances();
    }
}
