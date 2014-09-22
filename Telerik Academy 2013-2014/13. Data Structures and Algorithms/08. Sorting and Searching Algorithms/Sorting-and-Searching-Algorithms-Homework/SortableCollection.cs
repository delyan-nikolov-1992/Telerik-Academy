namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (T currentElement in this.Items)
            {
                if (currentElement.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int minIndex = 0;
            int maxIndex = this.Items.Count - 1;

            // continue searching while [minIndex, maxIndex] is not empty
            while (maxIndex >= minIndex)
            {
                // calculate the middlePoint for roughly equal partition
                int middlePoint = (minIndex + maxIndex) / 2;

                // determine which subarray to search
                if (this.Items[middlePoint].CompareTo(item) < 0)
                {
                    // change minIndex to search upper subarray
                    minIndex = middlePoint + 1;
                }
                else if (this.Items[middlePoint].CompareTo(item) > 0)
                {
                    // change maxIndex to search lower subarray
                    maxIndex = middlePoint - 1;
                }
                else
                {
                    // key found at index middlePoint
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            var random = RandomProvider.Instance;
            int length = this.Items.Count;

            for (int i = 0; i < length; i++)
            {
                // Exchange this.Items[i] with random element in this.Items[i..n-1]
                int randomPosition = i + random.GetRandomNumber(0, length - i);
                T oldElement = this.Items[i];
                this.Items[i] = this.Items[randomPosition];
                this.Items[randomPosition] = oldElement;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}