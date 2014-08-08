namespace BinarySearchTree
{
    using System.Text;

    public class TreeNode<T>
    {
        private T element;
        private TreeNode<T> left;
        private TreeNode<T> right;

        public TreeNode(T element)
        {
            this.Element = element;
        }

        public T Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        public TreeNode<T> Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public TreeNode<T> Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("[{0} ", this.Element);

            // Leaf node
            if (this.Left == null && this.Right == null)
            {
                result.Append(" (Leaf) ");
            }

            if (this.Left != null)
            {
                result.AppendFormat("Left: {0}", this.Left.ToString());
            }

            if (this.Right != null)
            {
                result.AppendFormat("Right: {0}", this.Right.ToString());
            }

            result.Append("] ");

            return result.ToString();
        }
    }
}