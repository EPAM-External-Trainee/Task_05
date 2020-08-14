namespace GenericType.Interfaces
{
    /// <summary>Interface that describes basic operations for working with data of custom generic types</summary>
    public interface IFileWorker
    {
        /// <summary>Serializing data to a file</summary>
        /// <typeparam name="T"><see cref="class"/></typeparam>
        /// <param name="path">Path to file</param>
        /// <param name="data">Serializable class</param>
        void Serialize<T>(string path, T data) where T : class;

        /// <summary>Deserializing data to a file</summary>
        /// <typeparam name="T"><see cref="class"/></typeparam>
        /// <param name="path">Path to file</param>
        /// <param name="actualClassVersion">Actual class version</param>
        /// <returns>Deserialized data</returns>
        T Deserialize<T>(string path, string actualClassVersion) where T : class;
    }
}