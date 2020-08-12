using BinaryTree.Models;

namespace BinaryTree.MyBinaryTree
{
    public class TreeNode<T> where T : Student
    {
        public TreeNode(T data) => Data = data;

        public TreeNode<T> LeftNode { get; set; }

        public TreeNode<T> RightNode { get; set; }

        public T Data { get; set; }
    }
}