using System.Numerics;


namespace NTiP_var7
{
    //TODO: Индуктивность - это физическая величина. А КАТУШКА ИНДУКТИВНОСТИ (Inductor) - это элемент
    /// <summary>
    /// Элемент цепи: Индуктивность
    /// </summary>
    public class Inductance : IPassiveElement
    {
        //TODO: комментарий
        //TODO: неправильное имя поля
        private double _L;

        public double L
        {
            get => _L;
            set
            {
                if (value < 0) throw new ValueLessThenNullException("L can't be less then 0.");
                _L = value;
            }
        }

        //TODO: неправильное именование входного аргумента
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Inductance(double LValue)
        {
            L = LValue;
        }

        //TODO: Зачем этот конструктор?
        public Inductance() { }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        public Complex ComplexImpedances(Complex j, double w)
        {
            return j * w * _L;
        }
    }
}
