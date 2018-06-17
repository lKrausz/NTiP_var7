using System;
using System.Numerics;
//TODO: убрать лишние юзинги

//TODO: переименовать проект, наимспейс и папку проекта правильно
namespace NTiP_var7
{
    //TODO: комментарий
    //TODO: интерфейс переименовать в единственном числе
    public interface IElements
    {
        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        Complex GetImpedance(double w);

        //TODO: комментарий
        //TODO: исправить грамматическую ошибку
        //TODO: Почему множественное число?
        double Parametrs { get; }
    }
}

