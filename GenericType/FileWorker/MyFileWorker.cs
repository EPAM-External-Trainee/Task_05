using GenericType.Enums;
using GenericType.FileWorker;
using GenericType.Interfaces;

namespace GenericType.Serializers
{
    public static class MyFileWorker<T> where T : class
    {
        private static readonly IBinaryFileWorker binaryFileWorker = new BinaryFileWorker();
        private static readonly IJSONFileWorker jSONFileWorker = new JSONFileWorker();
        private static readonly IXmlFileWorker xmlFileWorker = new XmlFileWorker();

        public static void Serialize(string path, T data, SerializationType serializationType)
        {
            switch (serializationType)
            {
                case SerializationType.Binary: binaryFileWorker.SerializeToBinaryFile(path, data); return;
                case SerializationType.JSON: jSONFileWorker.SerializeToJSONFile(path, data); return;
                case SerializationType.XML: xmlFileWorker.SerializeToXmlFile(path, data); return;
            }
        }

        public static T Deserialize(string path, string actualClassVersion, DeserializationType deserializationType)
        {
            return deserializationType switch
            {
                DeserializationType.Binary => binaryFileWorker.DeserializeFromBinaryFile<T>(path, actualClassVersion),
                DeserializationType.JSON => jSONFileWorker.DeserializeFromJSONFile<T>(path, actualClassVersion),
                DeserializationType.XML => xmlFileWorker.DeserializeFromXmlFile<T>(path, actualClassVersion),
                _ => null,
            };
        }
    }
}