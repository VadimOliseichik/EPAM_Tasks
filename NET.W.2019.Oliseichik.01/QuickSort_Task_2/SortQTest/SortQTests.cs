using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2_QuickSort; 

namespace SortQTest
{
    [TestClass]
    public class SortQTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var arr = new int[5] { 1, 6, 3, 9, 3 };

            int[] expected = { 1, 3, 3, 6, 9 };

            // получение значения с помощью тестируемого метода

            int[] actual = SortQ.QuickSort(arr, 0, arr.Length - 1);

            // сравнение ожидаемого результата с полученным
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var arr = new int[10] { 0, -5, -1, 8, 4, 1, 6, 3, 9, 3 };

            int[] expected = { -5, -1, 0, 1, 3, 3, 4, 6, 8, 9 };

            // получение значения с помощью тестируемого метода

            int[] actual = SortQ.QuickSort(arr, 0, arr.Length - 1);

            // сравнение ожидаемого результата с полученным
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var arr = new int[2] { 0, -10 };

            int[] expected = { -10, 0 };

            // получение значения с помощью тестируемого метода

            int[] actual = SortQ.QuickSort(arr, 0, arr.Length - 1);

            // сравнение ожидаемого результата с полученным
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
