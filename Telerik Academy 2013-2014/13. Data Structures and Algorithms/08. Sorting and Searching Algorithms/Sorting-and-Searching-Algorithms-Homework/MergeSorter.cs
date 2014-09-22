namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.TopDownSplitMerge(collection, 0, collection.Count, new List<T>(collection));
        }

        // startPosition is inclusive; endPosition is exclusive (collection[endPosition] is not in the set)
        private void TopDownSplitMerge(IList<T> collection, int startPosition, int endPosition, IList<T> workCollection)
        {
            // if run size == 1
            if (endPosition - startPosition < 2)
            {
                return; // consider it sorted
            }

            // recursively split runs into two halves until run size == 1,
            // then merge them and return back up the call chain
            int middlePoint = (endPosition + startPosition) / 2; // middlePoint = mid point
            this.TopDownSplitMerge(collection, startPosition, middlePoint, workCollection); // split / merge left half
            this.TopDownSplitMerge(collection, middlePoint, endPosition, workCollection); // split / merge right half
            this.TopDownMerge(collection, startPosition, middlePoint, endPosition, workCollection); // merge the two half runs
            this.CopyArray(workCollection, startPosition, endPosition, collection); // copy the merged runs back to collection
        }

        // left half is collection[startPosition : middlePoint - 1]
        // right half is collection[middlePoint : endPosition - 1]
        private void TopDownMerge(IList<T> collection, int startPosition, int middlePoint, int endPosition, IList<T> workCollection)
        {
            int startIndex = startPosition;
            int middleIndex = middlePoint;

            // While there are elements in the left or right runs
            for (int i = startPosition; i < endPosition; i++)
            {
                // If left run head exists and is <= existing right run head.
                if (startIndex < middlePoint &&
                    (middleIndex >= endPosition || collection[startIndex].CompareTo(collection[middleIndex]) <= 0))
                {
                    workCollection[i] = collection[startIndex];
                    startIndex = startIndex + 1;
                }
                else
                {
                    workCollection[i] = collection[middleIndex];
                    middleIndex = middleIndex + 1;
                }
            }
        }

        private void CopyArray(IList<T> workCollection, int startPosition, int endPosition, IList<T> collection)
        {
            for (int i = startPosition; i < endPosition; i++)
            {
                collection[i] = workCollection[i];
            }
        }
    }
}