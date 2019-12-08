using NUnit.Framework;

namespace Task_2_BubbleSortingOfArray_Correction.Tests
{
    public class SortSteppedArrayTest
    {
        [Test]
        public void SortBySumElementsOfMatrixRowsTest1()
        {
            int[][] arrayEnter = new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } };
            int[][] resultArray = new int[][] { new int[] { 123, 2569, -546 }, new int[] { 123654 }, new int[] { 1, 4, 7, 8, 4569874 } };
            SortSteppedArray.BubbleSort(arrayEnter, new SortBySumElementsOfMatrixRows().Compare);

            CollectionAssert.AreEqual(resultArray, arrayEnter);
        }

        [Test]
        public void SortByMinElementsOfMatrixRowsTest1()
        {
            int[][] arrayEnter = new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } };
            int[][] resultArray = new int[][] { new int[] { 123, 2569, -546 }, new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123654 } };
            SortSteppedArray.BubbleSort(arrayEnter, new SortByMinElementsOfMatrixRows().Compare);

            CollectionAssert.AreEqual(resultArray, arrayEnter);
        }

        [Test]
        public void SortByMaxElementsOfMatrixRowsTest1()
        {
            int[][] arrayEnter = new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } };
            int[][] resultArray = new int[][] { new int[] { 123, 2569, -546 }, new int[] { 123654 }, new int[] { 1, 4, 7, 8, 4569874 } };
            SortSteppedArray.BubbleSort(arrayEnter, new SortByMaxElementsOfMatrixRows().Compare);

            CollectionAssert.AreEqual(resultArray, arrayEnter);
        }

        [Test]
        public void SortBySumElementsOfMatrixRowsTest2()
        {
            int[][] arrayEnter = new int[][] { new int[] { -5, -4, 11 }, new int[] { 2 }, new int[] { 1 } };
            int[][] resultArray = new int[][] { new int[] { 1 }, new int[] { -5, -4, 11 }, new int[] { 2 } };
            SortSteppedArray.BubbleSort(arrayEnter, new SortBySumElementsOfMatrixRows().Compare);

            CollectionAssert.AreEqual(resultArray, arrayEnter);
        }

        [Test]
        public void SortByMinElementsOfMatrixRowsTest2()
        {
            int[][] arrayEnter = new int[][] { new int[] { -5, -4, 11 }, new int[] { 2 }, new int[] { 1 } };
            int[][] resultArray = new int[][] { new int[] { -5, -4, 11 }, new int[] { 1 }, new int[] { 2 } };
            SortSteppedArray.BubbleSort(arrayEnter, new SortByMinElementsOfMatrixRows().Compare);

            CollectionAssert.AreEqual(resultArray, arrayEnter);
        }

        [Test]
        public void SortByMaxElementsOfMatrixRowsTest2()
        {
            int[][] arrayEnter = new int[][] { new int[] { -5, -4, 11 }, new int[] { 2 }, new int[] { 1 } };
            int[][] resultArray = new int[][] { new int[] { 1 }, new int[] { 2 }, new int[] { -5, -4, 11 } };
            SortSteppedArray.BubbleSort(arrayEnter, new SortByMaxElementsOfMatrixRows().Compare);

            CollectionAssert.AreEqual(resultArray, arrayEnter);
        }

        [Test]
        public void SortBySumElementsOfMatrixRowsTest3()
        {
            int[][] arrayEnter = new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } };
            int[][] resultArray = new int[][] { new int[] { 123, 2569, -546 }, new int[] { 123654 }, new int[] { 1, 4, 7, 8, 4569874 } };
            SortSteppedArray.BubbleSort(arrayEnter, new SortBySumElementsOfMatrixRows().Compare);

            CollectionAssert.AreEqual(resultArray, arrayEnter);
        }

        [Test]
        public void SortByMinElementsOfMatrixRowsTest3()
        {
            int[][] arrayEnter = new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } };
            int[][] resultArray = new int[][] { new int[] { 123, 2569, -546 }, new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123654 } };
            SortSteppedArray.BubbleSort(arrayEnter, new SortByMinElementsOfMatrixRows().Compare);

            CollectionAssert.AreEqual(resultArray, arrayEnter);
        }

        [Test]
        public void SortByMaxElementsOfMatrixRowsTest3()
        {
            int[][] arrayEnter = new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } };
            int[][] resultArray = new int[][] { new int[] { 123, 2569, -546 }, new int[] { 123654 }, new int[] { 1, 4, 7, 8, 4569874 } };
            SortSteppedArray.BubbleSort(arrayEnter, new SortByMaxElementsOfMatrixRows().Compare);

            CollectionAssert.AreEqual(resultArray, arrayEnter);
        }
    }
}