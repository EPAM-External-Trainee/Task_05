using BinaryTree.Enums;
using BinaryTree.Interfaces;
using System;

namespace BinaryTree.Models
{
    [Serializable]
    public class Student : ITest, IComparable<Student>
    {
        private int _mark;

        public Student(string name, string surname, Subject subject, DateTime testDate, int mark)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Subject = subject;
            TestDate = testDate;
            Mark = mark;
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Subject Subject { get; set; }

        public DateTime TestDate { get; set; }

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

        public int CompareTo(Student other) => Mark.CompareTo(other?.Mark);

        public override bool Equals(object obj) => obj is Student student && Name == student.Name && Surname == student.Surname && Subject == student.Subject && TestDate == student.TestDate && Mark == student.Mark;

        public override int GetHashCode() => HashCode.Combine(Name, Surname, Subject, TestDate, Mark);

        public override string ToString() => $"Student: {Name} {Surname}. Test subject: {Enum.GetName(typeof(Subject), Subject)}. Test date: {TestDate.ToShortDateString()}. Mark: {Mark}.";
    }
}