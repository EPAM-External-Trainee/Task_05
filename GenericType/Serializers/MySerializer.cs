using GenericType.Enums;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace GenericType.Serializers
{
    public static class MySerializer<T> where T : class
    {
        private static void SerializeToBinaryFile(string path, T data)
        {
            using var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            var binarySerializer = new BinaryFormatter();
            binarySerializer.Serialize(fileStream, data);
        }

        private static T DeserializeFromBinaryFile(string path, string actualClassVersion)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var binarySerializer = new BinaryFormatter();
                dynamic tmp = binarySerializer.Deserialize(fileStream);

                if (tmp.Version.ToString() == actualClassVersion)
                {
                    return (T)tmp;
                }

                throw new InvalidCastException("Different version of classes");
            }
        }

        private static void SerializeToJSONFile(string path, T data)
        {
            using var fileStream = new FileStream(path, FileMode.OpenOrCreate);
            var jsonSerializer = new DataContractJsonSerializer(typeof(T));
            jsonSerializer.WriteObject(fileStream, data);
        }

        private static T DeserializeFromJSONFile(string path, string actualClassVersion)
        {
            using var fileStream = new FileStream(path, FileMode.Open);
            var jsonSerializer = new DataContractJsonSerializer(typeof(T));
            dynamic tmp = jsonSerializer.ReadObject(fileStream);

            if (tmp.Version.ToString() == actualClassVersion)
            {
                return (T)tmp;
            }

            throw new InvalidCastException("Different version of classes");
        }

        private static void SerializeToXmlFile(string path, T data)
        {
            using var fileStream = new FileStream(path, FileMode.OpenOrCreate);
            var xmlSerializer = new DataContractSerializer(typeof(T));
            xmlSerializer.WriteObject(fileStream, data);
        }

        private static T DeserializeFromXmlFile(string path, string actualClassVersion)
        {
            using var fileStream = new FileStream(path, FileMode.Open);
            var xmlSerializer = new DataContractSerializer(typeof(T));
            dynamic tmp = xmlSerializer.ReadObject(fileStream);

            if (tmp.Version.ToString() == actualClassVersion)
            {
                return (T)tmp;
            }

            throw new InvalidCastException("Different version of classes");
        }

        public static void Serialize(string path, T data, SerializationType serializationType)
        {
            switch (serializationType)
            {
                case SerializationType.Binary: SerializeToBinaryFile(path, data); break;
                case SerializationType.JSON: SerializeToJSONFile(path, data); break;
                case SerializationType.XML: SerializeToXmlFile(path, data); break;
            }
        }

        public static T Deserialize(string path, string actualClassVersion, SerializationType serializationType)
        {
            return serializationType switch
            {
                SerializationType.Binary => DeserializeFromBinaryFile(path, actualClassVersion),
                SerializationType.JSON => DeserializeFromJSONFile(path, actualClassVersion),
                SerializationType.XML => DeserializeFromXmlFile(path, actualClassVersion),
                _ => null,
            };
        }
    }
}