using System;

namespace Task_4_FindNthRoot
{
    public class Program
    {
        /// <summary>
        /// FindNthRoot method to find the root of a number
        /// I check for the correct input of the number 
        /// under the root and the degree of the root
        /// Using Newton's method, I find the root of the number
        /// </summary>
        /// <param name="numberUnderTheRoot"></param>
        /// <param name="rootDegree"></param>
        /// <param name="accuracy"></param>
        /// <returns></returns>
        public static double FindNthRoot(double numberUnderTheRoot, double rootDegree, double accuracy)
        {
            if (!(0 < accuracy && accuracy < 1))
            {
                throw new ArgumentOutOfRangeException("0 < accuracy < 1");
            }
            if ((numberUnderTheRoot <= 0 && rootDegree % 2 == 0) || rootDegree < 1) 
            {
                throw new ArgumentException("Number under the root must be > 0 or the degree of the root must be even");
            }

            double xk = numberUnderTheRoot / rootDegree;
            double xk_1 = xk;

            do
            {
                xk = xk_1;

                double resultExponentiation = 1;
                for (int i = 0; i < (int)rootDegree - 1; i++) resultExponentiation *= xk;

                xk_1 = (1 / rootDegree) * ((rootDegree - 1) * xk + numberUnderTheRoot / resultExponentiation);
            }while (Math.Abs(xk_1 - xk) > accuracy);

            return xk_1;
        }

        /// <summary>
        /// The Main () method is
        /// program entry point
        /// I call the FindNthRoot method 
        /// to test the function
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine(Math.Round(FindNthRoot(1, 5, 0.0001), 3));
            Console.WriteLine(Math.Round(FindNthRoot(8, 3, 0.0001), 3));
            Console.WriteLine(Math.Round(FindNthRoot(0.001, 3, 0.0001), 3));
            Console.WriteLine(Math.Round(FindNthRoot(0.04100625,4 , 0.0001), 3));
            Console.WriteLine(Math.Round(FindNthRoot(8, 3, 0.0001), 3));
            Console.WriteLine(Math.Round(FindNthRoot(0.0279936, 7, 0.0001), 3)); 
            Console.WriteLine(Math.Round(FindNthRoot(-0.008, 3, 0.1), 3));
            Console.WriteLine(Math.Round(FindNthRoot(0.004241979, 9, 0.00000001), 3));
            //Console.WriteLine(FindNthRoot(8, 15, -7));
            //Console.WriteLine(FindNthRoot(8, 15, -0.6));

            Console.ReadKey();
        }
    }
}