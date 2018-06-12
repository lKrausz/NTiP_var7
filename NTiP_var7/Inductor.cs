using System.Numerics;


namespace NTiP_var7
{
    //TODO: Индуктивность - это физическая величина. А КАТУШКА ИНДУКТИВНОСТИ (Inductor) - это элемент
    //done
    /// <summary>
    /// Элемент цепи: Катушка индуктивности
    /// </summary>
    public class Inductor : IElements
    {
        //TODO: комментарий
        //TODO: неправильное имя поля
        //done
        private double _l;

        public double L
        {
            get => _l;
            set
            {
                if (value < 0) throw new NegativeValueException("L can't be less then 0.");
                _l = value;
            }
        }

        //TODO: неправильное именование входного аргумента
        //done?
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Inductor(double lValue)
        {
            L = lValue;
        }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        public Complex GetImpedance( double w)
        {
            return Complex.ImaginaryOne * w * _l;
        }

        /// <summary>
        /// Получение закрытых полей дочерних классов для заполнения gridview, столбца параметров
        /// </summary>
        public double GetParametr()
        {
            return _l;
        }

        public override string ToString()
        {
            return "Inductor";
        }
    }
}
