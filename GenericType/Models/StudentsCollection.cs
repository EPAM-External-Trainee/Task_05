using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GenericType.Models
{
    [Serializable]
    [DataContract]
    public class StudentsCollection<T> : ICollection<T> where T : Student
    {
        public StudentsCollection() { }

        public StudentsCollection(IEnumerable<T> students) => Students = students.ToList();

        [DataMember]
        public List<T> Students { get; set; }

        [DataMember]
        public Version Version { get; set; } = new Version("1.1.1.0");

        public int Count => Students.Count;

        public bool IsReadOnly => false;

        public void Add(T item) => Students.Add(item);

        public void Clear() => Students.Clear();

        public bool Contains(T item) => Students.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => Students.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => Students.GetEnumerator();

        public bool Remove(T item) => Students.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override bool Equals(object obj) => obj is StudentsCollection<T> collection && Enumerable.SequenceEqual(Students, collection.Students) && Count == collection.Count && IsReadOnly == collection.IsReadOnly;

        public override int GetHashCode() => HashCode.Combine(Students, Count, IsReadOnly);

        public override string ToString()
        {
            var studentsString = new StringBuilder();
            Students.ForEach(s => studentsString.Append(s).Append("\n"));
            return studentsString.ToString();
        }
    }
}
