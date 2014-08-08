namespace GenericList
{
    using System;
    using System.Text;

    public class GenericList<T>
    {
        private int size;
        private T[] elements;
        private int next;

        public GenericList(int size)
        {
            this.Size = size;
            this.Elements = new T[size];
            this.Next = 0;
        }

        public int Size
        {
            get { return this.size; }

            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("The size of the list must be non-negative value!");
                }

                this.size = value;
            }
        }

        public T[] Elements
        {
            get { return this.elements; }
            set { this.elements = value; }
        }

        public int Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public void Add(T item)
        {
            if (next >= size)
            {
                AutoGrow();
            }

            Elements[next] = item;
            Next++;
        }

        public T this[int index]
        {
            get
            {
                if (!IsInRange(index))
                {
                    throw new IndexOutOfRangeException(string.Format("Invalid index: {0}", index));
                }

                return elements[index];
            }
        }

        public void RemoveAt(int index)
        {
            if (!IsInRange(index))
            {
                throw new IndexOutOfRangeException(string.Format("Invalid index: {0}", index));
            }

            for (int i = index; i < next - 1; i++)
            {
                T nextElement = elements[i + 1];
                Elements[i] = nextElement;
            }

            Next--;
        }

        public void Insert(int index, T item)
        {
            if (!IsInRange(index))
            {
                throw new IndexOutOfRangeException(string.Format("Invalid index: {0}", index));
            }

            if (next >= size)
            {
                AutoGrow();
            }

            for (int i = next; i > index; i--)
            {
                elements[i] = elements[i - 1];
            }

            elements[index] = item;
            Next++;
        }

        public void Clear()
        {
            Elements = new T[size];
            Next = 0;
        }

        public int FindElementIndex(T searchedValue)
        {
            return Array.IndexOf(elements, searchedValue);
        }

        private void AutoGrow()
        {
            T[] tempList = new T[size];
            elements.CopyTo(tempList, 0);
            Size *= 2;
            Elements = new T[size];
            tempList.CopyTo(elements, 0);
        }

        private bool IsInRange(int index)
        {
            if (index < 0 || index >= next)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            if (next == 0)
            {
                return "The list is empty!\n";
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < next; i++)
            {
                result.AppendLine(string.Format("element[{0}] = {1}", i, elements[i]));
            }

            return result.ToString();
        }
    }
}