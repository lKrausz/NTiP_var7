namespace ImpedanceModel
{
    /// <summary>
    /// Статистический класс, проверяющий корректность значений, введенных пользователем
    /// </summary>
    public static class ValidationTools
    {
        /// <summary>
        /// Проверка на корректность ввода вещественных чисел
        /// </summary>
        public static void IsDouble(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new NegativeValueException("Данные не являются вещественным числом.");
        }

        /// <summary>
        /// Проверка на корректность ввода данных, которые должны быть строго больше нуля
        /// </summary>
        public static void IsLessThenNull(double value)
        {
            if (value <= 0)
                throw new NegativeValueException("Значение данного параметра не может быть меньше 0");
        }
    }
}
