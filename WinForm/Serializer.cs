using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WinForm
{
    //TODO: у класса надо ставить модификатор static, иначе можно будет создавать его экземпляры
    /// <summary>
    /// Класс, реализующий сохранение в файл и загрузку данных из файла
    /// </summary>
    class Serializer
    {
        //TODO: убрать слово Binary из названия - название не должно раскрывать особенности реализации
        //TODO: заменить BinaryFormatter на Newtonsoft JSON.NET - стороннюю библиотеку. Атрибуты сериализации из бизнес-логики потом удалить
        //TODO: Зачем ref?
        //TODO: Зачем шаблонный метод?
        public static void SerializeBinary<T>(string fileName, ref T container)
        {
            var formatter = new BinaryFormatter();
            var serializeFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            formatter.Serialize(serializeFileStream, container);
            serializeFileStream.Close();
        }

        //TODO: убрать слово Binary из названия - название не должно раскрывать особенности реализации
        //TODO: заменить BinaryFormatter на Newtonsoft JSON.NET - стороннюю библиотеку. Атрибуты сериализации из бизнес-логики потом удалить
        //TODO: Зачем ref?
        //TODO: Зачем шаблонный метод?
        public static void DeserializeBinary<T>(string fileName, ref T container)
        {
            var formatter = new BinaryFormatter();
            var deserializeFile = new FileStream(fileName, FileMode.OpenOrCreate);
            if (deserializeFile.Length > 0)
                container = (T)formatter.Deserialize(deserializeFile);
            deserializeFile.Close();
        }
    }
}
