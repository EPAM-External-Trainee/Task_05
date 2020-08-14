using BinaryTree.Models;
using BinaryTree.MyBinaryTree;

namespace BinaryTree.Interfaces
{
    /// <summary>Interface that describes methods for working with files</summary>
    public interface IFileWorker
    {
        /// <summary>Serializing the <see cref="BinaryTree{Student}"/></summary>
        /// <param name="path">File path</param>
        /// <param name="binaryTree"><see cref="BinaryTree{Student}"/></param>
        void SerializeBinaryTree(string path, BinaryTree<Student> binaryTree);

        /// <summary>Deserializing the <see cref="BinaryTree{Student}"/></summary>
        /// <param name="path">File path</param>
        /// <returns><see cref="BinaryTree{Student}"/></returns>
        BinaryTree<Student> DeserializeBinaryTree(string path);
    }
}