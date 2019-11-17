using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1_InsertNumber;

namespace MSUnitTest_Task_1_InsertNumber
{
    [TestClass]
    public class InsertNumbetTestMS
    {
        [TestMethod]
        public void TestMethod1()
        {
            double expected = 120;

            // получение значения с помощью тестируемого метода

            double actual = Program.InsertNumber(8, 15, 3, 8);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            double expected = 9;

            // получение значения с помощью тестируемого метода

            double actual = Program.InsertNumber(8, 15, 0, 0);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestMethod3()
        {
            double expected = 15;

            // получение значения с помощью тестируемого метода

            double actual = Program.InsertNumber(15, 15, 0, 0);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
        }
    }
}
