using System;

namespace Task_2_BubbleSortingOfANonRectangularIntegerArray
{
    /// <summary>
    /// Class sort cow of stepped array
    /// </summary>
    public static class SortSteppedArray
    {
        /// <summary>
        /// Sort by the sum of the items in a row
        /// Filling an array with row sums
        /// </summary>
        /// <param name="steppedArray"></param>
        public static int[][] SortBySumElementsOfMatrixRows(int[][] steppedArray)
        {
            int[] arrayOfAmountOfElementsInRow = new int[steppedArray.Length];
            for (int i = 0; i < steppedArray.Length; i++)
            {
                arrayOfAmountOfElementsInRow[i] = SearchSumElementsForRow(steppedArray[i]);
            }

            BubbleSort(arrayOfAmountOfElementsInRow, steppedArray);

            return steppedArray;
        }

        /// <summary>
        /// Sort by max element in a row
        /// Filling an array max elements
        /// </summary>
        /// <param name="steppedArray"></param>
        public static int[][] SortByMaxElementsOfMatrixRows(int[][] steppedArray)
        {
            int[] arrayOfMaxElementsInRow = new int[steppedArray.Length];
            for (int i = 0; i < steppedArray.Length; i++)
            {
                arrayOfMaxElementsInRow[i] = SearchMaxElementForRow(steppedArray[i]);
            }

            BubbleSort(arrayOfMaxElementsInRow, steppedArray);

            return steppedArray;
        }

        /// <summary>
        /// Sort by min element in a row
        /// Filling an array min elements
        /// </summary>
        /// <param name="steppedArray"></param>
        public static int[][] SortByMinElementsOfMatrixRows(int[][] steppedArray)
        {
            int[] arrayOfMinElementsInRow = new int[steppedArray.Length];
            for (int i = 0; i < steppedArray.Length; i++)
            {
                arrayOfMinElementsInRow[i] = SearchMinElementForRow(steppedArray[i]);
            }

            BubbleSort(arrayOfMinElementsInRow, steppedArray);

            return steppedArray;
        }

        /// <summary>
        /// Bubble Sort for Rows
        /// </summary>
        /// <param name="arrayOfResultOfComputation"></param>
        /// <param name="steppedArray"></param>
        private static void BubbleSort(int[] arrayOfResultOfComputation, int[][] steppedArray)
        {
            for (int i = 0; i < arrayOfResultOfComputation.Length; i++)
            {
                for (int j = 0; j < arrayOfResultOfComputation.Length - 1 - i; j++)
                {
                    if (arrayOfResultOfComputation[j] > arrayOfResultOfComputation[j + 1])
                    {
                        int tmpItem = arrayOfResultOfComputation[j];
                        arrayOfResultOfComputation[j] = arrayOfResultOfComputation[j + 1];
                        arrayOfResultOfComputation[j + 1] = tmpItem;

                        int[] tmpItemArray = steppedArray[j];
                        steppedArray[j] = steppedArray[j + 1];
                        steppedArray[j + 1] = tmpItemArray;
                    }
                }
            }
        }

        /// <summary>
        /// Search for the sum of elements in a row
        /// </summary>
        /// <param name="rowArray"></param>
        /// <returns></returns>
        private static int SearchSumElementsForRow(int[] rowArray)
        {
            int sumElementsForRow = 0;
            foreach (var item in rowArray)
            {
                sumElementsForRow += item;
            }

            return sumElementsForRow;
        }

        /// <summary>
        /// Search for the maximum item in a row
        /// </summary>
        /// <param name="rowArray"></param>
        /// <returns></returns>
        private static int SearchMaxElementForRow(int[] rowArray)
        {
            int maxElementForRow = int.MinValue;
            foreach (var item in rowArray)
            {
                if (item > maxElementForRow)
                {
                    maxElementForRow = item; 
                }
            }

            return maxElementForRow;
        }

        /// <summary>
        /// Search for the minimal item in a row
        /// </summary>
        /// <param name="rowArray"></param>
        /// <returns></returns>
        private static int SearchMinElementForRow(int[] rowArray)
        {
            int minElementForRow = int.MaxValue;
            foreach (var item in rowArray)
            {
                if (item < minElementForRow)
                {
                    minElementForRow = item;
                }
            }

            return minElementForRow;
        }

        private static void Main()
        {
        }
    }
}
