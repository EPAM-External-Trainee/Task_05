using GenericType.Enums;
using GenericType.Models;
using GenericType.Serializers;
using GenericTypeNUnitTest.FileWorkTests.Abstract;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace GenericTypeNUnitTest.FileWorkTests.SerializationTest
{
    [Description("Class for testing deserialization of objects from various file formats ")]
    [TestFixture]    
    class DeserializationTests : GenericFileWorker
    {
        [Description("Initialization of _student and _students objects")]
        [OneTimeSetUp]
        public void Initialization()
        {
            Student = new Student { Name = "Vasya", Surname = "Vasiliev", Birthday = new DateTime(2000, 12, 12, 13, 15, 15) };
            Students = new StudentsCollection<Student>(new List<Student>
            {
                new Student { Name = "Vasya", Surname = "Vasiliev", Birthday = new DateTime(2000, 12, 12, 13, 15, 15) },
                new Student { Name = "Petya", Surname = "Petrov", Birthday = new DateTime(1999, 5, 7, 8, 13, 6) },
                new Student { Name = "Kolya", Surname = "Koloev", Birthday = new DateTime(1995, 9, 7, 15, 10, 10) },
            });
        }

        [Description("Testing object deserialization from binary file")]
        [Test]
        public void DeserializeFromBinaryFile_Object_Test()
        {
            Assert.AreEqual(Student,  MyFileWorker<Student>.Deserialize(Path.Combine(_pathToFiles, typeof(Student).Name + _binaryFileExtension), Student.Version.ToString(), DeserializationType.Binary));
        }

        [Description("Testing object deserialization from binary file with different class version")]
        [TestCase("1.1.1.1")]
        public void DeserializeFromBinaryFile_Object_DiffernetClassVersion_Test_InvalidCastExcpetion(string newVersion)
        {
            Student student = new Student() { Version = new Version(newVersion) };
            Assert.Throws<InvalidCastException>(() => MyFileWorker<Student>.Deserialize(Path.Combine(_pathToFiles, typeof(Student).Name + _binaryFileExtension), student.Version.ToString(), DeserializationType.Binary));
        }

        [Description("Testing object deserialization from JSON file")]
        [Test]
        public void DeserializeFromJSONFile_Object_Test()
        {
            Assert.AreEqual(Student, MyFileWorker<Student>.Deserialize(Path.Combine(_pathToFiles, typeof(Student).Name + _jsonFileExtension), Student.Version.ToString(), DeserializationType.JSON));
        }

        [Description("Testing object deserialization from JSON file with different class version")]
        [TestCase("1.1.1.1")]
        public void DeserializeFromJSONFile_Object_DiffernetClassVersion_Test_InvalidCastExcpetion(string newVersion)
        {
            Student student = new Student() { Version = new Version(newVersion) };
            Assert.Throws<InvalidCastException>(() => MyFileWorker<Student>.Deserialize(Path.Combine(_pathToFiles, typeof(Student).Name + _jsonFileExtension), student.Version.ToString(), DeserializationType.JSON));
        }

        [Description("Testing object deserialization from XML file")]
        [Test]
        public void DeserializeFromXmlFile_Object_Test()
        {
            Assert.AreEqual(Student, MyFileWorker<Student>.Deserialize(Path.Combine(_pathToFiles, typeof(Student).Name + _xmlFileExtension), Student.Version.ToString(), DeserializationType.XML));
        }

        [Description("Testing object deserialization from XML file with different class version")]
        [TestCase("1.1.1.1")]
        public void DeserializeFromXmlFile_Object_DiffernetClassVersion_Test_InvalidCastExcpetion(string newVersion)
        {
            Student student = new Student() { Version = new Version(newVersion) };
            Assert.Throws<InvalidCastException>(() => MyFileWorker<Student>.Deserialize(Path.Combine(_pathToFiles, typeof(Student).Name + _xmlFileExtension), student.Version.ToString(), DeserializationType.XML));
        }

        [Description("Testing object collection deserialization from binary file")]
        [Test]
        public void DeserializeFromBinaryFile_ObjectCollection_Test()
        {
            Assert.AreEqual(Students, MyFileWorker<StudentsCollection<Student>>.Deserialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _binaryFileExtension), Students.Version.ToString(), DeserializationType.Binary));
        }

        [Description("Testing object collection deserialization from XML file with different class version")]
        [TestCase("1.1.1.1")]
        public void DeserializeFromBinaryFile_ObjectCollection_DiffernetClassVersion_Test_InvalidCastExcpetion(string newVersion)
        {
            StudentsCollection<Student> students = new StudentsCollection<Student>() { Version = new Version(newVersion) };
            Assert.Throws<InvalidCastException>(() => MyFileWorker<StudentsCollection<Student>>.Deserialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _binaryFileExtension), students.Version.ToString(), DeserializationType.Binary));
        }

        [Description("Testing object collection deserialization from JSON file")]
        [Test]
        public void DeserializeFromJSONFile_ObjectCollection_Test()
        {
            Assert.AreEqual(Students, MyFileWorker<StudentsCollection<Student>>.Deserialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _jsonFileExtension), Students.Version.ToString(), DeserializationType.JSON));
        }

        [Description("Testing object collection deserialization from JSON file with different class version")]
        [TestCase("1.1.1.1")]
        public void DeserializeFromJSONFile_ObjectCollection_DiffernetClassVersion_Test_InvalidCastExcpetion(string newVersion)
        {
            StudentsCollection<Student> students = new StudentsCollection<Student>() { Version = new Version(newVersion) };
            Assert.Throws<InvalidCastException>(() => MyFileWorker<StudentsCollection<Student>>.Deserialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _jsonFileExtension), students.Version.ToString(), DeserializationType.JSON));
        }

        [Description("Testing object collection deserialization from XML file")]
        [Test]
        public void DeserializeFromXmlFile_ObjectCollection_Test()
        {
            Assert.AreEqual(Students, MyFileWorker<StudentsCollection<Student>>.Deserialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _xmlFileExtension), Students.Version.ToString(), DeserializationType.XML));
        }

        [Description("Testing object collection deserialization from XML file with different class version")]
        [TestCase("1.1.1.1")]
        public void DeserializeFromXmlFile_ObjectCollection_DiffernetClassVersion_Test_InvalidCastExcpetion(string newVersion)
        {
            StudentsCollection<Student> students = new StudentsCollection<Student>() { Version = new Version(newVersion) };
            Assert.Throws<InvalidCastException>(() => MyFileWorker<StudentsCollection<Student>>.Deserialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _xmlFileExtension), students.Version.ToString(), DeserializationType.XML));
        }
    }
}