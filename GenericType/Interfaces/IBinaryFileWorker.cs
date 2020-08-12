namespace GenericType.Interfaces
{
    public interface IBinaryFileWorker
    {
        void SerializeToBinaryFile<T>(string path, T data) where T : class;

        T DeserializeFromBinaryFile<T>(string path, string actualClassVersion) where T : class;
    }
}