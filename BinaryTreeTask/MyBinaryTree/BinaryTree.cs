using BinaryTree.Converter;
using BinaryTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree.MyBinaryTree
{
    public class BinaryTree<T> where T : Student
    {
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

        public TreeNode<T> Root { get; private set; }

        public int Depth => GetMaxDepth(Root);

        private int GetMaxDepth(TreeNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftDepth = GetHeight(root.LeftNode);
            int rightDepth = GetHeight(root.RightNode);

            return leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1;
        }

        private int GetHeight(TreeNode<T> treeNode) => treeNode == null ? 0 : 1 + Math.Max(GetHeight(treeNode.LeftNode), GetHeight(treeNode.RightNode));

        public bool IsBalanced => IsBalancedTree(Root);

        private bool IsBalancedTree(TreeNode<T> root)
        {
            if (root == null)
            {
                return true;
            }

            return Math.Abs(GetHeight(root.LeftNode) - GetHeight(root.RightNode)) <= 1 && IsBalancedTree(root.LeftNode) && IsBalancedTree(root.RightNode);

        }

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

        public void Remove(T data)
        {
            if (data != null)
            {
                Root = RemoveNode(Root, data);
            }
        }

        private TreeNode<T> RemoveNode(TreeNode<T> root, T data)
        {
            if (root == null)
            {
                throw new ArgumentException("The desired element is missing from the tree");
            }

            if (root.Data.CompareTo(data) > 0)
            {
                root.LeftNode = RemoveNode(root.LeftNode, data);
            }
            else if (root.Data.CompareTo(data) == -1)
            {
                root.RightNode = RemoveNode(root.RightNode, data);
            }
            else
            {
                if (root.LeftNode == null)
                {
                    return root.RightNode;
                }
                else if (root.RightNode == null)
                {
                    return root.LeftNode;
                }

                root.Data = MinValue(root.RightNode);
                root.RightNode = RemoveNode(root.RightNode, root.Data);
            }

            return root;
        }

        private T MinValue(TreeNode<T> root)
        {
            T minValue = root.Data;
            while (root.LeftNode != null)
            {
                minValue = root.LeftNode.Data;
                root = root.LeftNode;
            }
            return minValue;
        }

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

        public void BalanceTree()
        {
            if (IsBalanced)
            {
                return;
            }

            List<TreeNode<T>> nodes = MyConverter.ConvertTreeNodesToListNodes(Root).ToList();
            Root = BuildBalancedTree(nodes.OrderBy(n => n.Data.Mark).ToList(), 0, nodes.Count);
        }

        private TreeNode<T> BuildBalancedTree(List<TreeNode<T>> nodes, int min, int max)
        {
            if (min == max)
            {
                return null;
            }

            int middle = min + (max - min) / 2;
            return new TreeNode<T>(nodes[middle].Data, BuildBalancedTree(nodes, min, middle), BuildBalancedTree(nodes, middle + 1, max));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BinaryTree<T>))
            {
                return false;
            }

            BinaryTree<Student> bt = obj as BinaryTree<Student>;
            List<Student> thisStudents = MyConverter.ConvertBinaryTreeToList(Root).ToList() as List<Student>;
            List<Student> otherStudents = MyConverter.ConvertBinaryTreeToList(bt.Root).ToList() as List<Student>;
            return Enumerable.SequenceEqual(thisStudents, otherStudents) && IsBalanced == bt.IsBalanced && Depth == bt.Depth;
        }

        public override int GetHashCode() => HashCode.Combine(Root, Depth, IsBalanced, MyConverter.ConvertBinaryTreeToList(Root).ToList() as List<Student>).GetHashCode();

        public override string ToString()
        {
            List<Student> thisStudents = MyConverter.ConvertBinaryTreeToList(Root).ToList() as List<Student>;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Student student in thisStudents)
            {
                stringBuilder.Append(student).Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}