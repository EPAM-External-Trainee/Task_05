using BinaryTree.Models;
using BinaryTree.MyBinaryTree;

namespace BinaryTree.Interfaces
{
    /// <summary>Inteface that describes <see cref="BinaryTree{T}"/> node</summary>
    /// <typeparam name="T"><see cref="Student"/></typeparam>
    public interface ITreeNode<T> where T : Student
    {
        /// <summary>Left node</summary>
        TreeNode<T> LeftNode { get; set; }

        /// <summary>Right node</summary>
        TreeNode<T> RightNode { get; set; }

        /// <summary>Data</summary>
        T Data { get; set; }
    }
}