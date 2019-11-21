using System;
using System.Runtime.InteropServices;

namespace Task_2_DoubleToBinaryConvert
{
    /// <summary>
    /// Class with extension method for converting double to binary
    /// </summary>
    public static class FindBinaryFromDouble
    {
        /// <summary>
        /// Double to binary conversion method
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string BinaryFromDoubleMethod(this double number)
        {
            long longBytes = DoubleToLong(number);

            char[] binaryStringElements = new char[(int)Math.Pow(8, 2)];

            if (longBytes < 0)
            {
                binaryStringElements[0] = '1';
            }
            else
            {
                binaryStringElements[0] = '0';
            }

            for (int i = (int)Math.Pow(8, 2) - 2, j = 1; i >= 0; i--, j++)
            {
                binaryStringElements[j] = (longBytes & (1L << i)) != 0 ? '1' : '0';
            }

            string binaryString = new string(binaryStringElements);

            return binaryString;
        }

        /// <summary>
        /// A method that returns a long variable
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static long DoubleToLong(double number)
        {
            return new DoubleToLongStruct { Double = number }.Long;
        }

        /// <summary>
        /// An explicit layout user structure 
        /// that defines both long and double at offset 0
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            public long Long;
            [FieldOffset(0)]
            public double Double;
        }
    }
}
