namespace GenericType.Interfaces
{
    public interface IXmlFileWorker
    {
        void SerializeToXmlFile<T>(string path, T data) where T : class;

        T DeserializeFromXmlFile<T>(string path, string actualClassVersion) where T : class;
    }
}