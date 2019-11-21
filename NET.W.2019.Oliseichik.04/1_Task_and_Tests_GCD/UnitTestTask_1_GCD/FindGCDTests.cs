using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1_GCD;

namespace UnitTestTask_1_GCD
{
    /// <summary>
    /// Testing class
    /// </summary>
    [TestClass]
    public class FindGCDTests
    {
        /// <summary>
        /// Test Method for EuclideanAlgorithmMethod 
        /// Numbers: 10, 20, 160, 40  
        /// Result: 10
        /// </summary>
        [TestMethod]
        public void EuclideanAlgorithmMethod_10and20and160and40_10_GCD_Returned()
        {
            int expected = 10;

            int actual;
            string time;
            (actual, time) = FindGCD.EuclideanAlgorithmMethod(10, 20, 160, 40);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Method for EuclideanAlgorithmMethod 
        /// Numbers: 5, 15, 30 
        /// Result: 5
        /// </summary>
        [TestMethod]
        public void EuclideanAlgorithmMethod_5and15and30_5_GCD_Returned()
        {
            int expected = 5;

            int actual;
            string time;
            (actual, time) = expected.EuclideanAlgorithmMethod(15, 30);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Method for EuclideanAlgorithmMethod 
        /// Numbers: 3, 10 
        /// Result: 1
        /// </summary>
        [TestMethod]
        public void EuclideanAlgorithmMethod_3and10_5_GCD_Returned()
        {
            int expected = 1;

            int actual;
            string time;
            (actual, time) = FindGCD.EuclideanAlgorithmMethod(3, 10);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Method for EuclideanAlgorithmMethod 
        /// Numbers: 3, 10 
        /// Result: 1
        /// </summary>
        [TestMethod]
        public void EuclideanBinaryAlgorithmMethod_3and10_1_GCD_Returned()
        {
            int expected = 1;

            int actual;
            string time;
            (actual, time) = FindGCD.EuclideanBinaryAlgorithmMethod(3, 10);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test Method for EuclideanAlgorithmMethod 
        /// Numbers: 5, 15, 30 
        /// Result: 5
        /// </summary>
        [TestMethod]
        public void EuclideanBinaryAlgorithmMethod_5and15and30_5_GCD_Returned()
        {
            int expected = 5;

            int actual;
            string time;
            (actual, time) = expected.EuclideanBinaryAlgorithmMethod(15, 30);

            Assert.AreEqual(expected, actual);
        }
    }
}
