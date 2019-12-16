using NUnit.Framework;
using System;
using Task_2_GeneralizedMatrixClasses;

namespace Task_2_GeneralizedMatrixClasses.Tests
{
    [TestFixture]
    public class MatrixTest
    {
        private int[,] matrix1 = new int[,]
        {
                { 2, 0, 4, 0, 0 },
                {  0, 2, 0, 10, 0 },
                {  4, 0, 2, 0, 0 },
                {  0, 10, 0, 2, 20 },
                { 0, 0, 0, 20, 2 }
        };

        private int[,] matrix2 = new int[,]
        {
                { 1, 0, 0},
                { 0, 2, 0},
                { 0, 0, 3}
        };

        private int[,] matrix3 = new int[,]
        {
                { 2, 0, 2, 7, 3 },
                {  0, 3, 0, 13, 4 },
                {  2, 0, 4, 0, 1 },
                {  0, 13, 0, 6, 18 },
                { 0, 1, 0, 15, 8 }
        };

        private int[,] matrix4 = new int[,]
        {
                { 1, 0, 2, 0, 0 },
                {  0, 1, 0, 5, 0 },
                {  2, 0, 1, 0, 0 },
                {  0, 5, 0, 1, 10 },
                { 0, 0, 0, 10, 1 }
        };

        private int[,] matrix5 = new int[,]
        {
            { 1, 0, 0, 7, 3 },
            { 0, 2, 0, 8, 4 },
            { 0, 0, 3, 0, 1 },
            { 0, 8, 0, 5, 8 },
            { 0, 1, 0, 5, 7 },
            { 0, 1, 0, 5, 7 }
        };

        private string[,] matrix6 = new string[,]
        {
            {"a", null, "d", null },
            {null, "b",  null, null },
            {"d", null, "c" , null}
        };

        private double[,] matrix7 = new double[,]
        {
            { 1.2, 0, 0},
            { 0, 2.2, 8.2},
            { 0, 8.2, 3.5}
        };

        private int[,] matrix8 = new int[,]
            {
                { 1, 0, 0, 7, 3 },
                { 0, 2, 0, 8, 4 },
                { 0, 0, 3, 0, 1 },
                { 0, 8, 0, 5, 8 },
                { 0, 1, 0, 5, 7 }
            };

        private string[,] matrix9 = new string[,]
        {
            {"a", null, "y" },
            {null, "b",  null },
            {null, null, "c" }
        };

        private int[,] matrix10 = new int[,]
        {
            { 2, 0, 0},
            { 0, 2, 0},
            { 0, 0, 2}
        };

        private double[,] matrix11 = new double[,]
        {
            { 2.4, 0, 0},
            { 0, 4.4, 16.4 },
            { 0, 16.4, 7}
        };

        private string[,] matrix12 = new string[,]
        {
            {"a", null, "d" },
            {null, "b",  null },
            {"d", "u", "c" }
        };

        private int[,] matrix13 = new int[,]
        {
                { 1, 0, 0},
                { 0, 1, 0},
                { 0, 0, 1}
        };

        [Test]
        public void MatrixSimmetriclTest()
        {
            Matrix<int> matrix;
            Matrix<string> matrixString;
            Assert.Throws<ArgumentException>(() => matrix = new MatrixSymmetrical<int>(matrix8));
            Assert.Throws<ArgumentException>(() => matrixString = new MatrixSymmetrical<string>(matrix12));
        }

        [Test]
        public void MatrixAdditionFailTest()
        {
            Assert.Throws<Exception>(() => MatrixAddition.AddMatricies(new MatrixSquare<int>(matrix2), new MatrixSquare<int>(matrix4)));
        }

        [Test]
        public void MatrixSquareTest()
        {
            Matrix<int> matrix;
            Matrix<string> matrixString;
            Assert.Throws<ArgumentException>(() => matrix = new MatrixSquare<int>(matrix5));
            Assert.Throws<ArgumentException>(() => matrixString = new MatrixSquare<string>(matrix6));
        }

        [Test]
        public void MatrixAdditionTest()
        {
            Assert.AreEqual(new MatrixSquare<int>(matrix10), MatrixAddition.AddMatricies(new MatrixSymmetrical<int>(matrix13), new MatrixSymmetrical<int>(matrix13)));
            Assert.AreEqual(new MatrixSquare<int>(matrix3), MatrixAddition.AddMatricies(new MatrixSquare<int>(matrix8), new MatrixSymmetrical<int>(matrix4)));
            Assert.AreEqual(new MatrixSymmetrical<int>(matrix1), MatrixAddition.AddMatricies(new MatrixSymmetrical<int>(matrix4), new MatrixSymmetrical<int>(matrix4)));
            Assert.AreEqual(new MatrixSymmetrical<double>(matrix11), MatrixAddition.AddMatricies(new MatrixSymmetrical<double>(matrix7), new MatrixSymmetrical<double>(matrix7)));
        }

        [Test]
        public void MatrixDiagonalTest()
        {
            Matrix<int> matrix;
            Matrix<string> matrixString;
            Assert.Throws<ArgumentException>(() => matrix = new MatrixDiagonal<int>(matrix4));
            Assert.Throws<ArgumentException>(() => matrixString = new MatrixDiagonal<string>(matrix9));

        }
    }
}