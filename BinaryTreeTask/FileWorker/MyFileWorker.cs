using BinaryTree.Enums;
using BinaryTree.Interfaces;
using BinaryTree.Models;
using BinaryTree.MyBinaryTree;
using System;

namespace BinaryTree.FileWorker
{
    /// <summary>Class that describes working with files</summary>
    public static class MyFileWorker
    {
        /// <summary><see cref="IXmlFileWorker"/> object</summary>
        private static readonly IXmlFileWorker xmlFileWorker = new XmlWorker();

        /// <summary>Serializing the <see cref="BinaryTree{T}"/> to the selected <see cref="SerializationType"/></summary>
        /// <param name="path">Path to file</param>
        /// <param name="binaryTree"><see cref="BinaryTree{T}"/></param>
        /// <param name="type"><see cref="SerializationType"/></param>
        public static void SerializeBinaryTree(string path, BinaryTree<Student> binaryTree, SerializationType type)
        {
            switch (type)
            {
                case SerializationType.XML: xmlFileWorker.SerializeBinaryTree(path, binaryTree); return;
            }
        }

        /// <summary>Deserializing the <see cref="BinaryTree{T}"/> to the selected <see cref="DeserializationType"/></summary>
        /// <param name="path">Path to file</param>
        /// <param name="type"><see cref="DeserializationType"/></param>
        /// <returns><see cref="BinaryTree{T}"/> from file</returns>
        public static BinaryTree<Student> DeserializeBinaryTree(string path, DeserializationType type) => type switch
        {
            DeserializationType.XML => xmlFileWorker.DeserializeBinaryTree(path),
            _ => throw new NotSupportedException(),
        };
    }
}