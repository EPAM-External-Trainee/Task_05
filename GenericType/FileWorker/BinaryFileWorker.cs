using GenericType.Interfaces;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GenericType.FileWorker
{
    /// <summary>Class that describes basic operations for working with binary file</summary>
    public class BinaryFileWorker : IBinaryFileWorker
    {
        /// <summary><see cref="BinaryFormatter"/> object</summary>
        private BinaryFormatter _binaryFormatter;

        /// <inheritdoc cref="IFileWorker.Deserialize{T}(string, string)"/>
        public T Deserialize<T>(string path, string actualClassVersion) where T : class
        {
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            _binaryFormatter = new BinaryFormatter();
            dynamic tmp = _binaryFormatter.Deserialize(fileStream);

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
            _binaryFormatter = new BinaryFormatter();
            _binaryFormatter.Serialize(fileStream, data);
        }
    }
}