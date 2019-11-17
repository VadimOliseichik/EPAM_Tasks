using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_4_FindNthRoot; 

namespace UnitTestTask_4_FindNthRoot
{
    [TestClass]
    public class FindNthRootTestMS
    {
        [TestMethod]
        public void TestMethod1()
        {
            double expected = 1;

            // получение значения с помощью тестируемого метода

            double actual = System.Math.Round(Program.FindNthRoot(1, 5, 0.0001), 3);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            double expected = 0.45;

            // получение значения с помощью тестируемого метода

            double actual = System.Math.Round(Program.FindNthRoot(0.04100625, 4, 0.0001), 3);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            double expected = 0.545;

            // получение значения с помощью тестируемого метода

            double actual = System.Math.Round(Program.FindNthRoot(0.004241979, 9, 0.00000001), 3);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
        }
    }
}