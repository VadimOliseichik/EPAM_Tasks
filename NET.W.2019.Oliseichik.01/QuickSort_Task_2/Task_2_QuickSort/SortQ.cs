using System;

namespace Task_2_QuickSort
{
    public class SortQ
    {
        /// <summary>
        /// Quick Sort Method
        /// The reference element is calculated, it is taken in the middle of the array
        /// We go from the beginning of the array to the middle, until we meet an element larger than the reference
        /// We go from the end of the array to the middle until we meet an element larger than the reference
        /// Swap the elements found to the right and left of the reference
        /// Call the quick sort method for subarrays resulting from the above operations
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="StartIndex"></param>
        /// <param name="EndIndex"></param>
        /// <returns></returns>
        public static int[] QuickSort(int[] arr, int StartIndex, int EndIndex)
        {
            int tempStartIndex = StartIndex;
            int tempEndIndex = EndIndex;
            int middleElement = arr[(tempStartIndex + tempEndIndex) / 2]; //вычисление опорного элемента

            while (tempStartIndex < tempEndIndex)
            {
                while (arr[tempStartIndex] < middleElement)
                {
                    tempStartIndex++;
                }
                while (arr[tempEndIndex] > middleElement)
                {
                    tempEndIndex--;
                }

                if (tempStartIndex <= tempEndIndex) //перестановка элементов
                {
                    int temporaryVariable;

                    temporaryVariable = arr[tempStartIndex];
                    arr[tempStartIndex] = arr[tempEndIndex];
                    arr[tempEndIndex] = temporaryVariable;

                    tempStartIndex++;
                    tempEndIndex--;
                }
            } 

            if (StartIndex < tempEndIndex)
            {
                QuickSort(arr, StartIndex, tempEndIndex);
            }
            if (tempStartIndex < EndIndex)
            {
                QuickSort(arr, tempStartIndex, EndIndex);
            }

            return arr;
        }

        /// <summary>
        /// The Main () method is
        /// program entry point 
        /// Enter the size of the array
        /// The array is populated from the keyboard
        /// The quick sort method is called
        /// A sorted array is displayed
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

            arr = QuickSort(arr, 0, arr.Length - 1);

            Console.Write("End array:");
            foreach (var i in arr) 
            {
                Console.Write(" {0}",i);
            }

            Console.ReadLine();
        }
    }
}
