using GenericType.Interfaces;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace GenericType.FileWorker
{
    /// <summary>Class that describes basic operations for working with JSON file</summary>
    public class JSONFileWorker : IJSONFileWorker
    {
        /// <summary><see cref="DataContractJsonSerializerSettings"/> object</summary>
        private readonly DataContractJsonSerializerSettings _settings = new DataContractJsonSerializerSettings() { DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ss.fffK") };

        /// <summary><see cref="DataContractJsonSerializer"/> object</summary>
        private DataContractJsonSerializer _jsonSerializer;

        /// <inheritdoc cref="IFileWorker.Deserialize{T}(string, string)"/>
        public T Deserialize<T>(string path, string actualClassVersion) where T : class
        {
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            _jsonSerializer = new DataContractJsonSerializer(typeof(T), _settings);
            dynamic tmp = _jsonSerializer.ReadObject(fileStream);

            if (tmp.Version.ToString() == actualClassVersion)
            {
                return (T)tmp;
            }

            throw new InvalidCastException("Different version of classes");
        }

        /// <inheritdoc cref="IFileWorker.Serialize{T}(string, T)"/>
        public void Serialize<T>(string path, T data) where T : class
        {
            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            _jsonSerializer = new DataContractJsonSerializer(typeof(T), _settings);
            _jsonSerializer.WriteObject(fileStream, data);
        }
    }
}