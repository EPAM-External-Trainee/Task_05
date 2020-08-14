using BinaryTree.Converter;
using BinaryTree.Interfaces;
using BinaryTree.Models;
using BinaryTree.MyBinaryTree;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace BinaryTree.FileWorker
{
    /// <summary>Class that implements <see cref="IXmlFileWorker"/> for working with xml files</summary>
    internal class XmlWorker : IXmlFileWorker
    {
        /// <inheritdoc cref="IFileWorker.SerializeBinaryTree(string, BinaryTree{Student})"/>
        public void SerializeBinaryTree(string path, BinaryTree<Student> binaryTree)
        {
            List<Student> students = MyConverter.ConvertBinaryTreeToIEnumerable(binaryTree.Root).ToList();
            using FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            var xmlSerializer = new XmlSerializer(typeof(List<Student>));
            xmlSerializer.Serialize(fs, students);
        }

        /// <inheritdoc cref="IFileWorker.DeserializeBinaryTree(string)"/>
        public BinaryTree<Student> DeserializeBinaryTree(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            return new BinaryTree<Student>(xmlSerializer.Deserialize(fs) as List<Student>);
        }
    }
}