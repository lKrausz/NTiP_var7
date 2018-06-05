using System.Numerics;

//TODO: плохое название для проекта. Переименовать в Elements

//TODO: enum лежит ВНЕ пространства имен библиотеки!
//TODO: КАЖДЫЙ тип данных в своём файле!
public enum ElementsType
{
    Inductance,
    Resistor,
    Capacitor
}

namespace NTiP_var7
{
    public interface IPassiveElement
    {
        //TODO: Если первый параметр это ВСЕГДА комплексная единица, зачем его постоянно передавать? 
        // Может, внутри класса сразу использовать константу ImaginaryOne?
        //TODO: Метод переименовать в GetImpedance. Слово Complex лишнее - импеданс сам по себе только комлпексная величина
        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        Complex ComplexImpedances(Complex j, double w);
    }
}

