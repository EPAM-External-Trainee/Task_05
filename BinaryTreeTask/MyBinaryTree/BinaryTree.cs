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

        public int CountOfNodes => GetCountOfNodes(Root);

        private int GetCountOfNodes(TreeNode<T> root) => root == null ? 0 : 1 + GetCountOfNodes(root.LeftNode) + GetCountOfNodes(root.RightNode);

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

            TreeNode<T> newNode = new TreeNode<T>(data);
            if (Root == null)
            {
                Root = newNode;
                return;
            }

            TreeNode<T> currentNode = Root;
            TreeNode<T> previousNode = currentNode;

            while (currentNode != null)
            {
                if (data.CompareTo(currentNode.Data) == -1)
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
            Root = DeleteNode(Root, data);
        }

        private TreeNode<T> DeleteNode(TreeNode<T> root, T data)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Data.CompareTo(data) > 0)
            {
                root.LeftNode = DeleteNode(root.LeftNode, data);
            }
            else if (root.Data.CompareTo(data) == -1)
            {
                root.RightNode = DeleteNode(root.RightNode, data);
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

                root.RightNode = DeleteNode(root.RightNode, root.Data);
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

        public T Search(int testMark)
        {
            if (Root == null)
            {
                return null;
            }
            else
            {
                TreeNode<T> currentNode = Root;
                while (true)
                {
                    if (currentNode.Data.Mark > testMark)
                    {
                        currentNode = currentNode.LeftNode;
                    }
                    else if (currentNode.Data.Mark < testMark)
                    {
                        currentNode = currentNode.RightNode;
                    }
                    else
                    {
                        return currentNode.Data;
                    }
                }
            }
        }

        public void BalanceTree()
        {
            if (IsBalanced)
            {
                return;
            }

            List<TreeNode<T>> nodes = new List<TreeNode<T>>();
            ConvertTreeNodesToListNodes(Root, nodes);
            Root = BuildBalancedTree(nodes, 0, nodes.Count - 1);
        }

        private TreeNode<T> BuildBalancedTree(List<TreeNode<T>> nodes, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int middle = (start + end) / 2;
            var node = nodes[middle];

            node.LeftNode = BuildBalancedTree(nodes, start, middle - 1);
            node.RightNode = BuildBalancedTree(nodes, middle + 1, end);

            return node;
        }

        private void ConvertTreeNodesToListNodes(TreeNode<T> currentNode, List<TreeNode<T>> nodes)
        {
            if (currentNode == null)
            {
                return;
            }

            ConvertTreeNodesToListNodes(currentNode.LeftNode, nodes);
            nodes.Add(currentNode);
            ConvertTreeNodesToListNodes(currentNode.RightNode, nodes);
        }

        private List<Student> GetListOfStudentsFromTree(BinaryTree<Student> binaryTree)
        {
            List<Student> thisStudents = new List<Student>();
            MyConverter.ConvertBinaryTreeToList(binaryTree.Root, thisStudents);
            return thisStudents;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BinaryTree<T>))
            {
                return false;
            }

            BinaryTree<Student> bt = obj as BinaryTree<Student>;
            List<Student> thisStudents = GetListOfStudentsFromTree(this as BinaryTree<Student>);
            List<Student> otherStudents = GetListOfStudentsFromTree(bt);
            return Enumerable.SequenceEqual(thisStudents, otherStudents) && IsBalanced == bt.IsBalanced && Depth == bt.Depth && CountOfNodes == bt.CountOfNodes;
        }

        public override int GetHashCode() => HashCode.Combine(Root, Depth, CountOfNodes, IsBalanced, GetListOfStudentsFromTree(this as BinaryTree<Student>).GetHashCode());

        public override string ToString()
        {
            List<Student> thisStudents = GetListOfStudentsFromTree(this as BinaryTree<Student>);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Student student in thisStudents)
            {
                stringBuilder.Append(student).Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}