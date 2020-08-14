using GenericType.Models;
using System.Collections.Generic;

namespace GenericType.Interfaces
{
    public interface IStudentsCollection<T> : ICollection<T> where T : Student
    {
        List<T> Students { get; set; }
    }
}