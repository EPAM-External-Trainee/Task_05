using GenericType.Models;
using System.Collections.Generic;

namespace GenericType.Interfaces
{
    /// <summary>Interface that describes <see cref="Student"/>'s collection</summary>
    /// <typeparam name="T"><see cref="Student"/></typeparam>
    public interface IStudentsCollection<T> : ICollection<T> where T : Student
    {
        /// <summary><see cref="List{T}"/> of <see cref="Student"/>'s</summary>
        List<T> Students { get; set; }
    }
}