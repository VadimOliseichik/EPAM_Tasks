using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2_DoubleToBinaryConvert;

namespace Task_2_DoubleToBinaryConvert.Tests
{
    [TestClass]
    public class FindBinaryFromDoubleTests
    {
        [TestMethod]
        public void BinaryFromDoubleMethod_Enter0comma0inDouble_returned0000000000000000000000000000000000000000000000000000000000000000()
        {
            double expected = 0.0;

            string binaryNumber;
            binaryNumber = expected.BinaryFromDoubleMethod();

            Assert.AreEqual(binaryNumber, "0000000000000000000000000000000000000000000000000000000000000000");
        }

        [TestMethod]
        public void BinaryFromDoubleMethod_EnterMinus0comma0inDouble_returned1000000000000000000000000000000000000000000000000000000000000000()
        {
            double expected = -0.0;

            string binaryNumber;
            binaryNumber = expected.BinaryFromDoubleMethod();

            Assert.AreEqual(binaryNumber, "1000000000000000000000000000000000000000000000000000000000000000");
        }

        [TestMethod]
        public void BinaryFromDoubleMethod_EnterMinus255comma255inDouble_returned1100000001101111111010000010100011110101110000101000111101011100()
        {
            double expected = -255.255;

            string binaryNumber;
            binaryNumber = expected.BinaryFromDoubleMethod();

            Assert.AreEqual(binaryNumber, "1100000001101111111010000010100011110101110000101000111101011100");
        }

        [TestMethod]
        public void BinaryFromDoubleMethod_Enter255comma255inDouble_returned0100000001101111111010000010100011110101110000101000111101011100()
        {
            double expected = 255.255;

            string binaryNumber;
            binaryNumber = expected.BinaryFromDoubleMethod();

            Assert.AreEqual(binaryNumber, "0100000001101111111010000010100011110101110000101000111101011100");
        }

        [TestMethod]
        public void BinaryFromDoubleMethod_Enter4294967295inDouble_returned0100000111101111111111111111111111111111111000000000000000000000()
        {
            double expected = 4294967295.0;

            string binaryNumber;
            binaryNumber = expected.BinaryFromDoubleMethod();

            Assert.AreEqual(binaryNumber, "0100000111101111111111111111111111111111111000000000000000000000");
        }

        [TestMethod]
        public void BinaryFromDoubleMethod_EnterMinValueDouble_returned1111111111101111111111111111111111111111111111111111111111111111()
        {
            double expected = double.MinValue;

            string binaryNumber;
            binaryNumber = expected.BinaryFromDoubleMethod();

            Assert.AreEqual(binaryNumber, "1111111111101111111111111111111111111111111111111111111111111111");
        }

        [TestMethod]
        public void BinaryFromDoubleMethod_EnterMaxValueDouble_returned0111111111101111111111111111111111111111111111111111111111111111()
        {
            double expected = double.MaxValue;

            string binaryNumber;
            binaryNumber = expected.BinaryFromDoubleMethod();

            Assert.AreEqual(binaryNumber, "0111111111101111111111111111111111111111111111111111111111111111");
        }

        [TestMethod]
        public void BinaryFromDoubleMethod_EnterEpsilonDouble_returned0000000000000000000000000000000000000000000000000000000000000001()
        {
            double expected = double.Epsilon;

            string binaryNumber;
            binaryNumber = expected.BinaryFromDoubleMethod();

            Assert.AreEqual(binaryNumber, "0000000000000000000000000000000000000000000000000000000000000001");
        }

        [TestMethod]
        public void BinaryFromDoubleMethod_EnterNaNDouble_returned1111111111111000000000000000000000000000000000000000000000000000()
        {
            double expected = double.NaN;

            string binaryNumber;
            binaryNumber = expected.BinaryFromDoubleMethod();

            Assert.AreEqual(binaryNumber, "1111111111111000000000000000000000000000000000000000000000000000");
        }

        [TestMethod]
        public void BinaryFromDoubleMethod_EnterNegativeInfinityDouble_returned1111111111110000000000000000000000000000000000000000000000000000()
        {
            double expected = double.NegativeInfinity;

            string binaryNumber;
            binaryNumber = expected.BinaryFromDoubleMethod();

            Assert.AreEqual(binaryNumber, "1111111111110000000000000000000000000000000000000000000000000000");
        }
    }
}
