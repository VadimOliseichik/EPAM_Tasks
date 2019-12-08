using System;
using System.Collections.Generic;

namespace Task_2_BubbleSortingOfArray_Correction
{
    /// <summary>
    /// Array sort class.
    /// </summary>
    public static class SortSteppedArray
    {
        /// <summary>
        /// Bubble Sort for Rows.
        /// </summary>
        /// <param name="arrayOfResultOfComputation"></param>
        /// <param name="steppedArray"></param>
        public static void BubbleSort(this int[][] steppedArray, Func<int[], int[], int> comparer)
        {
            for (int i = 0; i < steppedArray.Length; i++)
            {
                for (int j = 1; j < steppedArray.Length; j++)
                {
                    int resultComparer = comparer.Invoke(steppedArray[j - 1], steppedArray[j]);

                    if (resultComparer == -1)
                    {
                        int[] tmpItemArray = steppedArray[j];
                        steppedArray[j] = steppedArray[j - 1];
                        steppedArray[j - 1] = tmpItemArray;
                    }
                }
            }
        }

        /// <summary>
        /// Point of entry.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int[][] arrayEnter = new int[][] { new int[] { 1, 4, 7, 8, 4569874 }, new int[] { 123, 2569, -546 }, new int[] { 123654 } };

            BubbleSort(arrayEnter, new SortByMaxElementsOfMatrixRows().Compare);

            BubbleSort(arrayEnter, new SortByMinElementsOfMatrixRows().Compare);

            BubbleSort(arrayEnter, new SortBySumElementsOfMatrixRows().Compare);
        }
    }
}
