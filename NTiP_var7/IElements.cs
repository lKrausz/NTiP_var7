using System.Numerics;

//TODO: плохое название для проекта. Переименовать в Elements
//done

//TODO: enum лежит ВНЕ пространства имен библиотеки!
//TODO: КАЖДЫЙ тип данных в своём файле!
//???
public enum ElementsType
{
    Inductor,
    Resistor,
    Capacitor
}

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
        /// <summary>
        /// Получение закрытых полей дочерних классов для заполнения gridview, столбца параметров
        /// </summary>
        double GetParametr();
    }
}

