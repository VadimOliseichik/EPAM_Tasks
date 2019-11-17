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

            // ��������� �������� � ������� ������������ ������

            double actual = Program.InsertNumber(8, 15, 3, 8);

            // ��������� ���������� ���������� � ����������
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            double expected = 9;

            // ��������� �������� � ������� ������������ ������

            double actual = Program.InsertNumber(8, 15, 0, 0);

            // ��������� ���������� ���������� � ����������
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestMethod3()
        {
            double expected = 15;

            // ��������� �������� � ������� ������������ ������

            double actual = Program.InsertNumber(15, 15, 0, 0);

            // ��������� ���������� ���������� � ����������
            Assert.AreEqual(expected, actual);
        }
    }
}
