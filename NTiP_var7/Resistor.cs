using System.Numerics;


namespace NTiP_var7
{
    /// <summary>
    /// Элемент цепи: Резистор
    /// </summary>
    public class Resistor : IElements
    {
        //TODO: все замечания аналогичны катушке индуктивности
        private double _r;

        public double R
        {
            get => _r;
            set
            {
                if (value < 0) throw new NegativeValueException("R can't be less then 0.");
                _r = value;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Resistor(double RValue)
        {
            R = RValue;
        }

        /// <summary>
        /// Рассчет комплексного сопротивления
        /// </summary>
        /// <remarks> Входные параметры не используются при рассчете комплексного сопротивления резистора.</remarks>
        public Complex GetImpedance(double w) 
        {
            return _r;
        }

        /// <summary>
        /// Получение закрытых полей дочерних классов для заполнения gridview, столбца параметров
        /// </summary>
        public double GetParametr()
        {
            return _r;
        }

        public override string ToString()
        {
            return "Resistor";
        }
    }
}
