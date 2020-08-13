using GenericType.Interfaces;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace GenericType.FileWorker
{
    public class XmlFileWorker : IXmlFileWorker
    {
        public T DeserializeFromXmlFile<T>(string path, string actualClassVersion) where T : class
        {
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            var xmlSerializer = new DataContractSerializer(typeof(T));
            dynamic tmp = xmlSerializer.ReadObject(fileStream);

            if (tmp.Version.ToString() == actualClassVersion)
            {
                return (T)tmp;
            }

            throw new InvalidCastException("Different version of classes");
        }

        public void SerializeToXmlFile<T>(string path, T data) where T : class
        {
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Write);
            var xmlSerializer = new DataContractSerializer(typeof(T));
            xmlSerializer.WriteObject(fileStream, data);
        }
    }
}