using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Task_2_GeneralizedMatrixClasses
{
    /// <summary>
    /// Class matrix addition.
    /// </summary>
    public static class MatrixAddition
    {
        /// <summary>
        /// Matrix addition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrixOne">One matrix.</param>
        /// <param name="matrixTwo">Two matrix.</param>
        /// <returns>Returned matrix of type.</returns>
        public static Matrix<T> AddMatricies<T>(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne == null)
            {
                throw new ArgumentNullException(nameof(matrixOne));
            }

            if (matrixTwo == null)
            {
                throw new ArgumentNullException(nameof(matrixOne));
            }

            if (!(matrixOne.LengthRow() == matrixTwo.LengthRow()) && !(matrixOne.LengthColum() == matrixTwo.LengthColum()))
            {
                throw new Exception("Разный размер матриц.");
            }

            T[,] matrixResult = new T[matrixOne.LengthRow(), matrixOne.LengthColum()];

            for (int i = 0; i < matrixOne.LengthRow(); i++)
            {
                for (int j = 0; j < matrixOne.LengthColum(); j++)
                {
                    matrixResult[i, j] = Adding(matrixOne.GetMatrix()[i, j], matrixTwo.GetMatrix()[i, j]);
                }
            }

            if (typeof(MatrixDiagonal<T>) == matrixOne.GetType() && typeof(MatrixDiagonal<T>) == matrixTwo.GetType())
            {
                return new MatrixDiagonal<T>(matrixResult);
            }
            else if (typeof(MatrixSymmetrical<T>) == matrixOne.GetType() && typeof(MatrixSymmetrical<T>) == matrixTwo.GetType())
            {
                return new MatrixSymmetrical<T>(matrixResult);
            }
            else
            {
                return new MatrixSquare<T>(matrixResult);
            }
        }

        /// <summary>
        /// Addition of type T operands.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrixOne">One matrix.</param>
        /// <param name="matrixTwo">Two matrix.</param>
        /// <returns>Returned matrix of type.</returns>
        private static T Adding<T>(T matrixOne, T matrixTwo)
        {
            if (matrixOne == null)
            {
                throw new ArgumentNullException(nameof(matrixOne));
            }

            if (matrixTwo == null)
            {
                throw new ArgumentNullException(nameof(matrixTwo));
            }

            if (typeof(T) == typeof(string))
            {
                dynamic oneMatrixx = matrixOne;
                dynamic twoMatrixx = matrixTwo;

                return oneMatrixx + twoMatrixx;
            }

            ParameterExpression oneMatrix = Expression.Parameter(typeof(T), "matrixOne");
            ParameterExpression twoMatrix = Expression.Parameter(typeof(T), "matrixTwo");

            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(Expression.Add(oneMatrix, twoMatrix), oneMatrix, twoMatrix).Compile();

            return add(matrixOne, matrixTwo);
        }
    }
}
