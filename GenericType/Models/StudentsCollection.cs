using GenericType.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GenericType.Models
{
    /// <summary>lass that describes <see cref="Student"/> collection</summary>
    /// <typeparam name="T"><see cref="Student"/></typeparam>
    [Serializable]
    [DataContract]
    public class StudentsCollection<T> : IClassVersion, IStudentsCollection<T> where T : Student
    {
        /// <summary>The instance constructor by default</summary>
        public StudentsCollection() { }

        /// <summary>The instance constructor with parameters</summary>
        /// <param name="students"><see cref="IEnumerable{T}"/> of students</param>
        public StudentsCollection(IEnumerable<T> students) => Students = students.ToList();

        /// <summary><see cref="List{T}"/> of <see cref="Student"/>'s</summary>
        [DataMember]
        public List<T> Students { get; set; }

        /// <inheritdoc cref="IClassVersion.Version"/>
        [DataMember]
        public Version Version { get; set; } = new Version("1.1.1.0");

        /// <inheritdoc cref="List{T}.Count"/>
        public int Count => Students.Count;

        /// <summary>Read-only access</summary>
        public bool IsReadOnly => false;

        /// <inheritdoc cref="List{T}.Add(T)"/>
        public void Add(T item) => Students.Add(item);

        /// <inheritdoc cref="List{T}.Clear"/>
        public void Clear() => Students.Clear();

        /// <inheritdoc cref="List{T}.Contains(T)"/>
        public bool Contains(T item) => Students.Contains(item);

        /// <inheritdoc cref="List{T}.CopyTo(T[], int)"/>
        public void CopyTo(T[] array, int arrayIndex) => Students.CopyTo(array, arrayIndex);

        /// <inheritdoc cref=IEnumerable.GetEnumerator"/>
        public IEnumerator<T> GetEnumerator() => Students.GetEnumerator();

        /// <inheritdoc cref="List{T}.Remove(T)"/>
        public bool Remove(T item) => Students.Remove(item);

        /// <inheritdoc cref=IEnumerable.GetEnumerator"/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc cref=object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is StudentsCollection<T> collection && Enumerable.SequenceEqual(Students, collection.Students) && Count == collection.Count && IsReadOnly == collection.IsReadOnly;

        /// <inheritdoc cref=object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Students, Count, IsReadOnly);

        /// <inheritdoc cref=object.ToString"/>
        public override string ToString()
        {
            var studentsString = new StringBuilder();
            Students.ForEach(s => studentsString.Append(s).Append("\n"));
            return studentsString.ToString();
        }
    }
}