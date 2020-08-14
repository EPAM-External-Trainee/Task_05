using GenericType.Enums;
using GenericType.FileWorker;
using GenericType.Interfaces;
using System;

namespace GenericType.Serializers
{
    public static class MyFileWorker<T> where T : class
    {
        private static IFileWorker _fileWorker;

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