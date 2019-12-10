using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_Book_WithLog
{
    /// <summary>
    /// Class to sort by Year
    /// Override method TagCompare for comparing objects by a Year field
    /// </summary>
    public class SortByYear : SortingBooksWithAPatternTemplateMethod
    {
        public override int TagCompare(Book oneBook, Book twoBook)
        {
            return oneBook.TheYearOfPublishing.CompareTo(twoBook.TheYearOfPublishing);
        }
    }
}