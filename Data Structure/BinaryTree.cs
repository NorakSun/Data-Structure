using Data_Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;

        public BinaryTree()
        {
            root = null;
        }

        public void Add(T data)
        {
            root = AddRecursive(root, data);
        }

        private BinaryTreeNode<T> AddRecursive(BinaryTreeNode<T> node, T data)
        {
            if (node == null)
            {
                return new BinaryTreeNode<T>(data);
            }

            int compareResult = Comparer<T>.Default.Compare(data, node.Data);

            if (compareResult < 0)
            {
                node.Left = AddRecursive(node.Left, data);
            }
            else if (compareResult > 0)
            {
                node.Right = AddRecursive(node.Right, data);
            }

            return node;
        }

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(root, action);
        }

        private void PreOrderTraversal(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                action(node.Data);
                PreOrderTraversal(node.Left, action);
                PreOrderTraversal(node.Right, action);
            }
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(root, action);
        }

        private void InOrderTraversal(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, action);
                action(node.Data);
                InOrderTraversal(node.Right, action);
            }
        }

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(root, action);
        }

        private void PostOrderTraversal(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left, action);
                PostOrderTraversal(node.Right, action);
                action(node.Data);
            }
        }
    }

}
/*class Program
{
    static void Main()
    {
        BinaryTree<string> balancedTree = new BinaryTree<string>();
        balancedTree.Add("D");
        balancedTree.Add("B");
        balancedTree.Add("F");
        balancedTree.Add("A");
        balancedTree.Add("C");
        balancedTree.Add("E");
        balancedTree.Add("G");

        Console.WriteLine("InOrder Traversal:");
        balancedTree.InOrderTraversal(data => Console.Write($"{data} "));
    }
}
*/
