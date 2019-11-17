using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2_FindNextBiggerNumber; 

namespace MSUnitTest_Task_2_FindNextBiggerNumber
{
    [TestClass]
    public class FindNextBiggerNumberTestMS
    {
        [TestMethod]
        public void TestMethod1()
        {
            int expected = 21;

            // получение значения с помощью тестируемого метода

            int actual = Program.FindNextBiggerNumber(12);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int expected = 531;

            // получение значения с помощью тестируемого метода

            int actual = Program.FindNextBiggerNumber(513);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int expected = 2071;

            // получение значения с помощью тестируемого метода

            int actual = Program.FindNextBiggerNumber(2017);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
        }
    }
}
