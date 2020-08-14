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

        /// <summary>Serializing the <see cref="BinaryTree{T}"/> to the selected <see cref="SerializeType"/></summary>
        /// <param name="path">Path to file</param>
        /// <param name="binaryTree"><see cref="BinaryTree{T}"/></param>
        /// <param name="type"><see cref="SerializeType"/></param>
        public static void SerializeBinaryTree(string path, BinaryTree<Student> binaryTree, SerializeType type)
        {
            switch (type)
            {
                case SerializeType.XML: xmlFileWorker.SerializeBinaryTree(path, binaryTree); return;
            }
        }

        /// <summary>Deserializing the <see cref="BinaryTree{T}"/> to the selected <see cref="DeserializeType"/></summary>
        /// <param name="path">Path to file</param>
        /// <param name="type"><see cref="DeserializeType"/></param>
        /// <returns><see cref="BinaryTree{T}"/> from file</returns>
        public static BinaryTree<Student> DeserializeBinaryTree(string path, DeserializeType type) => type switch
        {
            DeserializeType.XML => xmlFileWorker.DeserializeBinaryTree(path),
            _ => throw new NotSupportedException(),
        };
    }
}