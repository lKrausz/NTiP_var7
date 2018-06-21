using System.Numerics;

namespace ImpedanceModel
{
    /// <summary>
    /// Интерфейс элементов
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        Complex GetImpedance(double w);

        /// <summary>
        /// Свойство для работы с параметрами пассивных элементов
        /// </summary>
        double Parameter { get; }
    }
}

