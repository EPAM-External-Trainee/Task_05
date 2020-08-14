using GenericType.Interfaces;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace GenericType.FileWorker
{
    /// <summary>Class that describes basic operations for working with JSON file</summary>
    public class XmlFileWorker : IXmlFileWorker
    {
        /// <summary><see cref="DataContractSerializer"/> object</summary>
        private DataContractSerializer _xmlSerializer;

        /// <inheritdoc cref="IFileWorker.Deserialize{T}(string, string)"/>
        public T Deserialize<T>(string path, string actualClassVersion) where T : class
        {
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            _xmlSerializer = new DataContractSerializer(typeof(T));
            dynamic tmp = _xmlSerializer.ReadObject(fileStream);

            if (tmp.Version.ToString() == actualClassVersion)
            {
                return (T)tmp;
            }

            throw new InvalidCastException("Different version of classes");
        }

        /// <inheritdoc cref="IFileWorker.Serialize{T}(string, T)"/>
        public void Serialize<T>(string path, T data) where T : class
        {
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Write);
            _xmlSerializer = new DataContractSerializer(typeof(T));
            _xmlSerializer.WriteObject(fileStream, data);
        }
    }
}