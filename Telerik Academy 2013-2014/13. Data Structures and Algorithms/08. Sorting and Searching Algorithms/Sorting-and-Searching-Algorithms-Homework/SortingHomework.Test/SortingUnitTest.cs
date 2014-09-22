namespace SortingHomework.Test
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SortingHomework;

    [TestClass]
    public class SortingUnitTest
    {
        [TestMethod]
        public void TestSelectionSortWithNormalList()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            collection.Sort(new SelectionSorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The selection sort algorithm does not work correctly with normal data!"));
        }

        [TestMethod]
        public void TestSelectionSortWithSortedList()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            collection.Sort(new SelectionSorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The selection sort algorithm does not work correctly with sorted data!"));
        }

        [TestMethod]
        public void TestSelectionSortWithReversedList()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 33, 22, 11, 0 });
            collection.Sort(new SelectionSorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The selection sort algorithm does not work correctly with unsorted data!"));
        }

        [TestMethod]
        public void TestSelectionSortWithEmptyList()
        {
            var collection = new SortableCollection<int>();
            collection.Sort(new SelectionSorter<int>());

            var expectedOutput = new SortableCollection<int>();
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The selection sort algorithm does not work correctly with empty list!"));
        }

        [TestMethod]
        public void TestSelectionSortWithListOfOneElement()
        {
            var collection = new SortableCollection<int>(new[] { -5 });
            collection.Sort(new SelectionSorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { -5 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The selection sort algorithm does not work correctly with list of one element!"));
        }

        [TestMethod]
        public void TestQuickSortWithNormalList()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            collection.Sort(new Quicksorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The quick sort algorithm does not work correctly with normal data!"));
        }

        [TestMethod]
        public void TestQuickSortWithSortedList()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            collection.Sort(new Quicksorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The quick sort algorithm does not work correctly with sorted data!"));
        }

        [TestMethod]
        public void TestQuickSortWithReversedList()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 33, 22, 11, 0 });
            collection.Sort(new Quicksorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The quick sort algorithm does not work correctly with unsorted data!"));
        }

        [TestMethod]
        public void TestQuickSortWithEmptyList()
        {
            var collection = new SortableCollection<int>();
            collection.Sort(new Quicksorter<int>());

            var expectedOutput = new SortableCollection<int>();
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The quick sort algorithm does not work correctly with empty list!"));
        }

        [TestMethod]
        public void TestQuickSortWithListOfOneElement()
        {
            var collection = new SortableCollection<int>(new[] { -5 });
            collection.Sort(new Quicksorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { -5 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The quick sort algorithm does not work correctly with list of one element!"));
        }

        [TestMethod]
        public void TestMergeSortWithNormalList()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            collection.Sort(new MergeSorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The merge sort algorithm does not work correctly with normal data!"));
        }

        [TestMethod]
        public void TestMergeSortWithSortedList()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            collection.Sort(new MergeSorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The merge sort algorithm does not work correctly with sorted data!"));
        }

        [TestMethod]
        public void TestMergeSortWithReversedList()
        {
            var collection = new SortableCollection<int>(new[] { 101, 101, 33, 22, 11, 0 });
            collection.Sort(new MergeSorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The merge sort algorithm does not work correctly with unsorted data!"));
        }

        [TestMethod]
        public void TestMergeSortWithEmptyList()
        {
            var collection = new SortableCollection<int>();
            collection.Sort(new MergeSorter<int>());

            var expectedOutput = new SortableCollection<int>();
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The merge sort algorithm does not work correctly with empty list!"));
        }

        [TestMethod]
        public void TestMergeSortWithListOfOneElement()
        {
            var collection = new SortableCollection<int>(new[] { -5 });
            collection.Sort(new MergeSorter<int>());

            var expectedOutput = new SortableCollection<int>(new[] { -5 });
            var actualOutput = collection;
            bool areEqual = true;

            for (int i = 0; i < actualOutput.Items.Count; i++)
            {
                if (!actualOutput.Items[i].Equals(expectedOutput.Items[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            Assert.AreEqual(
                areEqual,
                true,
                string.Format("The merge sort algorithm does not work correctly with list of one element!"));
        }

        [TestMethod]
        public void TestLinearSearchWithElementInTheList()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

            bool expectedResult = true;
            bool actualResult = collection.LinearSearch(101);

            Assert.AreEqual(
                expectedResult,
                actualResult,
                string.Format("The linear search algorithm does not work correctly for finding an existing element!"));
        }

        [TestMethod]
        public void TestLinearSearchWithElementNotInTheList()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

            bool expectedResult = false;
            bool actualResult = collection.LinearSearch(-5);

            Assert.AreEqual(
                expectedResult,
                actualResult,
                string.Format("The linear search algorithm does not work correctly for finding a non-existing element!"));
        }

        [TestMethod]
        public void TestBinarySearchWithElementInTheList()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });

            bool expectedResult = true;
            bool actualResult = collection.BinarySearch(101);

            Assert.AreEqual(
                expectedResult,
                actualResult,
                string.Format("The binary search algorithm does not work correctly for finding an existing element!"));
        }

        [TestMethod]
        public void TestBinarySearchWithElementNotInTheList()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 101, 101 });

            bool expectedResult = false;
            bool actualResult = collection.BinarySearch(-5);

            Assert.AreEqual(
                expectedResult,
                actualResult,
                string.Format("The binary search algorithm does not work correctly for finding a non-existing element!"));
        }
    }
}