using GenericType.Models;
using GenericTypeNUnitTest.FileWorkTests.Abstract;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTypeNUnitTest.FileWorkTests.SerializationTest
{
    [Description("Class for testing serialization of objects in various file formats ")]
    [TestFixture]    
    class SerealizationTests : GenericFileWorker
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


    }
}