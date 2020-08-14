using BinaryTree.Enums;
using BinaryTree.FileWorker;
using BinaryTree.Models;
using BinaryTree.MyBinaryTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BinaryTreeNUnitTest.FileWorkerTests
{
    [Description("Class for testing FileWorker class methods")]
    [TestFixture]
    public class FileWorkerTests
    {
        private BinaryTree<Student> _binaryTree;
        private const string _pathToXmlFile = @"..\..\..\FileWorkerTests\BinaryTree.xml";

        [Description("Initialization of a binary tree")]
        [OneTimeSetUp]
        public void InitializeBinaryTree()
        {
            _binaryTree = new BinaryTree<Student>(new List<Student>()
            {
                new Student("Vasya", "Vasiliev", Subject.Mathematics, new DateTime(2020, 5, 10), 90),
                new Student("Petya", "Petrov", Subject.Geography, new DateTime(2020, 5, 16), 60),
                new Student("Ilya", "Iliev", Subject.Physics, new DateTime(2020, 5, 5), 40),
                new Student("Kolya", "Koloev", Subject.Mathematics, new DateTime(2020, 5, 10), 100),
                new Student("Alex", "Alexandrov", Subject.Geography, new DateTime(2020, 5, 16), 50),
                new Student("Kostya", "Kostin", Subject.Geography, new DateTime(2014, 6, 10), 10),
            });
        }

        [Description("Testing serialization of a tree to an xml file")]
        [Test]
        public void SerializeBinaryTree_Test()
        {
            MyFileWorker.SerializeBinaryTree(_pathToXmlFile, _binaryTree, SerializationType.XML);

            var expectedBinaryTree = MyFileWorker.DeserializeBinaryTree(_pathToXmlFile, DeserializationType.XML);

            Assert.AreEqual(_binaryTree, expectedBinaryTree);
        }

        [Description("Testing serialization of a tree to an xml file")]
        [Test]
        public void DeserializeBinaryTree_Test()
        {
            Assert.AreEqual(_binaryTree, MyFileWorker.DeserializeBinaryTree(_pathToXmlFile, DeserializationType.XML));
        }
    }
}