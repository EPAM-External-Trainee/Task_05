using BinaryTree.Enums;
using BinaryTree.Models;
using BinaryTree.MyBinaryTree;

namespace BinaryTree.FileWorker
{
    public static class MyFileWorker
    {
        public static void SerializeBinaryTree(string path, BinaryTree<Student> binaryTree, SerializeType type)
        {
            switch (type)
            {
                case SerializeType.XML: XmlWorker.SerializeBinaryTreeToXmlFile(path, binaryTree); return;
            }
        }

        public static BinaryTree<Student> DeserializeBinaryTree(string path, DeserializeType type) => type switch
        {
            DeserializeType.XML => XmlWorker.DeserializeBinaryTreeFromXmlFile(path),
            _ => null,
        };
    }
}