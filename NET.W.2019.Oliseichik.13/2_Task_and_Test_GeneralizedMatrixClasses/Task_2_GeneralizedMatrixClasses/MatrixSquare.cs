using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_GeneralizedMatrixClasses
{
    /// <summary>
    /// Class matrix square.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class MatrixSquare<T> : Matrix<T>
    {
        /// <summary>
        /// Constructor of class MatrixSymmetrical.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        public MatrixSquare(T[,] matrix) : base(matrix)
        {
        }

        /// <summary>
        /// Method check right.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        public override void CheckRight(T[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException();
            }
        }
    }
}
