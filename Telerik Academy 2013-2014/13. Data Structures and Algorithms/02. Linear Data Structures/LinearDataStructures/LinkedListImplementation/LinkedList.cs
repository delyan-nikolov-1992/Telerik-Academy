namespace LinkedListImplementation
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private ListItem<T> root = null;

        public ListItem<T> FirstElement
        {
            get
            {
                return root;
            }
        }

        public void AddFirst(T value)
        {
            ListItem<T> newElement = new ListItem<T>
            {
                Value = value,
                NextItem = null
            };

            newElement.NextItem = root;
            root = newElement;
        }

        public void AddLast(T value)
        {
            ListItem<T> newElement = new ListItem<T>
            {
                Value = value,
                NextItem = null
            };

            if (root == null)
            {
                root = newElement;
            }
            else
            {
                ListItem<T> current = root;

                while (current.NextItem != null)
                {
                    current = current.NextItem;
                }

                current.NextItem = newElement;
            }
        }

        public void Remove(T value)
        {
            ListItem<T> searchedElement = new ListItem<T>
            {
                Value = value,
                NextItem = null
            };

            ListItem<T> current = root;

            while (current.NextItem != null)
            {
                if (current.NextItem.Value.Equals(value))
                {
                    current.NextItem = current.NextItem.NextItem;
                    break;
                }

                current = current.NextItem;
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.root;

            while (node != null)
            {
                yield return node.Value;
                node = node.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}