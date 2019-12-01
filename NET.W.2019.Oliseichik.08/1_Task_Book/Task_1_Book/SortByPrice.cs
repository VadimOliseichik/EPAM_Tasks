using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_Book
{
    /// <summary>
    /// Class to sort by Price
    /// Override method TagCompare for comparing objects by a Price field
    /// </summary>
    public class SortByPrice : SortingBooksWithAPatternTemplateMethod
    {
        public override int TagCompare(Book oneBook, Book twoBook)
        {
            return oneBook.Price.CompareTo(twoBook.Price);
        }
    }
}
