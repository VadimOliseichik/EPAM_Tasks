using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_GeneralizedMatrixClasses
{
    /// <summary>
    /// ReactionOnChangeEventArgs.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class ReactionOnChangeEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="valueBefore">ValueBefore.</param>
        /// <param name="valueAfter">ValueAfter.</param>
        /// <param name="indexOne">IndexOne.</param>
        /// <param name="indexTwo">IndexTwo.</param>
        public ReactionOnChangeEventArgs(T valueBefore, T valueAfter, int indexOne, int indexTwo)
        {
            this.ValueBefore = valueBefore;
            this.ValueAfter = valueAfter;
            this.IndexOne = indexOne;
            this.IndexTwo = indexTwo;
        }

        /// <summary>
        /// ValueBefore.
        /// </summary>
        public T ValueBefore { get; set; }

        /// <summary>
        /// ValueAfter.
        /// </summary>
        public T ValueAfter { get; set; }

        /// <summary>
        /// IndexOne.
        /// </summary>
        public int IndexOne { get; set; }

        /// <summary>
        /// IndexTwo.
        /// </summary>
        public int IndexTwo { get; set; }
    }
}
