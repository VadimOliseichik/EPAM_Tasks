using NUnit.Framework;
using Task_1_InsertNumber; 

namespace NUnitTest_Task_1_InsertNumber
{
    [TestFixture()]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(8, 15, 3, 8, 120)]
        [TestCase(8, 15, 0, 0, 9)]
        [TestCase(15, 15, 0, 0, 15)]
        public void Test1(int a, int b, int c, int d, double expected)
        {
            // получение значения с помощью тестируемого метода

            double actual = Program.InsertNumber(a, b, c, d);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
    }
}