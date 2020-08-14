using BinaryTree.Models;
using BinaryTree.MyBinaryTree;

namespace BinaryTree.Interfaces
{
    /// <summary>Interface that describes basic binary tree opearations</summary>
    /// <typeparam name="T"><see cref="Student"/></typeparam>
    public interface IBinaryTree<T> where T : Student
    {
        /// <summary>Root</summary>
        TreeNode<T> Root { get; set; }

        /// <summary>Max depth</summary>
        int Depth { get; }

        /// <summary>Information about the current state of the tree</summary>
        bool IsBalanced { get; }

        /// <summary>Adding data to the tree</summary>
        /// <param name="data">Data to add</param>
        void Add(T data);

        /// <summary>Deleting data from the tree</summary>
        /// <param name="data">Data to delete</param>
        void Remove(T data);

        /// <summary>Search for data in the tree</summary>
        /// <param name="data">Search data</param>
        /// <returns>Search data or null</returns>
        T Search(T data);

        /// <summary>To start the balancing tree</summary>
        void BalanceTree();
    }
}