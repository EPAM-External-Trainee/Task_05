using GenericType.Interfaces;
using System;
using System.Runtime.Serialization;

namespace GenericType.Models
{
    /// <summary>Class that describes student</summary>
    [Serializable]
    [DataContract]
    public class Student : ISerialize<Student>, IClassVersion, IStudent
    {
        /// <summary>The instance constructor by default</summary>
        public Student() { }

        /// <summary>The instance constructor with parameters</summary>
        /// <param name="name">Student name</param>
        /// <param name="surname">Student surname</param>
        /// <param name="birthday">Student birthday</param>
        public Student(string name, string surname, DateTime birthday)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Birthday = birthday;
        }

        /// <inheritdoc cref="IClassVersion.Version"/>
        [DataMember]
        public Version Version { get; set; } = new Version("1.1.1.0");

        /// <inheritdoc cref="IStudent.Name"/>
        [DataMember]
        public string Name { get; set; }

        /// <inheritdoc cref="IStudent.Surname"/>
        [DataMember]
        public string Surname { get; set; }

        /// <inheritdoc cref="IStudent.Birthday"/>
        [DataMember]
        public DateTime Birthday { get; set; }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is Student student && Name == student.Name && Surname == student.Surname && Birthday == student.Birthday;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Name, Surname, Birthday);

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => $"{Name};{Surname};{Birthday.ToShortDateString()}";
    }
}