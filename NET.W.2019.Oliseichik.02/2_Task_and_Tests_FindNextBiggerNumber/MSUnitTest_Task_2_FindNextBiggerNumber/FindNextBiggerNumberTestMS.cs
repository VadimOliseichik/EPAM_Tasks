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

            // ��������� �������� � ������� ������������ ������

            int actual = Program.FindNextBiggerNumber(12);

            // ��������� ���������� ���������� � ����������
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int expected = 531;

            // ��������� �������� � ������� ������������ ������

            int actual = Program.FindNextBiggerNumber(513);

            // ��������� ���������� ���������� � ����������
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int expected = 2071;

            // ��������� �������� � ������� ������������ ������

            int actual = Program.FindNextBiggerNumber(2017);

            // ��������� ���������� ���������� � ����������
            Assert.AreEqual(expected, actual);
        }
    }
}
