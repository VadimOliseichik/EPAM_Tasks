using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Task_1_GCD_Correction
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
        public static int EuclideanAlgorithmMethod(this int numberOne, int numberTwo)
        {
            while (numberOne != numberTwo)
            {
                if (numberOne > numberTwo)
                {
                    numberOne -= numberTwo;
                }
                else
                {
                    numberTwo -= numberOne;
                }
            }

            return numberOne;
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
        public static int EuclideanAlgorithmMethod(this int numberOne, int numberTwo, int numberThree)
        {
            return CalculationsEuclideanAlgorithmMethod(EuclideanAlgorithmMethod, numberOne, numberTwo, numberThree);
        }

        /// <summary>
        /// EuclideanAlgorithmMethod method overload implementation 
        /// EuclideanAlgorithmMethod method for more than three numbers
        /// </summary>
        /// <param name="arrayOfValues"></param>
        /// <returns></returns>
        public static int EuclideanAlgorithmMethod(params int[] arrayOfValues)
        {
            return CalculationsEuclideanAlgorithmMethod(EuclideanAlgorithmMethod, arrayOfValues);
        }

        /// <summary>
        /// EuclideanBinaryAlgorithmMethod method overload implementation 
        /// EuclideanBinaryAlgorithmMethod method for two numbers
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        public static int EuclideanBinaryAlgorithmMethod(this int numberOne, int numberTwo)
        {
            numberOne = Math.Abs(numberOne);
            numberTwo = Math.Abs(numberTwo);

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
                    return EuclideanBinaryAlgorithmMethod(numberOne >> 1, numberTwo);
                }
                else
                {
                    return EuclideanBinaryAlgorithmMethod(numberOne >> 1, numberTwo >> 1) << 1;
                }
            }

            if ((~numberTwo & 1) != 0)
            {
                return EuclideanBinaryAlgorithmMethod(numberOne, numberTwo >> 1);
            }

            if (numberOne > numberTwo)
            {
                return EuclideanBinaryAlgorithmMethod((numberOne - numberTwo) >> 1, numberTwo);
            }

            return EuclideanBinaryAlgorithmMethod((numberTwo - numberOne) >> 1, numberOne);
        }

        /// <summary>
        /// EuclideanBinaryAlgorithmMethod method overload implementation 
        /// EuclideanBinaryAlgorithmMethod method for three numbers
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <param name="numberThree"></param>
        /// <returns></returns>
        public static int EuclideanBinaryAlgorithmMethod(this int numberOne, int numberTwo, int numberThree)
        {
            return CalculationsEuclideanAlgorithmMethod(EuclideanBinaryAlgorithmMethod, numberOne, numberTwo, numberThree);
        }

        /// <summary>
        /// EuclideanBinaryAlgorithmMethod method overload implementation 
        /// EuclideanBinaryAlgorithmMethod method for more than three numbers
        /// </summary>
        /// <param name="arrayOfValues"></param>
        /// <returns></returns>
        public static int EuclideanBinaryAlgorithmMethod(params int[] arrayOfValues)
        {
            return CalculationsEuclideanAlgorithmMethod(EuclideanBinaryAlgorithmMethod, arrayOfValues);
        }

        /// <summary>
        /// Calculations Euclidean algorithm method for more 3 parametres.
        /// </summary>
        /// <param name="calculations"></param>
        /// <param name="arrayOfValues"></param>
        /// <returns></returns>
        private static int CalculationsEuclideanAlgorithmMethod(Func<int, int, int> calculations, params int[] arrayOfValues)
        {
            if (arrayOfValues == null)
            {
                throw new ArgumentNullException(nameof(arrayOfValues));
            }

            if (arrayOfValues.Length <= 1)
            {
                throw new Exception("Method failed. Numbers were not transmitted or one number was transmitted.");
            }

            for (int i = 1; i < arrayOfValues.Length; i++)
            {
                arrayOfValues[i] = calculations(Math.Abs(arrayOfValues[i]), Math.Abs(arrayOfValues[i - 1]));
            }

            return arrayOfValues[arrayOfValues.Length - 1];
        }

        /// <summary>
        /// Calculations Euclidean algorithm method for 3 parametres.
        /// </summary>
        /// <param name="calculations"></param>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <param name="numberThree"></param>
        /// <returns></returns>
        private static int CalculationsEuclideanAlgorithmMethod(Func<int, int, int> calculations, int numberOne, int numberTwo, int numberThree)
        {
            return calculations(calculations(numberOne, numberTwo), numberThree);
        }
    }
}
