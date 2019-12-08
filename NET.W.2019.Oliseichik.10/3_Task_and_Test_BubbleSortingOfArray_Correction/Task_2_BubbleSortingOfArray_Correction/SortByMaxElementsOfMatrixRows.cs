using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_BubbleSortingOfArray_Correction
{
    /// <summary>
    /// Max element sort class.
    /// </summary>
    public class SortByMaxElementsOfMatrixRows : IComparer<int[]>
    {
        /// <summary>
        /// IComparer interface implementation for max element.
        /// </summary>
        /// <param name="rowArrayOne"></param>
        /// <param name="rowArrayTwo"></param>
        /// <returns></returns>
        public int Compare(int[] rowArrayOne, int[] rowArrayTwo)
        {
            int maxRowArrayOne = MaxElement(rowArrayOne);
            int maxRowArrayTwo = MaxElement(rowArrayTwo);

            return maxRowArrayOne < maxRowArrayTwo ? 1 : maxRowArrayOne > maxRowArrayTwo ? -1 : 0;
        }

        /// <summary>
        /// Search max element in row.
        /// </summary>
        /// <param name="arrayRow"></param>
        /// <returns></returns>
        private int MaxElement(int[] arrayRow)
        {
            int maxElementForRow = int.MinValue;
            foreach (var item in arrayRow)
            {
                if (item > maxElementForRow)
                {
                    maxElementForRow = item;
                }
            }

            return maxElementForRow;
        }
    }
}
