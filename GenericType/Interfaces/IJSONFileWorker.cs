namespace GenericType.Interfaces
{
    public interface IJSONFileWorker
    {
        void SerializeToJSONFile<T>(string path, T data) where T : class;

        T DeserializeFromJSONFile<T>(string path, string actualClassVersion) where T : class;
    }
}