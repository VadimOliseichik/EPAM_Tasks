using NUnit.Framework;
using Task_2_FindNextBiggerNumber; 

namespace NUnitTestTask_2_FindNextBiggerNumber
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        public void Test1(int oneNumber, int expected)
        {
            int actual = Program.FindNextBiggerNumber(oneNumber);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
    }
}