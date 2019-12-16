using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_2_GeneralizedMatrixClasses
{
    /// <summary>
    /// Base class matrix.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Matrix<T> : IEnumerable<T>
    {
        private T[,] matrix;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="matrix"></param>
        public Matrix(T[,] matrix)
        {
            this.matrix = new T[matrix.GetLength(0), matrix.GetLength(1)];

            this.matrix = matrix;

            CheckRight(this.matrix);
        }

        /// <summary>
        /// Event.
        /// </summary>
        public event EventHandler<ReactionOnChangeEventArgs<T>> ReactionOnChange;

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="indexOne">Index one.</param>
        /// <param name="indexTwo">Index two.</param>
        /// <returns>Element of matrix.</returns>
        public T this[int indexOne, int indexTwo]
        {
            get
            {
                if (indexOne < 0 || indexTwo < 0 || indexOne >= this.matrix.GetLength(0) || indexTwo >= this.matrix.GetLength(1))
                {
                    throw new IndexOutOfRangeException();
                }

                return this.matrix[indexOne, indexTwo];
            }

            set
            {
                if (indexOne < 0 || indexTwo < 0 || indexOne >= this.matrix.GetLength(0) || indexTwo >= this.matrix.GetLength(1))
                {
                    throw new IndexOutOfRangeException();
                }

                ReactionOnChange += this.Message;
                this.ReactionOnChange.Invoke(this, new ReactionOnChangeEventArgs<T>(this.matrix[indexOne, indexTwo], value, indexOne, indexTwo));
                ReactionOnChange -= this.Message;

                this.matrix[indexOne, indexTwo] = value;
            }
        }

        /// <summary>
        /// Interface implementation.
        /// </summary>
        /// <returns>IEnumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    yield return this.matrix[i, j];
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Interface implementation.
        /// </summary>
        /// <returns>IEnumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Method check right.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        public abstract void CheckRight(T[,] matrix);

        /// <summary>
        /// Get matrix.
        /// </summary>
        /// <returns>Matrix of type T.</returns>
        public T[,] GetMatrix()
        {
            return this.matrix;
        }

        /// <summary>
        /// Count row.
        /// </summary>
        /// <returns>Count.</returns>
        public int LengthRow()
        {
            return this.matrix.GetLength(0);
        }

        /// <summary>
        /// Count colum.
        /// </summary>
        /// <returns>Count.</returns>
        public int LengthColum()
        {
            return this.matrix.GetLength(1);
        }

        /// <summary>
        /// Message of event.
        /// </summary>
        /// <param name="sender">Sender of type object.</param>
        /// <param name="e">ReactionOnChangeEventArgs<T> e.</param>
        private void Message(object sender, ReactionOnChangeEventArgs<T> e)
        {
            Console.WriteLine($"Element [{e.IndexOne},{e.IndexTwo}] was changed from {e.ValueBefore} to {e.ValueAfter}.");
        }
    }
}
