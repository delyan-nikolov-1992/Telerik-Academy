namespace CompareSorting
{
    using System;
    using System.Diagnostics;

    public class Test
    {
        private const int NumberOfDashes = 50;

        private static int[] randomIntValues = new int[] { 1, 7, 6, 5, 2, 4, 3 };
        private static int[] sortedIntValues = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        private static int[] reversedIntValues = new int[] { 7, 6, 5, 4, 3, 2, 1 };

        private static double[] randomDoubleValues = new double[] { 1.1, 1.5, 1.3, 1.4, 1.2 };
        private static double[] sortedDoubleValues = new double[] { 1.1, 1.2, 1.3, 1.4, 1.5 };
        private static double[] reversedDoubleValues = new double[] { 1.5, 1.4, 1.3, 1.2, 1.1 };

        private static string[] randomStringValues = new string[] { "qwerty", "milen", "amanda", "cherry", "carry" };
        private static string[] sortedStringValues = new string[] { "amanda", "carry", "cherry", "milen", "qwerty" };
        private static string[] reversedStringValues = new string[] { "qwerty", "milen", "cherry", "carry", "amanda" };

        public static void Main()
        {
            SortIntValues();
            SortDoubleValues();
            SortStringValues();
        }

        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static T[] InsertionSort<T>(T[] arr) where T : IComparable<T>
        {
            T[] sortedArr = (T[])arr.Clone();

            for (int i = 0; i < sortedArr.Length; i++)
            {
                T value = sortedArr[i];
                int j = i - 1;

                while (j >= 0 && sortedArr[j].CompareTo(value) > 0)
                {
                    sortedArr[j + 1] = sortedArr[j];
                    j--;
                }

                sortedArr[j + 1] = value;
            }

            return sortedArr;
        }

        private static T[] SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            T[] sortedArr = (T[])arr.Clone();
            int k;
            T current;

            for (int i = 0; i < sortedArr.Length; i++)
            {
                k = i;

                for (int j = i + 1; j < sortedArr.Length; j++)
                {
                    if (sortedArr[j].CompareTo(sortedArr[k]) < 0)
                    {
                        k = j;
                    }
                }

                current = sortedArr[i];
                sortedArr[i] = sortedArr[k];
                sortedArr[k] = current;
            }

            return sortedArr;
        }

        private static T[] QuickSort<T>(T[] arr, int left, int right) where T : IComparable<T>
        {
            T[] sortedArr = (T[])arr.Clone();
            int i = left;
            int j = right;
            T pivot = sortedArr[(left + right) / 2];

            while (i <= j)
            {
                while (sortedArr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (sortedArr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    T newValue = sortedArr[i];
                    sortedArr[i] = sortedArr[j];
                    sortedArr[j] = newValue;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort(sortedArr, left, j);
            }

            if (i < right)
            {
                QuickSort(sortedArr, i, right);
            }

            return sortedArr;
        }

        private static void SortIntValues()
        {
            // Sort random int values
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Insertion sort for random int values:\t\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(randomIntValues);
            });

            Console.Write("Selection sort for random int values:\t\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(randomIntValues);
            });

            Console.Write("Quick sort for random int values:\t\t");
            DisplayExecutionTime(() =>
            {
                QuickSort(randomIntValues, 0, randomStringValues.Length - 1);
            });

            // Sort sorted int values
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Insertion sort for sorted int values:\t\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(sortedIntValues);
            });

            Console.Write("Selection sort for sorted int values:\t\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(sortedIntValues);
            });

            Console.Write("Quick sort for sorted int values:\t\t");
            DisplayExecutionTime(() =>
            {
                QuickSort(sortedIntValues, 0, sortedIntValues.Length - 1);
            });

            // Sort reversed int values
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Insertion sort for reversed int values:\t\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(reversedIntValues);
            });

            Console.Write("Selection sort for reversed int values:\t\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(reversedIntValues);
            });

            Console.Write("Quick sort for reversed int values:\t\t");
            DisplayExecutionTime(() =>
            {
                QuickSort(reversedIntValues, 0, reversedIntValues.Length - 1);
            });
        }

        private static void SortDoubleValues()
        {
            // Sort random double values
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Insertion sort for random double values:\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(randomDoubleValues);
            });

            Console.Write("Selection sort for random double values:\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(randomDoubleValues);
            });

            Console.Write("Quick sort for random double values:\t\t");
            DisplayExecutionTime(() =>
            {
                QuickSort(randomDoubleValues, 0, randomStringValues.Length - 1);
            });

            // Sort sorted double values
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Insertion sort for sorted double values:\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(sortedDoubleValues);
            });

            Console.Write("Selection sort for sorted double values:\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(sortedDoubleValues);
            });

            Console.Write("Quick sort for sorted double values:\t\t");
            DisplayExecutionTime(() =>
            {
                QuickSort(sortedDoubleValues, 0, sortedDoubleValues.Length - 1);
            });

            // Sort reversed double values
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Insertion sort for reversed double values:\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(reversedDoubleValues);
            });

            Console.Write("Selection sort for reversed double values:\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(reversedDoubleValues);
            });

            Console.Write("Quick sort for reversed double values:\t\t");
            DisplayExecutionTime(() =>
            {
                QuickSort(reversedDoubleValues, 0, reversedDoubleValues.Length - 1);
            });
        }

        private static void SortStringValues()
        {
            // Sort random string values
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Insertion sort for random string values:\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(randomStringValues);
            });

            Console.Write("Selection sort for random string values:\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(randomStringValues);
            });

            Console.Write("Quick sort for random string values:\t\t");
            DisplayExecutionTime(() =>
            {
                QuickSort(randomStringValues, 0, randomStringValues.Length - 1);
            });

            // Sort sorted string values
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Insertion sort for sorted string values:\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(sortedStringValues);
            });

            Console.Write("Selection sort for sorted string values:\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(sortedStringValues);
            });

            Console.Write("Quick sort for sorted string values:\t\t");
            DisplayExecutionTime(() =>
            {
                QuickSort(sortedStringValues, 0, sortedStringValues.Length - 1);
            });

            // Sort reversed string values
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Insertion sort for reversed string values:\t");
            DisplayExecutionTime(() =>
            {
                InsertionSort(reversedStringValues);
            });

            Console.Write("Selection sort for reversed string values:\t");
            DisplayExecutionTime(() =>
            {
                SelectionSort(reversedStringValues);
            });

            Console.Write("Quick sort for reversed string values:\t\t");
            DisplayExecutionTime(() =>
            {
                QuickSort(reversedStringValues, 0, reversedStringValues.Length - 1);
            });
        }
    }
}