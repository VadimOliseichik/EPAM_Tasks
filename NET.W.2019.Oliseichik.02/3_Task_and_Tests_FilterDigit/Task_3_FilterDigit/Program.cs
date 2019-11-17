using System;
using System.Collections.Generic;

namespace Task_3_FilterDigit
{
    public class Program
    {
        /// <summary>
        /// Create a list of numbersStr type string
        /// I fill it with list items numbersInt
        /// I am looking for a given digit in the numbers of the numbers list
        /// If I didn’t find it, delete this number from the numbersInt list
        /// If I find an already encountered number, delete it from the numbersInt list
        /// I return a list of numbersInt
        /// </summary>
        /// <param name="numbersInt"></param>
        /// <param name="numeral"></param>
        /// <returns></returns>
        public static List<int> FilterDigit(List<int> numbersInt, int numeral)
        {
            List<string> numbersStr = new List<string>() { };

            foreach (int itemListNumbersInt in numbersInt)
            {
                numbersStr.Add(itemListNumbersInt.ToString());
            }

            int countIndexListItem = -1;
            foreach (string itemListNumbersStr in numbersStr)
            {
                countIndexListItem++;
                bool flagNumeralInNumbers = true;
                for (int i = 0; i < itemListNumbersStr.Length; i++)
                {
                    if (itemListNumbersStr[i] == Convert.ToChar(numeral.ToString()))
                    {
                        flagNumeralInNumbers = false;
                    }
                }

                if (flagNumeralInNumbers)
                {
                    numbersInt.Remove(Convert.ToInt32(itemListNumbersStr));
                    countIndexListItem--;
                }
                else if (numbersInt.IndexOf(Convert.ToInt32(itemListNumbersStr), countIndexListItem) > numbersInt.IndexOf(Convert.ToInt32(itemListNumbersStr)))
                {
                    numbersInt.RemoveAt(numbersInt.IndexOf(Convert.ToInt32(itemListNumbersStr), 
                        countIndexListItem));
                    countIndexListItem--;
                }

            }
            return numbersInt;
        }

        /// <summary>
        /// The Main () method is
        /// program entry point
        /// I specify a list of integers
        /// I call the FilterDigit method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            List<int> numbersInt = new List<int>() { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            foreach (int y in FilterDigit(numbersInt, 7)) 
            {
                Console.WriteLine(y);
            }
        }
    }
}