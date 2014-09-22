namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }

        private void Quicksort(IList<T> collection, int leftPosition, int rightPosition)
        {
            if (leftPosition < rightPosition)
            {
                int partiotionIndex = this.FindPartitionIndex(collection, leftPosition, rightPosition);
                this.Quicksort(collection, leftPosition, partiotionIndex - 1);
                this.Quicksort(collection, partiotionIndex + 1, rightPosition);
            }
        }

        // leftPosition is the index of the leftmost element of the subarray
        // rightPosition is the index of the rightmost element of the subarray (inclusive)
        // number of elements in subarray = rightPosition - leftPosition + 1
        private int FindPartitionIndex(IList<T> collection, int leftPosition, int rightPosition)
        {
            int length = collection.Count;

            int pivotIndex = this.ChoosePivotIndex(collection, leftPosition, rightPosition);
            T pivotValue = collection[pivotIndex];

            T oldPivotValue = collection[pivotIndex];
            collection[pivotIndex] = collection[rightPosition];
            collection[rightPosition] = oldPivotValue;

            int storedIndex = leftPosition;

            for (int i = leftPosition; i < rightPosition; i++)
            {
                if (collection[i].CompareTo(pivotValue) < 0)
                {
                    T oldValue = collection[i];
                    collection[i] = collection[storedIndex];
                    collection[storedIndex] = oldValue;
                    storedIndex = storedIndex + 1;
                }
            }

            // Move pivot to its final place
            T oldStoredIndex = collection[storedIndex];
            collection[storedIndex] = collection[rightPosition];
            collection[rightPosition] = oldStoredIndex;

            return storedIndex;
        }

        private int ChoosePivotIndex(IList<T> collection, int leftPosition, int rightPosition)
        {
            int pivotIndex = rightPosition / 2;
            T firstElement = collection[leftPosition];
            T middleElement = collection[rightPosition / 2];
            T lastElement = collection[rightPosition];

            if ((middleElement.CompareTo(firstElement) <= 0 && firstElement.CompareTo(lastElement) <= 0) ||
                (lastElement.CompareTo(firstElement) <= 0 && firstElement.CompareTo(middleElement) <= 0))
            {
                pivotIndex = leftPosition;
            }
            else if ((middleElement.CompareTo(lastElement) <= 0 && lastElement.CompareTo(firstElement) <= 0) ||
              (firstElement.CompareTo(lastElement) <= 0 && lastElement.CompareTo(middleElement) <= 0))
            {
                pivotIndex = rightPosition;
            }

            return pivotIndex;
        }
    }
}