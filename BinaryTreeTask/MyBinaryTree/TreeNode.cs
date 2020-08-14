using BinaryTree.Models;

namespace BinaryTree.MyBinaryTree
{
    /// <summary>Class that describes <see cref="BinaryTree{T}"/> node</summary>
    /// <typeparam name="T"><see cref="Student"/></typeparam>
    public class TreeNode<T> where T : Student
    {
        /// <summary></summary>
        /// <param name="data"></param>
        public TreeNode(T data) => Data = data;

        /// <summary>Instance constructor with parameters</summary>
        /// <param name="data">Data</param>
        /// <param name="leftNode">Left node</param>
        /// <param name="rightNode">Right node</param>
        public TreeNode(T data, TreeNode<T> leftNode, TreeNode<T> rightNode)
        {
            Data = data;
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        /// <summary>Left node</summary>
        public TreeNode<T> LeftNode { get; set; }

        /// <summary>Right node</summary>
        public TreeNode<T> RightNode { get; set; }

        /// <summary>Data</summary>
        public T Data { get; set; }
    }
}