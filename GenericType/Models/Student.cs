using GenericType.Interfaces;
using System;
using System.Runtime.Serialization;

namespace GenericType.Models
{
    [Serializable]
    [DataContract]
    public class Student : ISerialize<Student>, IClassVersion
    {
        public Student() { }

        public Student(string name, int age, DateTime birthday)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Age = age;
            Birthday = birthday;
        }

        [DataMember]
        public Version Version { get; set; } = new Version("1.1.1.0");

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        public override bool Equals(object obj) => obj is Student student && Name == student.Name && Age == student.Age && Birthday == student.Birthday;

        public override int GetHashCode() => HashCode.Combine(Name, Age, Birthday);

        public override string ToString() => $"{Name};{Age};{Birthday.ToShortDateString()}";
    }
}