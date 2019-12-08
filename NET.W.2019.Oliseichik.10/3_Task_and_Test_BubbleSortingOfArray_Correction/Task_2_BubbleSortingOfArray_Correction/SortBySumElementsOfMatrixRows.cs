using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_BubbleSortingOfArray_Correction
{
    /// <summary>
    /// Sum sort class.
    /// </summary>
    public class SortBySumElementsOfMatrixRows : IComparer<int[]>
    {
        /// <summary>
        /// IComparer interface implementation for sum of elements.
        /// </summary>
        /// <param name="rowArrayOne"></param>
        /// <param name="rowArrayTwo"></param>
        /// <returns></returns>
        public int Compare(int[] rowArrayOne, int[] rowArrayTwo)
        {
            int sumRowArrayOne = SumOfElements(rowArrayOne);
            int sumRowArrayTwo = SumOfElements(rowArrayTwo);

            return sumRowArrayOne < sumRowArrayTwo ? 1 : sumRowArrayOne > sumRowArrayTwo ? -1 : 0;
        }

        /// <summary>
        /// Search sum of elements in row.
        /// </summary>
        /// <param name="arrayRow"></param>
        /// <returns></returns>
        private int SumOfElements(int[] arrayRow)
        {
            int sumElementsForRow = 0;
            foreach (var item in arrayRow)
            {
                sumElementsForRow += item;
            }

            return sumElementsForRow;
        }
    }
}
