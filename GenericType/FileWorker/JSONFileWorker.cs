using GenericType.Interfaces;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace GenericType.FileWorker
{
    public class JSONFileWorker : IJSONFileWorker
    {
        private readonly DataContractJsonSerializerSettings _settings = new DataContractJsonSerializerSettings() { DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ss.fffK") };

        public T DeserializeFromJSONFile<T>(string path, string actualClassVersion) where T : class
        {
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            var jsonSerializer = new DataContractJsonSerializer(typeof(T), _settings);
            dynamic tmp = jsonSerializer.ReadObject(fileStream);

            if (tmp.Version.ToString() == actualClassVersion)
            {
                return (T)tmp;
            }

            throw new InvalidCastException("Different version of classes");
        }

        public void SerializeToJSONFile<T>(string path, T data) where T : class
        {
            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            var jsonSerializer = new DataContractJsonSerializer(typeof(T), _settings);
            jsonSerializer.WriteObject(fileStream, data);
        }
    }
}