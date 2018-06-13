using System;
using System.Numerics;

namespace NTiP_var7

{
    public interface IElements
    {
        //TODO: Если первый параметр это ВСЕГДА комплексная единица, зачем его постоянно передавать? 
        // Может, внутри класса сразу использовать константу ImaginaryOne?
        //done
        //TODO: Метод переименовать в GetImpedance. Слово Complex лишнее - импеданс сам по себе только комлпексная величина
        //done
        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        Complex GetImpedance(double w);

        double Parametrs { get; }
    }
}

