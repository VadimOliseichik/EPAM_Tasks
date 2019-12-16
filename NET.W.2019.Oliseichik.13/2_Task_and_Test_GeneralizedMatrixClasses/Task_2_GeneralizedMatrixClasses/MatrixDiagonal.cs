using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_GeneralizedMatrixClasses
{
    /// <summary>
    /// Class matrix diagonal.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class MatrixDiagonal<T> : Matrix<T>
    {
        /// <summary>
        /// Constructor of class MatrixSymmetrical.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        public MatrixDiagonal(T[,] matrix) : base(matrix)
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

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != j && !Equals(default(T), matrix[i, j]))
                    {
                        throw new ArgumentException();
                    }
                }
            }
        }
    }
}
