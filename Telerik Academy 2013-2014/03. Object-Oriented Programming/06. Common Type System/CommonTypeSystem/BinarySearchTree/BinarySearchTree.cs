namespace BinarySearchTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IEnumerable<TreeNode<T>>, ICloneable where T : IComparable
    {
        private TreeNode<T> root;

        public BinarySearchTree()
        {
            this.Root = null;
        }

        public TreeNode<T> Root
        {
            get { return this.root; }
            set { this.root = value; }
        }

        public void Insert(T element)
        {
            this.root = Insert(element, this.root);
        }

        public void Remove(T element)
        {
            this.root = Remove(element, this.root);
        }

        public void RemoveMin()
        {
            this.root = RemoveMin(this.root);
        }

        public T Find(T element)
        {
            return ElementAt(Find(element, this.root));
        }

        public T FindMin()
        {
            return ElementAt(FindMin(this.root));
        }

        public T FindMax()
        {
            return ElementAt(FindMax(this.root));
        }

        public void MakeEmpty()
        {
            this.root = null;
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public static bool operator ==(BinarySearchTree<T> firstTree, BinarySearchTree<T> secondTree)
        {
            return firstTree.Equals(secondTree);
        }

        public static bool operator !=(BinarySearchTree<T> firstTree, BinarySearchTree<T> secondTree)
        {
            return !firstTree.Equals(secondTree);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();

            GetNextNode(this.root, ref nodes);

            foreach (TreeNode<T> node in nodes)
            {
                yield return node;
            }
        }

        public object Clone()
        {
            BinarySearchTree<T> clone = new BinarySearchTree<T>();

            CopyNode(this.root, ref clone);

            return clone;
        }

        private TreeNode<T> Insert(T element, TreeNode<T> node)
        {
            if (node == null)
            {
                node = new TreeNode<T>(element);
            }
            else if (element.CompareTo(node.Element) < 0)
            {
                node.Left = Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Element) > 0)
            {
                node.Right = Insert(element, node.Right);
            }
            else
            {
                throw new ArgumentException("Duplicate item!");
            }

            return node;
        }

        private TreeNode<T> Remove(T element, TreeNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentException("Item not found!");
            }
            else if (element.CompareTo(node.Element) < 0)
            {
                node.Left = Remove(element, node.Left);
            }
            else if (element.CompareTo(node.Element) > 0)
            {
                node.Right = Remove(element, node.Right);
            }
            else if (node.Left != null && node.Right != null)
            {
                node.Element = FindMin(node.Right).Element;
                node.Right = RemoveMin(node.Right);
            }
            else
            {
                node = (node.Left != null) ? node.Left : node.Right;
            }

            return node;
        }

        private TreeNode<T> RemoveMin(TreeNode<T> element)
        {
            if (element == null)
            {
                throw new ArgumentException("Item not found!");
            }
            else if (element.Left != null)
            {
                element.Left = RemoveMin(element.Left);

                return element;
            }
            else
            {
                return element.Right;
            }
        }

        private T ElementAt(TreeNode<T> node)
        {
            return node == null ? default(T) : node.Element;
        }

        private TreeNode<T> Find(T element, TreeNode<T> node)
        {
            while (node != null)
            {
                if (element.CompareTo(node.Element) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Element) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }

        private TreeNode<T> FindMin(TreeNode<T> element)
        {
            if (element != null)
            {
                while (element.Left != null)
                {
                    element = element.Left;
                }
            }

            return element;
        }

        private TreeNode<T> FindMax(TreeNode<T> element)
        {
            if (element != null)
            {
                while (element.Right != null)
                {
                    element = element.Right;
                }
            }

            return element;
        }

        private void CheckEqualNodes(TreeNode<T> firstNode, TreeNode<T> secondNode, ref bool equal)
        {
            if (firstNode == null && secondNode == null)
            {
                return;
            }

            if ((firstNode != null && secondNode == null) || (firstNode == null && secondNode != null) || !firstNode.Equals(secondNode))
            {
                equal = false;

                return;
            }

            CheckEqualNodes(firstNode.Left, secondNode.Left, ref equal);
            CheckEqualNodes(firstNode.Right, secondNode.Right, ref equal);
        }

        private void GetNextNode(TreeNode<T> node, ref List<TreeNode<T>> nodes)
        {
            if (node == null)
            {
                return;
            }

            GetNextNode(node.Left, ref nodes);
            nodes.Add(node);
            GetNextNode(node.Right, ref nodes);
        }

        private void CopyNode(TreeNode<T> root, ref BinarySearchTree<T> tree)
        {
            if (root == null)
            {
                return;
            }

            tree.Insert(this.root.Element);
            CopyNode(this.root.Left, ref tree);
            CopyNode(this.root.Right, ref tree);
        }

        public override int GetHashCode()
        {
            int hashCode = 7;

            foreach (TreeNode<T> node in this)
            {
                hashCode ^= node.Element.GetHashCode();
            }

            return hashCode;
        }

        public override bool Equals(object obj)
        {
            bool equal = true;

            CheckEqualNodes(this.root, ((BinarySearchTree<T>)obj).root, ref equal);

            return equal;
        }

        public override string ToString()
        {
            return this.Root.ToString();
        }
    }
}