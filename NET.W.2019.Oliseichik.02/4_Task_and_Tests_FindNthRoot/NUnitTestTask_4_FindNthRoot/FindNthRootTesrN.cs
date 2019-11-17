using NUnit.Framework;
using Task_4_FindNthRoot; 

namespace NUnitTestTask_4_FindNthRoot
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 5, 0.0001, 1, 3)]
        [TestCase(0.04100625, 4, 0.0001, 0.45, 3)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545, 3)]
        public void Test1(double a, double b, double c, double expected, int e)
        {
            double actual = System.Math.Round(Program.FindNthRoot(a, b, c), e);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
    }
}