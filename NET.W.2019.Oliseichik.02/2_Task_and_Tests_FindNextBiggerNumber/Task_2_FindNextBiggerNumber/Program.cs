using System;
using System.Diagnostics;

namespace Task_2_FindNextBiggerNumber
{
    public class Program
    {
        /// <summary>
        /// We create an array to store each 
        /// digit of the number, fill it 
        /// We go through the array from the end, 
        /// look for a number in it that is smaller 
        /// than the number that stands after it
        /// We swap the two numbers 
        /// that were mentioned earlier
        /// Call the sort function for a subarray 
        /// starting with the index of the second 
        /// of the changed digits
        /// We make one number 
        /// from the number of the array
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int FindNextBiggerNumber(int number) 
        {
            if (number <= 11) 
            {
                return -1;
            }

            string numberString = number.ToString();
            int[] numberDecomposedNumber = new int[numberString.Length];

            for (int i = 0; i < numberDecomposedNumber.Length; i++) 
            {
                numberDecomposedNumber[i] = number % 10;
                number /= 10; 
            }

            Array.Reverse(numberDecomposedNumber);

            int indexat = -1; 

            for (int i = numberDecomposedNumber.Length - 1; i > 0; i--) 
            {
                if (numberDecomposedNumber[i] > numberDecomposedNumber[i - 1]) 
                {
                    indexat = i - 1;
                    break; 
                }
            }

            if (indexat < 0)
            {
                return -1;
            }
            else 
            {
                int timeTemp = numberDecomposedNumber[indexat];
                numberDecomposedNumber[indexat] = numberDecomposedNumber[indexat + 1];
                numberDecomposedNumber[indexat + 1] = timeTemp;
                int g = numberDecomposedNumber.Length - 1;
                numberDecomposedNumber = ArraySort(numberDecomposedNumber, indexat + 1); 
            }

            number = 0;

            for (int i = 0, j = numberDecomposedNumber.Length - 1; i < numberDecomposedNumber.Length && j >= 0; i++, j--) 
            {
                number += numberDecomposedNumber[i] * (int)Math.Pow(10, j);
            }

            return number; 
        }

        /// <summary>
        /// Sorting an array starting 
        /// at a given index to make 
        /// the number possible minimal
        /// </summary>
        /// <param name="numberDecomposedNumber"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int[] ArraySort(int[] numberDecomposedNumber, int startIndex)
        {
            for (int i = startIndex; i < numberDecomposedNumber.Length; i++)
            {
                for (int j = startIndex; j < numberDecomposedNumber.Length - 1; j++)
                {
                    if (numberDecomposedNumber[j] > numberDecomposedNumber[j + 1])
                    {
                        int temp = numberDecomposedNumber[j];
                        numberDecomposedNumber[j] = numberDecomposedNumber[j + 1];
                        numberDecomposedNumber[j + 1] = temp;
                    }
                }
            }
            return numberDecomposedNumber;
        }

        /// <summary>
        /// The Main () method is
        /// program entry point 
        /// FindNextBiggerNumber method 
        /// to find the nearest largest integer,
        /// consisting of digits of the original number
        /// I determine the execution time of the method using FindNextBiggerNumber
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Stopwatch stopWatch1 = new Stopwatch();
            stopWatch1.Start();
            var before1 = DateTime.UtcNow;
            var beforeT1 = DateTime.Now;
            
            Console.WriteLine(FindNextBiggerNumber(12));

            stopWatch1.Stop();
            Console.WriteLine("Stopwatch: {0}", stopWatch1.Elapsed);
            Console.WriteLine("DateTime.UtcNow: {0}", DateTime.UtcNow - before1);
            Console.WriteLine("DateTime.Now: {0}", DateTime.Now - beforeT1);
            Console.WriteLine("");

            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            var before2 = DateTime.UtcNow;
            var beforeT2 = DateTime.Now;

            Console.WriteLine(FindNextBiggerNumber(513));

            stopWatch2.Stop();
            Console.WriteLine("Stopwatch: {0}", stopWatch2.Elapsed);
            Console.WriteLine("DateTime.UtcNow: {0}", DateTime.UtcNow - before2);
            Console.WriteLine("DateTime.Now: {0}", DateTime.Now - beforeT2);
            Console.WriteLine("");


            Stopwatch stopWatch3 = new Stopwatch();
            stopWatch3.Start();
            var before3 = DateTime.UtcNow;
            var beforeT3 = DateTime.Now;

            Console.WriteLine(FindNextBiggerNumber(2017));

            stopWatch3.Stop();
            Console.WriteLine("Stopwatch: {0}", stopWatch3.Elapsed);
            Console.WriteLine("DateTime.UtcNow: {0}", DateTime.UtcNow - before3);
            Console.WriteLine("DateTime.Now: {0}", DateTime.Now - beforeT3);
            Console.WriteLine("");


            Stopwatch stopWatch4 = new Stopwatch();
            stopWatch4.Start();
            var before4 = DateTime.UtcNow;
            var beforeT4 = DateTime.Now;

            Console.WriteLine(FindNextBiggerNumber(414));

            stopWatch4.Stop();
            Console.WriteLine("Stopwatch: {0}", stopWatch4.Elapsed);
            Console.WriteLine("DateTime.UtcNow: {0}", DateTime.UtcNow - before4);
            Console.WriteLine("DateTime.Now: {0}", DateTime.Now - beforeT4);
            Console.WriteLine("");
            

            Console.WriteLine(FindNextBiggerNumber(144));
            Console.WriteLine(FindNextBiggerNumber(1234321));
            Console.WriteLine(FindNextBiggerNumber(1234126));
            Console.WriteLine(FindNextBiggerNumber(3456432));
            Console.WriteLine(FindNextBiggerNumber(10));
            Console.WriteLine(FindNextBiggerNumber(20));
            Console.ReadKey();
        }
    }
}