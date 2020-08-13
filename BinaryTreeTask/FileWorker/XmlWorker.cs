using BinaryTree.Converter;
using BinaryTree.Interfaces;
using BinaryTree.Models;
using BinaryTree.MyBinaryTree;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BinaryTree.FileWorker
{
    internal class XmlWorker : IXmlFileWorker
    {
        public void SerializeBinaryTreeToXmlFile(string path, BinaryTree<Student> binaryTree)
        {
            List<Student> students = new List<Student>();
            MyConverter.ConvertBinaryTreeToList(binaryTree.Root, students);

            using FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            xmlSerializer.Serialize(fs, students);
        }

        public BinaryTree<Student> DeserializeBinaryTreeFromXmlFile(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            return new BinaryTree<Student>(xmlSerializer.Deserialize(fs) as List<Student>);
        }
    }
}