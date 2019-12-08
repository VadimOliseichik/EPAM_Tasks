using NUnit.Framework;
using Task_1_GCD_Correction;

namespace Task_1_GCD_Correction.Tests
{
    /// <summary>
    /// Testing class
    /// </summary>
    public class FindGCDTests
    {
        // <summary>
        /// Test Method for EuclideanBinaryAlgorithmMethod.
        /// Three tests: 
        /// 1. Numbers: 10, 20 
        /// Result: 10
        /// 2. Numbers: 5, 15 
        /// Result: 5
        /// 3. Numbers: 3, 10
        /// Result: 1
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        [TestCase(10, 10, 20)]
        [TestCase(5, 5, 15)]
        [TestCase(1, 3, 10)]
        public void EuclideanAlgorithmMethod_numberOneandnumberTwo_returned10(int expected, int numberOne, int numberTwo)
        {
            int actual;
            actual = FindGCD.EuclideanAlgorithmMethod(numberOne, numberTwo);

            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }

        /// <summary>
        /// Test Method for EuclideanAlgorithmMethod 
        /// Three tests: 
        /// 1. Numbers: 10, 20, -20, 40, -80
        /// Result: 10
        /// 2. Numbers: 5, 15, 30, 60
        /// Result: 5
        /// 3. Numbers: 3, 10, 20, 330
        /// Result: 1
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="a"></param>
        [TestCase(10, 10, 20, -20, 40, -80)]
        [TestCase(5, 5, 15, 30, 60)]
        [TestCase(1, 3, 10, 20, 330)]
        public void EuclideanAlgorithmMethod_paramsGCD_returned10(int expected, params int[] a)
        {
            int actual;
            actual = FindGCD.EuclideanAlgorithmMethod(a);

            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }

        /// <summary>
        /// Test Method for EuclideanBinaryAlgorithmMethod 
        /// Three tests: 
        /// 1. Numbers: 10, 20, -20, 40, -80
        /// Result: 10
        /// 2. Numbers: 5, 15, 30, 60
        /// Result: 5
        /// 3. Numbers: 3, 10, 20, 330
        /// Result: 1
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="a"></param>
        [TestCase(10, 10, 20, -20, 40, -80)]
        [TestCase(5, 5, 15, 30, 60)]
        [TestCase(1, 3, 10, 20, 330)]
        public void EuclideanBinaryAlgorithmMethod_paramsGCD_returned10(int expected, params int[] a)
        {
            int actual;
            actual = FindGCD.EuclideanAlgorithmMethod(a);

            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }

        /// <summary>
        /// Test Method for EuclideanBinaryAlgorithmMethod 
        /// Three tests: 
        /// 1. Numbers: 10, 20 
        /// Result: 10
        /// 2. Numbers: 5, 15 
        /// Result: 5
        /// 3. Numbers: 3, 10 
        /// Result: 1
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        [TestCase(10, 10, 20)]
        [TestCase(5, 5, 15)]
        [TestCase(1, 3, 10)]
        public void EuclideanBinaryAlgorithmMethod_numberOneandnumberTwo_returned10(int expected, int numberOne, int numberTwo)
        {
            int actual;
            actual = FindGCD.EuclideanBinaryAlgorithmMethod(numberOne, numberTwo);

            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
    }
}