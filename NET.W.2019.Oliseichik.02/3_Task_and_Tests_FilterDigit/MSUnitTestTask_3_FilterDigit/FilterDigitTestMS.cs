using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task_3_FilterDigit; 

namespace MSUnitTestTask_3_FilterDigit
{
    [TestClass]
    public class FilterDigitTestMS
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<int> expected = new List<int>() { 6, 68, 69 };
            List<int> numbersInt = new List<int>() { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };

            // получение значения с помощью тестируемого метода

            List<int> actual = Program.FilterDigit(numbersInt, 6);

            // сравнение ожидаемого результата с полученным
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<int> expected = new List<int>() { 69 };
            List<int> numbersInt = new List<int>() { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };

            // получение значения с помощью тестируемого метода

            List<int> actual = Program.FilterDigit(numbersInt, 9);

            // сравнение ожидаемого результата с полученным
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            List<int> expected = new List<int>() { 7, 70, 17 };
            List<int> numbersInt = new List<int>() { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            
            // получение значения с помощью тестируемого метода

            List<int> actual = Program.FilterDigit(numbersInt, 7);

            // сравнение ожидаемого результата с полученным
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
