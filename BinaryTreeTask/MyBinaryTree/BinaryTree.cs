using BinaryTree.Converter;
using BinaryTree.Interfaces;
using BinaryTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree.MyBinaryTree
{
    /// <summary>Class that describes binary tree</summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : IBinaryTree<T> where T : Student
    {
        /// <summary>Instance constructor with parameters</summary>
        /// <param name="students"><see cref="IEnumerable{T}"/> of students</param>
        public BinaryTree(IEnumerable<T> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException("The source data must be initialized");
            }
            else
            {
                foreach (T student in students)
                {
                    Add(student);
                }
            }
        }

        /// <inheritdoc cref="IBinaryTree.Root"/>
        public TreeNode<T> Root { get; set; }

        /// <inheritdoc cref="IBinaryTree.Depth"/>
        public int Depth => GetMaxDepth(Root);

        /// <inheritdoc cref="IBinaryTree.IsBalanced"/>
        public bool IsBalanced => IsBalancedTree(Root);

        /// <summary>Search for maximum depth</summary>
        /// <param name="root"><see cref="BinaryTree{T}.Root"/></param>
        /// <returns>Max depth</returns>
        private int GetMaxDepth(TreeNode<T> treeNode) => treeNode == null ? 0 : 1 + Math.Max(GetMaxDepth(treeNode.LeftNode), GetMaxDepth(treeNode.RightNode));

        /// <summary>Check for a balanced tree</summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private bool IsBalancedTree(TreeNode<T> root) => root == null ? true : Math.Abs(GetMaxDepth(root.LeftNode) - GetMaxDepth(root.RightNode)) <= 1 && IsBalancedTree(root.LeftNode) && IsBalancedTree(root.RightNode);

        /// <inheritdoc cref="IBinaryTree.Add(T)"/>
        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("The added data must be initialized");
            }

            if (Root == null)
            {
                Root = new TreeNode<T>(data);
                return;
            }

            TreeNode<T> newNode = new TreeNode<T>(data);
            TreeNode<T> currentNode = Root;
            TreeNode<T> previousNode = currentNode;

            while (currentNode != null)
            {
                if (data.CompareTo(currentNode.Data) < 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.LeftNode;
                }
                else if (data.CompareTo(currentNode.Data) > 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.RightNode;
                }
                else
                {
                    throw new ArgumentException("A node with this data already exists");
                }
            }

            if (data.CompareTo(previousNode.Data) == -1)
            {
                previousNode.LeftNode = newNode;
            }
            else
            {
                previousNode.RightNode = newNode;
            }
        }

        /// <inheritdoc cref="IBinaryTree.Remove(T)"/>
        public void Remove(T data)
        {
            if (data != null)
            {
                Root = RemoveNode(Root, data);
            }
        }

        /// <summary>Removing a node from the tree</summary>
        /// <param name="node"><see cref="BinaryTree{T}.Root"/></param>
        /// <param name="data">Data</param>
        /// <returns>new <see cref="BinaryTree{T}.Root"/></returns>
        private TreeNode<T> RemoveNode(TreeNode<T> node, T data)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Data.CompareTo(data) > 0)
            {
                node.LeftNode = RemoveNode(node.LeftNode, data);
            }
            else if (node.Data.CompareTo(data) == -1)
            {
                node.RightNode = RemoveNode(node.RightNode, data);
            }
            else
            {
                if (node.LeftNode == null)
                {
                    return node.RightNode;
                }
                else if (node.RightNode == null)
                {
                    return node.LeftNode;
                }

                node.Data = MinValue(node.RightNode);
                node.RightNode = RemoveNode(node.RightNode, node.Data);
            }

            return node;
        }

        /// <summary>Search smallest in the right subtree</summary>
        /// <param name="node">Right subtree root</param>
        /// <returns>Smallest in the right subtree data</returns>
        private T MinValue(TreeNode<T> node)
        {
            T minValue = node.Data;
            while (node.LeftNode != null)
            {
                minValue = node.LeftNode.Data;
                node = node.LeftNode;
            }
            return minValue;
        }

        /// <inheritdoc cref="IBinaryTree.Search(T)"/>
        public T Search(T student)
        {
            if (Root == null)
            {
                return null;
            }
            else
            {
                TreeNode<T> currentNode = Root;
                while (currentNode != null)
                {
                    if (currentNode.Data.CompareTo(student) > 0)
                    {
                        currentNode = currentNode.LeftNode;
                    }
                    else if (currentNode.Data.CompareTo(student) == -1)
                    {
                        currentNode = currentNode.RightNode;
                    }
                    else
                    {
                        return currentNode.Data;
                    }
                }
                return null;
            }
        }

        /// <inheritdoc cref="IBinaryTree.BalanceTree"/>
        public void BalanceTree()
        {
            if (IsBalanced)
            {
                return;
            }

            List<TreeNode<T>> nodes = MyConverter.ConvertTreeNodesToListNodes(Root).ToList();
            Root = BuildBalancedTree(nodes.OrderBy(n => n.Data.Mark).ToList(), 0, nodes.Count);
        }

        /// <summary>Tree balancing</summary>
        /// <param name="nodes">Nodes of the tree</param>
        /// <param name="min">Min value of nodes count</param>
        /// <param name="max">Max value of nodes count</param>
        /// <returns>new <see cref="BinaryTree{T}.Root"/></returns>
        private TreeNode<T> BuildBalancedTree(List<TreeNode<T>> nodes, int min, int max)
        {
            if (min == max)
            {
                return null;
            }

            int middle = min + (max - min) / 2;
            return new TreeNode<T>(nodes[middle].Data, BuildBalancedTree(nodes, min, middle), BuildBalancedTree(nodes, middle + 1, max));
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (!(obj is BinaryTree<T>))
            {
                return false;
            }

            BinaryTree<Student> bt = obj as BinaryTree<Student>;
            List<Student> thisStudents = MyConverter.ConvertBinaryTreeToIEnumerable(Root).ToList() as List<Student>;
            List<Student> otherStudents = MyConverter.ConvertBinaryTreeToIEnumerable(bt.Root).ToList() as List<Student>;
            return Enumerable.SequenceEqual(thisStudents, otherStudents) && IsBalanced == bt.IsBalanced && Depth == bt.Depth;
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Root, Depth, IsBalanced, MyConverter.ConvertBinaryTreeToIEnumerable(Root).ToList() as List<Student>).GetHashCode();

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            List<Student> thisStudents = MyConverter.ConvertBinaryTreeToIEnumerable(Root).ToList() as List<Student>;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Student student in thisStudents)
            {
                stringBuilder.Append(student).Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}