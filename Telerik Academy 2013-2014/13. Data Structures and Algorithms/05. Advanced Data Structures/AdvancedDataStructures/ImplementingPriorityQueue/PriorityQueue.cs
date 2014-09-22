namespace ImplementingPriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;

        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public void Enqueue(T item)
        {
            this.data.Add(item);
            int childIndex = this.data.Count - 1;

            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;

                if (this.data[childIndex].CompareTo(this.data[parentIndex]) >= 0)
                {
                    break;
                }

                T childElement = this.data[childIndex];
                this.data[childIndex] = this.data[parentIndex];
                this.data[parentIndex] = childElement;
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            int lastIndex = this.data.Count - 1;
            T frontItem = this.data[0];
            this.data[0] = this.data[lastIndex];
            this.data.RemoveAt(lastIndex);

            --lastIndex;
            int parentIndex = 0;

            while (true)
            {
                int leftChildIndex = (parentIndex * 2) + 1;

                if (leftChildIndex > lastIndex)
                {
                    break;
                }

                int rightChildIndex = leftChildIndex + 1;

                if (rightChildIndex <= lastIndex && this.data[rightChildIndex].CompareTo(this.data[leftChildIndex]) < 0)
                {
                    leftChildIndex = rightChildIndex;
                }

                if (this.data[parentIndex].CompareTo(this.data[leftChildIndex]) <= 0)
                {
                    break;
                }

                T parentElement = this.data[parentIndex];
                this.data[parentIndex] = this.data[leftChildIndex];
                this.data[leftChildIndex] = parentElement;
                parentIndex = leftChildIndex;
            }

            return frontItem;
        }

        public T Peek()
        {
            T frontItem = this.data[0];

            return frontItem;
        }

        public int Count()
        {
            return this.data.Count;
        }

        public bool IsConsistent()
        {
            if (this.data.Count == 0)
            {
                return true;
            }

            int lastIndex = this.data.Count - 1;

            for (int parentIndex = 0; parentIndex < this.data.Count; ++parentIndex)
            {
                int leftChildIndex = (2 * parentIndex) + 1;
                int rightChildIndex = (2 * parentIndex) + 2;

                if (leftChildIndex <= lastIndex && this.data[parentIndex].CompareTo(this.data[leftChildIndex]) > 0)
                {
                    return false;
                }

                if (rightChildIndex <= lastIndex && this.data[parentIndex].CompareTo(this.data[rightChildIndex]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var element in this.data)
            {
                result.Append(element.ToString() + " ");
            }

            result.AppendLine("\ncount = " + this.data.Count);

            return result.ToString();
        }
    }
}