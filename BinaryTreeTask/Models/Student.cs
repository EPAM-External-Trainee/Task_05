using BinaryTree.Enums;
using BinaryTree.Interfaces;
using System;

namespace BinaryTree.Models
{
    /// <summary>Class that describes student</summary>
    [Serializable]
    public class Student : ITestResult, IComparable<Student>
    {
        /// <summary>Test result mark</summary>
        private int _mark;

        /// <summary>The instance constructor by default</summary>
        public Student() { }

        /// <summary>Instance constructor with parameters</summary>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="subject"><see cref="Enums.Subject"/></param>
        /// <param name="testDate">Date and time of the test</param>
        /// <param name="mark">Test mark</param>
        public Student(string name, string surname, Subject subject, DateTime testDate, int mark)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Subject = subject;
            TestDate = testDate;
            Mark = mark;
        }

        /// <summary>Student name</summary>
        public string Name { get; set; }

        /// <summary>Student surname</summary>
        public string Surname { get; set; }

        /// <inheritdoc cref="ITest.Subject"/>
        public Subject Subject { get; set; }

        /// <inheritdoc cref="ITest.TestDate"/>
        public DateTime TestDate { get; set; }

        /// <inheritdoc cref="ITestResult.Mark"/>
        public int Mark
        {
            get => _mark;

            set
            {
                if (value > 0 && value < 11)
                {
                    _mark = value;
                }
                else
                {
                    throw new ArgumentException("The test mark can't be less than or equal to 0 or greater than 10");
                }
            }
        }

        /// <inheritdoc cref="IComparable{T}.CompareTo(T)"/>
        public int CompareTo(Student otherStudent) => Mark.CompareTo(otherStudent?.Mark);

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is Student student && Name == student.Name && Surname == student.Surname && Subject == student.Subject && TestDate == student.TestDate && Mark == student.Mark;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Name, Surname, Subject, TestDate, Mark);

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => $"Student: {Name} {Surname}. Test subject: {Enum.GetName(typeof(Subject), Subject)}. Test date: {TestDate.ToShortDateString()}. Mark: {Mark}.";
    }
}