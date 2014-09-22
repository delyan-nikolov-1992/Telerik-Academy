namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int length = collection.Count;

            for (int i = 0; i < length - 1; i++)
            {
                /* find the min element in the unsorted collection[i .. length-1] */
                int indexOfMinElement = i;

                for (int j = i + 1; j < length; j++)
                {
                    if (collection[j].CompareTo(collection[indexOfMinElement]) < 0)
                    {
                        indexOfMinElement = j;
                    }
                }

                if (indexOfMinElement != i)
                {
                    T oldFirstElement = collection[i];
                    collection[i] = collection[indexOfMinElement];
                    collection[indexOfMinElement] = oldFirstElement;
                }
            }
        }
    }
}