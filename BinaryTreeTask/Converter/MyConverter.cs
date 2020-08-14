using BinaryTree.Models;
using BinaryTree.MyBinaryTree;
using System.Collections.Generic;

namespace BinaryTree.Converter
{
    /// <summary>Class for converting <see cref="BinaryTree{T}"/> data</summary>
    public static class MyConverter
    {
        /// <summary>Convert <see cref="BinaryTree{T}"/> to <see cref="IEnumerable{T}"/></summary>
        /// <typeparam name="T"><see cref="Student"/></typeparam>
        /// <param name="root"><see cref="BinaryTree{T}.Root"/></param>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="Student"/>'s</returns>
        public static IEnumerable<T> ConvertBinaryTreeToIEnumerable<T>(TreeNode<T> root) where T : Student
        {
            List<T> students = new List<T>();
            GetListFromBinaryTree(root, students);
            return students;
        }

        /// <summary>Convert <see cref="BinaryTree{T}"/> to <see cref="List{T}"/></summary>
        /// <typeparam name="T"><see cref="Student"/></typeparam>
        /// <param name="root"><see cref="BinaryTree{T}.Root"/></param>
        /// <param name="students"><see cref="List{T}"/> of <see cref="Student"/>'s</param>
        private static void GetListFromBinaryTree<T>(TreeNode<T> root, List<T> students) where T : Student
        {
            if(root == null)
            {
                return;
            }

            students.Add(root.Data);
            GetListFromBinaryTree(root.LeftNode, students);
            GetListFromBinaryTree(root.RightNode, students);
        }

        /// <summary>Convert <see cref="TreeNode{T}"/>'s to <see cref="IEnumerable{T}"/></summary>
        /// <typeparam name="T"><see cref="Student"/></typeparam>
        /// <param name="root"><see cref="BinaryTree{T}.Root"/></param>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="TreeNode{T}"/>'s</returns>
        public static IEnumerable<TreeNode<T>> ConvertTreeNodesToListNodes<T>(TreeNode<T> root) where T : Student
        {
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();
            GetListFromTreeNodes(root, nodes);
            return nodes;
        }

        /// <summary>Convert <see cref="TreeNode{T}"/> to <see cref="List{T}"/></summary>
        /// <typeparam name="T"><see cref="Student"/></typeparam>
        /// <param name="root"><see cref="BinaryTree{T}.Root"/></param>
        /// <param name="nodes"><see cref="List{T}"/> of <see cref="TreeNode{T}"/>'s</param>
        private static void GetListFromTreeNodes<T>(TreeNode<T> root, List<TreeNode<T>> nodes) where T : Student
        {
            if (root == null)
            {
                return;
            }

            GetListFromTreeNodes(root.LeftNode, nodes);
            nodes.Add(root);
            GetListFromTreeNodes(root.RightNode, nodes);
        }
    }
}