using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_MergeSort
{
    /// <summary>
    ///  Class SortM
    ///  main class of the program
    ///  sorting integer array by merge sort
    /// </summary>
    public class SortM
    {
        /// <summary>
        /// Method for adding items
        /// remaining after merging 
        /// Elements are added from right or left subarrays
        /// </summary>
        /// <param name="tempArray"></param>
        /// <param name="arr"></param>
        /// <param name="leftSubarrayIndex"></param>
        /// <param name="right"></param>
        /// <param name="AverageIndex"></param>
        /// <param name="index"></param>
        /// <param name="EndIndex"></param>
        static void AddRemainingItems(int[] tempArray, int[] arr, int leftSubarrayIndex, int right, int AverageIndex, int index, int EndIndex) 
        {
            for (var i = leftSubarrayIndex; i <= AverageIndex; i++)
            {
                tempArray[index] = arr[i];
                index++;
            }

            for (var i = right; i <= EndIndex; i++)
            {
                tempArray[index] = arr[i];
                index++;
            }
        }

        /// <summary>
        /// The method of merging two subarrays
        /// Moving through the subarrays from the beginning
        /// Comparing items smaller
        /// write to a temporary array
        /// We call a method for adding elements,
        /// not added during merge
        /// Transfer data from a temporary array to the main array 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="StartIndex"></param>
        /// <param name="AverageIndex"></param>
        /// <param name="EndIndex"></param>
        static void MergeTwoSubarrays(int[] arr, int StartIndex, int AverageIndex, int EndIndex)
        {
            var leftSubarrayIndex = StartIndex;
            var rightSubarrayIndex = AverageIndex + 1;
            var tempArray = new int[EndIndex - StartIndex + 1];
            var index = 0;

            while ((leftSubarrayIndex <= AverageIndex) && (rightSubarrayIndex <= EndIndex))
            {
                if (arr[leftSubarrayIndex] < arr[rightSubarrayIndex])
                {
                    tempArray[index] = arr[leftSubarrayIndex];
                    leftSubarrayIndex++;
                }
                else
                {
                    tempArray[index] = arr[rightSubarrayIndex];
                    rightSubarrayIndex++;
                }

                index++;
            }

            AddRemainingItems(tempArray, arr, leftSubarrayIndex, rightSubarrayIndex, AverageIndex, index, EndIndex);

            for (var i = 0; i < tempArray.Length; i++)
            {
                arr[StartIndex + i] = tempArray[i];
            }
        }


        /// <summary>
        /// Merge Sort Method
        /// Find the middle element in the array
        /// Divide the array into subarrays
        /// Call the method of merging two subarrays
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="StartIndex"></param>
        /// <param name="EndIndex"></param>
        /// <returns></returns>
        public static int[] MergeSort(int[] arr, int StartIndex, int EndIndex)
        {
            if (StartIndex < EndIndex)
            {
                var AverageIndex = (StartIndex + EndIndex) / 2;
                MergeSort(arr, StartIndex, AverageIndex);
                MergeSort(arr, AverageIndex + 1, EndIndex);
                MergeTwoSubarrays(arr, StartIndex, AverageIndex, EndIndex);
            }

            return arr;
        }

        /// <summary>
        /// The Main () method is
        /// program entry point 
        /// Enter the size of the array
        /// The array is filled from the keyboard
        /// Merge Sort Method Called 
        /// The sorted array is displayed
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("Size array: ");
            var Size = Convert.ToInt32(Console.ReadLine());
            var arr = new int[Size];
            for (var i = 0; i < arr.Length; ++i)
            {
                Console.Write("array[{0}] = ", i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            arr = MergeSort(arr, 0, arr.Length - 1);

            Console.Write("End array:");
            foreach (var i in arr)
            {
                Console.Write(" {0}", i);
            }

            Console.ReadLine();
        }
    }
}
