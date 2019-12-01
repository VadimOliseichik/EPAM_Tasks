using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Task_1_Book
{
    /// <summary>
    /// A class implementing an interface IComparer for sorting a list of books
    /// Pattern template method
    /// </summary>
    public abstract class SortingBooksWithAPatternTemplateMethod : IComparer<Book>
    {
        /// <summary>
        /// Abstract class method search by tag
        /// </summary>
        /// <param name="oneBook"></param>
        /// <param name="twoBook"></param>
        /// <returns></returns>
        public abstract int TagCompare(Book oneBook, Book twoBook);

        /// <summary>
        /// Interface IComparer implementation
        /// </summary>
        /// <param name="oneBook"></param>
        /// <param name="twoBook"></param>
        /// <returns></returns>
        public int Compare(Book oneBook, Book twoBook)
        {
            if (oneBook == null || twoBook == null)
            {
                throw new ArgumentNullException();
            }

            if (ReferenceEquals(oneBook, twoBook))
            {
                return 0;
            }

            return TagCompare(oneBook, twoBook);
        }
    }
}