namespace GenericType.Interfaces
{
    /// <summary>Marker interface for serialization of any classes</summary>
    /// <typeparam name="T"><see cref="class"/></typeparam>
    public interface ISerialize<T> where T : class
    {
    }
}