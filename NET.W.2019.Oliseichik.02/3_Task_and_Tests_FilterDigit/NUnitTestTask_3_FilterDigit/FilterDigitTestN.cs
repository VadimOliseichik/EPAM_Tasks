using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Task_3_FilterDigit; 

namespace NUnitTestTask_3_FilterDigit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new[] { 7, 70, 17 }, 7)]
        [TestCase(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new[] { 5, 15 }, 5)]
        [TestCase(new[] { 7, 1, 333, 3, 4, 5, 6, 7, 13, 69, 70, 15, 17 }, new[] { 333, 3, 13 }, 3)]
        public void Test1(int[] numbersInt, int[] expected, int number)
        {
            List<int> actual = Program.FilterDigit(numbersInt.ToList(), number);

            // сравнение ожидаемого результата с полученным
            CollectionAssert.AreEqual(expected.ToList(), actual);
            Assert.Pass();
        }
    }
}