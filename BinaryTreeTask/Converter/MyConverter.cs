using BinaryTree.Models;
using BinaryTree.MyBinaryTree;
using System.Collections.Generic;

namespace BinaryTree.Converter
{
    public static class MyConverter
    {
        public static IEnumerable<T> ConvertBinaryTreeToList<T>(TreeNode<T> root) where T : Student
        {
            List<T> students = new List<T>();
            GetListFromBinaryTree(root, students);
            return students;
        } 

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

        public static IEnumerable<TreeNode<T>> ConvertTreeNodesToListNodes<T>(TreeNode<T> root) where T : Student
        {
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();
            GetListFromTreeNodes(root, nodes);
            return nodes;
        }

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