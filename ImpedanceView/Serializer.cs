using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using ImpedanceModel;


namespace ImpedanceView
{
    /// <summary>
    /// Класс, реализующий сохранение в файл и загрузку данных из файла
    /// </summary>
    static class Serializer
    {
        /// <summary>
        /// Перечисление типов, которые рассматриваются при десериализации
        /// </summary>
        private static readonly IEnumerable<Type> TypeList = new List<Type>
        {
            typeof(Resistor),
            typeof(Capacitor),
            typeof(Inductor),
        };

        /// <summary>
        /// Сериализует объекты в нотацию объектов JavaScript (JSON) и десериализует данные JSON в объекты
        /// </summary>
        private static readonly DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<IElement>), TypeList);

        /// <summary>
        /// Сохранение в файл
        /// </summary>
        public static void Save(string filename, List<IElement> elements)
        {
            jsonFormatter.WriteObject(new FileStream(filename, FileMode.Create), elements);
        }

        /// <summary>
        /// Загрузка файла
        /// </summary>
        public static List<IElement> Open(string filename)
        {
            return (List<IElement>)jsonFormatter.ReadObject(new FileStream(filename, FileMode.Open));
        }

    }
}
