using System.Numerics;


namespace NTiP_var7
{
    public interface IPassiveElement
    {
        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        Complex ComplexImpedances(Complex j, double w);
    }
}
