using BinaryTree.Models;
using BinaryTree.MyBinaryTree;

namespace BinaryTree.Interfaces
{
    public interface IFileWorker
    {
        void SerializeBinaryTreeToXmlFile(string path, BinaryTree<Student> binaryTree);

        BinaryTree<Student> DeserializeBinaryTreeFromXmlFile(string path);
    }
}