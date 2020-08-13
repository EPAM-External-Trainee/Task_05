using BinaryTree.Enums;
using BinaryTree.Interfaces;
using BinaryTree.Models;
using BinaryTree.MyBinaryTree;
using System;

namespace BinaryTree.FileWorker
{
    public static class MyFileWorker
    {
        private static readonly IXmlFileWorker xmlFileWorker = new XmlWorker();

        public static void SerializeBinaryTree(string path, BinaryTree<Student> binaryTree, SerializeType type)
        {
            switch (type)
            {
                case SerializeType.XML: xmlFileWorker.SerializeBinaryTreeToXmlFile(path, binaryTree); return;
            }
        }

        public static BinaryTree<Student> DeserializeBinaryTree(string path, DeserializeType type) => type switch
        {
            DeserializeType.XML => xmlFileWorker.DeserializeBinaryTreeFromXmlFile(path),
            _ => throw new NotSupportedException(),
        };
    }
}