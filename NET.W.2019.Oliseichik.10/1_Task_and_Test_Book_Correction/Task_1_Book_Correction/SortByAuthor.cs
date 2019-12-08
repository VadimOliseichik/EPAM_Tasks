using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_Book_Correction
{
    /// <summary>
    /// Class to sort by Author
    /// Override method TagCompare for comparing objects by a Author field
    /// </summary>
    public class SortByAuthor : SortingBooksWithAPatternTemplateMethod
    {
        public override int TagCompare(Book oneBook, Book twoBook)
        {
            return string.Compare(oneBook.Author, twoBook.Author, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
