using GenericType.Interfaces;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GenericType.FileWorker
{
    public class BinaryFileWorker : IBinaryFileWorker
    {
        public T DeserializeFromBinaryFile<T>(string path, string actualClassVersion) where T : class
        {
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            var binaryFormatter = new BinaryFormatter();
            dynamic tmp = binaryFormatter.Deserialize(fileStream);

            if (tmp.Version.ToString() == actualClassVersion)
            {
                return (T)tmp;
            }

            throw new InvalidCastException("Different version of classes");
        }

        public void SerializeToBinaryFile<T>(string path, T data) where T : class
        {
            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, data);
        }
    }
}