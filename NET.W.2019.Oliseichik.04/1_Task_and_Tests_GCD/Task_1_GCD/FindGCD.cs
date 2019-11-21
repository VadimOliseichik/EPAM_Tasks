using System;
using System.Diagnostics;

namespace Task_1_GCD
{
    /// <summary>
    /// A class that allows the calculation of GCD 
    /// using the Euclidean algorithm and 
    /// the Stein algorithm (binary Euclidean algorithm) 
    /// for two, three, etc. integers
    /// </summary>
    public static class FindGCD
    {
        /// <summary>
        /// EuclideanAlgorithmMethod method overload implementation 
        /// EuclideanAlgorithmMethod method for two numbers
        /// I pass numbers for the Computational method for the Euclidean algorithm
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        public static (int gcd, string elapsedTime) EuclideanAlgorithmMethod(this int numberOne, int numberTwo)
        {
            int answer; 
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            answer = CalculationsEuclideanAlgorithmMethod(Math.Abs(numberOne), Math.Abs(numberTwo));
            
            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();

            return (answer, elapsedTime);
        }

        /// <summary>
        /// EuclideanAlgorithmMethod method overload implementation 
        /// EuclideanAlgorithmMethod method for three numbers 
        /// I pass numbers for the Computational method for the Euclidean algorithm 
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <param name="numberThree"></param>
        /// <returns></returns>
        public static (int gcd, string elapsedTime) EuclideanAlgorithmMethod(this int numberOne, int numberTwo, int numberThree)
        {
            int answer;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            answer = CalculationsEuclideanAlgorithmMethod(
                CalculationsEuclideanAlgorithmMethod(Math.Abs(numberOne), Math.Abs(numberTwo)), Math.Abs(numberThree));

            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();

            return (answer, elapsedTime);
        }

        /// <summary>
        /// EuclideanAlgorithmMethod method overload implementation 
        /// EuclideanAlgorithmMethod method for more than three numbers
        /// </summary>
        /// <param name="arrayOfValues"></param>
        /// <returns></returns>
        public static (int gcd, string elapsedTime) EuclideanAlgorithmMethod(params int[] arrayOfValues)
        {
            if (arrayOfValues.Length <= 1)
            {
                throw new Exception("Method failed. Numbers were not transmitted or one number was transmitted.");
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 1; i < arrayOfValues.Length; i++)
            {
                arrayOfValues[i] = CalculationsEuclideanAlgorithmMethod(Math.Abs(arrayOfValues[i]), Math.Abs(arrayOfValues[i - 1]));
            }

            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();

            return (arrayOfValues[arrayOfValues.Length - 1], elapsedTime);
        }

        /// <summary>
        /// EuclideanBinaryAlgorithmMethod method overload implementation 
        /// EuclideanBinaryAlgorithmMethod method for two numbers
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        public static (int gcd, string elapsedTime) EuclideanBinaryAlgorithmMethod(this int numberOne, int numberTwo)
        {
            int answer;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            answer = CalculationsEuclideanBinaryAlgorithmMethod(Math.Abs(numberOne), Math.Abs(numberTwo));
            
            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();

            return (answer, elapsedTime);
        }

        /// <summary>
        /// EuclideanBinaryAlgorithmMethod method overload implementation 
        /// EuclideanBinaryAlgorithmMethod method for three numbers
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <param name="numberThree"></param>
        /// <returns></returns>
        public static (int gcd, string elapsedTime) EuclideanBinaryAlgorithmMethod(this int numberOne, int numberTwo, int numberThree)
        {
            int answer;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            answer = CalculationsEuclideanBinaryAlgorithmMethod(
                CalculationsEuclideanBinaryAlgorithmMethod(Math.Abs(numberOne), Math.Abs(numberTwo)), 
                Math.Abs(numberThree));

            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();

            return (answer, elapsedTime);
        }

        /// <summary>
        /// EuclideanBinaryAlgorithmMethod method overload implementation 
        /// EuclideanBinaryAlgorithmMethod method for more than three numbers
        /// </summary>
        /// <param name="arrayOfValues"></param>
        /// <returns></returns>
        public static (int gcd, string elapsedTime) EuclideanBinaryAlgorithmMethod(params int[] arrayOfValues)
        {
            if (arrayOfValues.Length <= 1) 
            {
                throw new Exception("Method failed. Numbers were not transmitted or one number was transmitted.");
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 1; i < arrayOfValues.Length; i++)
            {
                arrayOfValues[i] = CalculationsEuclideanBinaryAlgorithmMethod(Math.Abs(arrayOfValues[i]), Math.Abs(arrayOfValues[i - 1]));
            }

            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();

            return (arrayOfValues[arrayOfValues.Length - 1], elapsedTime);
        }

        /// <summary>
        /// Computational method for EuclideanAlgorithm
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        private static int CalculationsEuclideanAlgorithmMethod(int numberOne, int numberTwo)
        {
            while (numberOne != numberTwo)
            {
                if (numberOne > numberTwo)
                {
                    numberOne = numberOne - numberTwo;
                }
                else
                {
                    numberTwo = numberTwo - numberOne;
                }
            }

            return numberOne;
        }

        /// <summary>
        /// Computational method for EuclideanBinaryAlgorithm
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        private static int CalculationsEuclideanBinaryAlgorithmMethod(int numberOne, int numberTwo)
        {
            if (numberOne == numberTwo)
            {
                return numberOne;
            }

            if (numberOne == 0)
            {
                return numberTwo;
            }

            if (numberTwo == 0)
            {
                return numberOne;
            }

            if ((~numberOne & 1) != 0)
            {
                if ((numberTwo & 1) != 0)
                {
                    return CalculationsEuclideanBinaryAlgorithmMethod(numberOne >> 1, numberTwo);
                }
                else
                {
                    return CalculationsEuclideanBinaryAlgorithmMethod(numberOne >> 1, numberTwo >> 1) << 1;
                }
            }

            if ((~numberTwo & 1) != 0)
            {
                return CalculationsEuclideanBinaryAlgorithmMethod(numberOne, numberTwo >> 1);
            }

            if (numberOne > numberTwo)
            {
                return CalculationsEuclideanBinaryAlgorithmMethod((numberOne - numberTwo) >> 1, numberTwo);
            }

            return CalculationsEuclideanBinaryAlgorithmMethod((numberTwo - numberOne) >> 1, numberOne);
        }
    }
}