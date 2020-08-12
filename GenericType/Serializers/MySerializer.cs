using GenericType.Enums;
using GenericType.FileWorker;
using GenericType.Interfaces;

namespace GenericType.Serializers
{
    public static class MySerializer<T> where T : class
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

        public static T Deserialize(string path, string actualClassVersion, SerializationType serializationType)
        {
            return serializationType switch
            {
                SerializationType.Binary => binaryFileWorker.DeserializeFromBinaryFile<T>(path, actualClassVersion),
                SerializationType.JSON => jSONFileWorker.DeserializeFromJSONFile<T>(path, actualClassVersion),
                SerializationType.XML => xmlFileWorker.DeserializeFromXmlFile<T>(path, actualClassVersion),
                _ => null,
            };
        }
    }
}