using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_Book
{
    /// <summary>
    /// Class to sort by Number
    /// Override method TagCompare for comparing objects by a Number field
    /// </summary>
    public class SortByNumber : SortingBooksWithAPatternTemplateMethod
    {
        public override int TagCompare(Book oneBook, Book twoBook)
        {
            return oneBook.Id.CompareTo(twoBook.Id);
        }
    }
}
