using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using ImpedanceModel;


namespace ImpedanceView
{
    /// <summary>
    /// Класс, реализующий сохранение в файл и загрузку данных из файла
    /// </summary>
    static class Serializer
    {
        //public static void SerializeBinary<T>(string fileName, ref T container)
        //{
        //    var formatter = new BinaryFormatter();
        //    var serializeFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
        //    formatter.Serialize(serializeFileStream, container);
        //    serializeFileStream.Close();
        //}

        //public static void DeserializeBinary<T>(string fileName, ref T container)
        //{
        //    var formatter = new BinaryFormatter();
        //    var deserializeFile = new FileStream(fileName, FileMode.OpenOrCreate);
        //    if (deserializeFile.Length > 0)
        //        container = (T)formatter.Deserialize(deserializeFile);
        //    deserializeFile.Close();
        //}

        // Create a User object and serialize it to a JSON stream.  
        public static string WriteFromObject(string fileName, List<IElement> elements)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IElement));
            ser.WriteObject(ms, elements);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        // Deserialize a JSON stream to a User object.  
        public static List<IElement> ReadToObject(string json)
        {
            List<IElement> deserializedUser = new List<IElement>();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedUser.GetType());
            deserializedUser = ser.ReadObject(ms) as List<IElement>;
            ms.Close();
            return deserializedUser;
        }
    }
}
