using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3_GenericClassBinarySearchTree.Tests
{
    /// <summary>
    /// Class ComparerPoint.
    /// </summary>
    public class ComparerPoint : IComparer<Point>
    {
        /// <summary>
        /// Compare for struct Point.
        /// </summary>
        /// <param name="x">Parameter one of type Point.</param>
        /// <param name="y">Parameter two of type Point.</param>
        /// <returns>Result compare.</returns>
        public int Compare(Point x, Point y)
        {
            if (x.OperandOne + x.OperandTwo > y.OperandOne + y.OperandTwo)
            {
                return 1;
            }

            if (x.OperandOne + x.OperandTwo < y.OperandOne + y.OperandTwo)
            {
                return -1;
            }

            return 0;
        }
    }
}
