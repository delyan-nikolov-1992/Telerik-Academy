namespace Assertions
{
    using System;
    using System.Diagnostics;

    public class AssertionsHomework
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr.Length != 0, "The input array is emtpy!");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr.Length != 0, "The input array is empty!");

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            // uncomment the next line to check assertion
            // SelectionSort(new int[0]); // Test sorting empty array
            SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arr, -1000));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 17));
            Console.WriteLine(BinarySearch(arr, 10));
            Console.WriteLine(BinarySearch(arr, 1000));
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr.Length != 0, "The input array is empty!");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "The start index is out of range!");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "The end index is out of range!");
            Debug.Assert(startIndex <= endIndex, "The start index is greater than the end index!");

            int minElementIndex = startIndex;

            Debug.Assert(minElementIndex >= 0 && minElementIndex < arr.Length, "The index is out of range!");

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;

                    Debug.Assert(minElementIndex >= 0 && minElementIndex < arr.Length, "The index is out of range!");
                }
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "The first element is null!");
            Debug.Assert(y != null, "The second element is null!");

            T oldX = x;
            x = y;
            y = oldX;
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr.Length != 0, "The input array is empty!");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "The start index is out of range!");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "The end index is out of range!");
            Debug.Assert(startIndex <= endIndex, "The start index is greater than the end index!");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                Debug.Assert(midIndex >= 0 && midIndex < arr.Length, "The index is out of range!");

                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}