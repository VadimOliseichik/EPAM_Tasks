using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_Book
{
    /// <summary>
    /// Class to sort by Title
    /// Override method TagCompare for comparing objects by a Title field
    /// </summary>
    public class SortByTitle : SortingBooksWithAPatternTemplateMethod
    {
        public override int TagCompare(Book oneBook, Book twoBook)
        {
            return string.Compare(oneBook.Title, twoBook.Title, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
