using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Task_1_InsertNumber
{
    public class Program
    {
        public static string Invert( string number ) 
        {
            
            number = number.Replace('0', '3');
            number = number.Replace('1', '0');
            number = number.Replace('3', '1');
            
            for (int i = 0; i < number.Length; i++) 
            {
                if (number[i] == '0')
                {
                    number = number.Insert(i+1, "1");
                    number = number.Remove(0, i+1);
                    string fgd = "";
                    for (int y = 0; y < i; y++) { fgd += '0'; }
                    number = number.Insert(0, fgd);
                    
                    return number;
                }
                
            } 
            return number; 
        }
        /// <summary>
        /// Translate to binary
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ToBinaryNumber(int num) 
        {
            bool g = false;
            int index = -1;
            if (num < 0) 
            {
                g = true;
                num *= index; 
            }
            int zero = 0;
            int one = 1;
            string number = "";
            while (true)
            {
                index++;
                if (num > 0)
                {
                    if (num % 2 == 0)
                    {
                        number += zero.ToString();
                    }
                    else
                    {
                        number += one.ToString();
                    }
                    num /= 2;
                    continue;
                }
                else if (number.Length <= 31)
                {
                    number += zero.ToString();
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (g) 
            {
                number = Invert(number);
            }
            int rrr = number.Length;
            return number; 
        }
        /// <summary>
        /// I do a check for input pavilion
        /// I call the ToBinaryNumber method for two numbers
        /// I carry out operations with bits
        /// I return the result
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static double InsertNumber(int num1, int num2, int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentOutOfRangeException("j should have more i");
            }
            if (i < 0 || j < 0 || i > 31 || j > 31)
            {
                throw new ArgumentOutOfRangeException("32 bits exceeded");
            }

            string number1 = ToBinaryNumber(num1);
            string number2 = ToBinaryNumber(num2); 
            
            number2 = number2.Substring(0, j - i + 1);
            number1 = number1.Remove(i, j + 1);
            number1 = number1.Insert(i, number2);

            int count = 1; 
            if (number1[number1.Length - 1] == '1') 
            {
                number1 = Invert(number1);
                count = -1;
            }

            double y = 0;
            for (int k = 0; k < number1.Length; k++) 
            {
                y += ((int)(number1[k] - '0') * Math.Pow(2,k));
            }
            y *= count;
            return y;
        }
        /// <summary>
        /// The Main () method is
        /// program entry point
        /// I call the InsertNumber method 
        /// to test the function
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine(InsertNumber(8, 15, 3, 8));
            Console.WriteLine(InsertNumber(8, 15, 0, 0));
            Console.WriteLine(InsertNumber(15, 15, 0, 0));

            Console.ReadKey(); 
        }
    }
}
