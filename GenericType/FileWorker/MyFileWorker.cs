using GenericType.Enums;
using GenericType.FileWorker;
using GenericType.Interfaces;
using System;

namespace GenericType.Serializers
{
    /// <summary>Class that describes basic operations for working with data of custom generic types</summary>
    /// <typeparam name="T"><see cref="class"/></typeparam>
    public static class MyFileWorker<T> where T : class
    {
        /// <summary><see cref="IFileWorker"/> object</summary>
        private static IFileWorker _fileWorker;

        /// <summary>Serializing data to a file with the selected format</summary>
        /// <param name="path">Path to file</param>
        /// <param name="data">Serializable class</param>
        /// <param name="serializationType">Type for serialization</param>
        public static void Serialize(string path, T data, SerializationType serializationType)
        {
            try
            {
                switch (serializationType)
                {
                    case SerializationType.Binary: _fileWorker = new BinaryFileWorker(); _fileWorker.Serialize(path, data); return;
                    case SerializationType.JSON: _fileWorker = new JSONFileWorker(); _fileWorker.Serialize(path, data); return;
                    case SerializationType.XML: _fileWorker = new XmlFileWorker(); _fileWorker.Serialize(path, data); return;
                }
            }
            catch (InvalidCastException ice)
            {
                throw new InvalidCastException(ice.Message);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        /// <summary>Deserializing data to a file with the selected format</summary>
        /// <param name="path">Path to file</param>
        /// <param name="data">Serializable class</param>
        /// <param name="deserializationType">Type for deserialization</param>
        /// <returns>Deserialized data</returns>
        public static T Deserialize(string path, string actualClassVersion, DeserializationType deserializationType)
        {
            try
            {
                switch (deserializationType)
                {
                    case DeserializationType.Binary: _fileWorker = new BinaryFileWorker(); return _fileWorker.Deserialize<T>(path, actualClassVersion);
                    case DeserializationType.JSON: _fileWorker = new JSONFileWorker(); return _fileWorker.Deserialize<T>(path, actualClassVersion);
                    case DeserializationType.XML: _fileWorker = new XmlFileWorker(); return _fileWorker.Deserialize<T>(path, actualClassVersion);
                }

                return null;
            }
            catch (InvalidCastException ice)
            {
                throw new InvalidCastException(ice.Message);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
    }
}