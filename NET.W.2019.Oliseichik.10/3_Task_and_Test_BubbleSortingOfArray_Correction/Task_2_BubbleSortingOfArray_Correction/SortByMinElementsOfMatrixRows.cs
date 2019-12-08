using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_BubbleSortingOfArray_Correction
{
    /// <summary>
    /// Min element sort class
    /// </summary>
    public class SortByMinElementsOfMatrixRows : IComparer<int[]>
    {
        /// <summary>
        /// IComparer interface implementation for min element.
        /// </summary>
        /// <param name="rowArrayOne"></param>
        /// <param name="rowArrayTwo"></param>
        /// <returns></returns>
        public int Compare(int[] rowArrayOne, int[] rowArrayTwo)
        {
            int minRowArrayOne = MinElement(rowArrayOne);
            int minRowArrayTwo = MinElement(rowArrayTwo);

            return minRowArrayOne < minRowArrayTwo ? 1 : minRowArrayOne > minRowArrayTwo ? -1 : 0;
        }

        /// <summary>
        /// Search min element in row.
        /// </summary>
        /// <param name="arrayRow"></param>
        /// <returns></returns>
        private int MinElement(int[] arrayRow)
        {
            int minElementForRow = int.MaxValue;
            foreach (var item in arrayRow)
            {
                if (item < minElementForRow)
                {
                    minElementForRow = item;
                }
            }

            return minElementForRow;
        }
    }
}
