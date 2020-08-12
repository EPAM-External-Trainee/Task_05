using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace GenericType.Serializers
{
    public static class MySerializer<T> where T : class
    {
        public static void SerializeToBinaryFile(string path, T data)
        {
            try
            {
                using var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, data);
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public static T DeserializeFromBinaryFile(string path, string actualClassVersion)
        {
            try
            {
                using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                var binaryFormatter = new BinaryFormatter();

                dynamic tmp = binaryFormatter.Deserialize(fileStream);
                if (tmp.Version.ToString() == actualClassVersion)
                {
                    return (T)tmp;
                }

                throw new InvalidCastException("Error on deserialization of different versions of classes");
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public static void SerializeToJSONFile(string path, T data)
        {
            try
            {
                using var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                var jsonSerializer = new DataContractJsonSerializer(typeof(T));
                jsonSerializer.WriteObject(fileStream, data);
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public static T DeserializeFromJSONFile(string path, string actualClassVersion)
        {
            try
            {
                using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                var jsonSerializer = new DataContractJsonSerializer(typeof(T));

                dynamic tmp = jsonSerializer.ReadObject(fileStream);
                if (tmp.Version.ToString() == actualClassVersion)
                {
                    return (T)tmp;
                }

                throw new InvalidCastException("Error on deserialization of different versions of classes");
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }

        }

        public static void SerializeToXmlFile(string path, T data)
        {
            try
            {
                using var fileStream = new FileStream(path, FileMode.OpenOrCreate);
                var xmlSerializer = new DataContractSerializer(typeof(T));
                xmlSerializer.WriteObject(fileStream, data);
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }

        }

        public static T DeserializeFromXmlFile(string path, string actualClassVersion)
        {
            try
            {
                using var fileStream = new FileStream(path, FileMode.Open);
                var xmlSerializer = new DataContractSerializer(typeof(T));

                dynamic tmp = xmlSerializer.ReadObject(fileStream);
                if (tmp.Version.ToString() == actualClassVersion)
                {
                    return (T)tmp;
                }

                throw new InvalidCastException("Error on deserialization of different versions of classes");
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
    }
}