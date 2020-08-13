using BinaryTree.Enums;
using BinaryTree.Models;
using BinaryTree.MyBinaryTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BinaryTreeNUnitTest
{
    [Description("Class for testing BinaryTree<T> class methods")]
    [TestFixture]
    public class BinaryTreeTests
    {
        private BinaryTree<Student> _sourceBinaryTree;
        private List<Student> _students;
        private Student _student;

        [Description("Tree initialization")]
        [SetUp]
        public void Setup()
        {
            _students = new List<Student>()
            {
                new Student("Vasya", "Vasiliev", Subject.Mathematics, new DateTime(2020, 5, 10), 9),
                new Student("Petya", "Petrov", Subject.Geography, new DateTime(2020, 5, 16), 6),
                new Student("Ilya", "Iliev", Subject.Physics, new DateTime(2020, 5, 5), 4),
                new Student("Kolya", "Koloev", Subject.Mathematics, new DateTime(2020, 5, 10), 10),
                new Student("Alex", "Alexandrov", Subject.Geography, new DateTime(2020, 5, 16), 5),
                new Student("Kostya", "Kostin", Subject.Geography, new DateTime(2014, 6, 10), 1),
            };

            _sourceBinaryTree = new BinaryTree<Student>(_students);
        }

        [Description("Testing Depth property")]
        [Test]
        public void Depth_Test()
        {
            Assert.AreEqual(4, _sourceBinaryTree.Depth);
        }

        [Description("Testing IsBalanced property")]
        [Test]
        public void IsBalanced_Test()
        {
            Assert.IsFalse(_sourceBinaryTree.IsBalanced);
        }

        [Description("Testing adding a node to a tree")]
        [TestCase("Ivan", "Ivanov", Subject.Geography, 2020, 08, 05, 7)]
        [TestCase("Daniel", "Danielov", Subject.Physics, 2020, 08, 06, 3)]
        [TestCase("Kirill", "Kirillov", Subject.Physics, 2020, 08, 06, 2)]
        public void Add_Test(string name, string surname, Subject subject, int year, int month, int day, int mark)
        {
            _student = new Student(name, surname, subject, new DateTime(year, month, day), mark);
            _sourceBinaryTree.Add(_student);
            Assert.IsNotNull(_sourceBinaryTree.Search(_student));
        }

        [Description("Testing adding an existing node in a tree")]
        [TestCase("Kostya", "Kostin", Subject.Geography, 2014, 6, 10, 1)]
        public void Add_Test_ArgumentExcpetion(string name, string surname, Subject subject, int year, int month, int day, int mark)
        {
            Assert.Throws<ArgumentException>(() => _sourceBinaryTree.Add(new Student(name, surname, subject, new DateTime(year, month, day), mark)));
        }

        [Description("Testing removing a node from a tree")]
        [TestCase("Kolya", "Koloev", Subject.Mathematics, 2020, 5, 10, 10)]
        [TestCase("Alex", "Alexandrov", Subject.Geography, 2020, 5, 16, 5)]
        [TestCase("Kostya", "Kostin", Subject.Geography, 2014, 6, 10, 1)]
        public void Remove_Test(string name, string surname, Subject subject, int year, int month, int day, int mark)
        {
            _student = new Student(name, surname, subject, new DateTime(year, month, day), mark);
            _sourceBinaryTree.Remove(_student);
            Assert.IsNull(_sourceBinaryTree.Search(_student));
        }

        [Description("Testing removing a node from a tree which isn't inside")]
        [TestCase("Kostya", "Kostin", Subject.Geography, 2014, 6, 10, 6)]
        public void Remove_Test_Null(string name, string surname, Subject subject, int year, int month, int day, int mark)
        {
            Student student = new Student(name, surname, subject, new DateTime(year, month, day), mark);
            _sourceBinaryTree.Remove(student);
            Assert.IsNull(_sourceBinaryTree.Search(student));
        }

        [Description("Testing the balancing of a tree")]
        [TestCaseSource(nameof(GetStudentsListTestCases))]
        public void BalanceTree_Test(List<Student> students)
        {
            var expectedBalancedTree = new BinaryTree<Student>(students);
            _sourceBinaryTree.BalanceTree();

            Assert.IsTrue(_sourceBinaryTree.IsBalanced);
            Assert.AreEqual(expectedBalancedTree, _sourceBinaryTree);
        }

        private static IEnumerable<object[]> GetStudentsListTestCases()
        {
            yield return new object[]
            {
                new List<Student>
                {
                    new Student("Petya", "Petrov", Subject.Geography, new DateTime(2020, 5, 16), 6),
                    new Student("Ilya", "Iliev", Subject.Physics, new DateTime(2020, 5, 5), 4),
                    new Student("Alex", "Alexandrov", Subject.Geography, new DateTime(2020, 5, 16), 5),
                    new Student("Kostya", "Kostin", Subject.Geography, new DateTime(2014, 6, 10), 1),
                    new Student("Kolya", "Koloev", Subject.Mathematics, new DateTime(2020, 5, 10), 10),
                    new Student("Vasya", "Vasiliev", Subject.Mathematics, new DateTime(2020, 5, 10), 9),
                }
            };
        }
    }
}