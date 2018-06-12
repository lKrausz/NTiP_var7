using System.Numerics;


namespace NTiP_var7
{
    /// <summary>
    /// Элемент цепи: Конденсатор
    /// </summary>
    public class Capacitor : IElements
    {
        //TODO: Все замечания аналогичны катушке индуктивности
        //done
        private double _c;

        public double C
        {
            get => _c;
            set
            {
                if (value < 0) throw new NegativeValueException("C can't be less then 0.");
                _c = value;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Capacitor(double cValue)
        {
            C = cValue;
        }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        public Complex GetImpedance(double w)
        {
            return -Complex.ImaginaryOne / (w * _c);
        }

        /// <summary>
        /// Получение закрытых полей дочерних классов для заполнения gridview, столбца параметров
        /// </summary>
        public double GetParametr()
        {
            return _c;
        }

        public override string ToString()
        {
            return "Capacitor";
        }
    }
}
