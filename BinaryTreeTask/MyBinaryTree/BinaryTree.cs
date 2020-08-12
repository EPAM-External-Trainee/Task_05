using BinaryTree.Models;
using System;
using System.Collections.Generic;
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

        public TreeNode<T> Root { get; set; }

        // Максимальная глубина
        public int Depth => GetMaxDepth(Root);

        // Рекурскивный поиск максмальной глубины
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

        // Количество всех узлов
        public int CountOfNodes => GetCountOfNodes(Root);

        // Получение числа всех узлов
        private int GetCountOfNodes(TreeNode<T> root) => root == null ? 0 : 1 + GetCountOfNodes(root.LeftNode) + GetCountOfNodes(root.RightNode);

        // Получение максимальной глубины(высоты) поддерева
        private int GetHeight(TreeNode<T> treeNode) => treeNode == null ? 0 : 1 + Math.Max(GetHeight(treeNode.LeftNode), GetHeight(treeNode.RightNode));

        // Проверка на текущее состояние дерева
        public bool IsBalanced => IsBalancedTree(Root);

        // Проверка текущего состояние дерева
        private bool IsBalancedTree(TreeNode<T> root)
        {
            if (root == null)
            {
                return true;
            }

            return Math.Abs(GetHeight(root.LeftNode) - GetHeight(root.RightNode)) <= 1 && IsBalancedTree(root.LeftNode) && IsBalancedTree(root.RightNode);

        }

        // Добавление
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

        // TODO: сделать удаление
        public void Remove(T data)
        {
            Root = DeleteNode(Root, data);
        }

        // Вспомогательный метод для удаления
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

        /// Вспомогательный метод для удаления
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

        // TODO: сделать поиск(бинарный) по оценке
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

        // TODO: сделать балансировку
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

        // Вспомогательный метод для балансировки
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

        // Вспомогательный метод для балансировки
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
    }
}