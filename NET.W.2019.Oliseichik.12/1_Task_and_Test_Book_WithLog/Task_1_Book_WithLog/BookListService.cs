using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Task_1_Book_WithLog
{
    /// <summary>
    /// Class of service list book
    /// </summary>
    public class BookListService
    {
        /// <summary>
        /// List books.
        /// </summary>
        public readonly List<Book> ListBooks = new List<Book>();

        /// <summary>
        /// Culture.
        /// </summary>
        private static CultureInfo culture = new CultureInfo("en-US");

        /// <summary>
        /// Logger.
        /// </summary>
        private static readonly ILogger logger = new NLogger();

        /// <summary>
        /// Method sorting list of books.
        /// </summary>
        /// <param name="comparer"></param>
        public void SortBooksByItem(IComparer<Book> comparer)
        {
            ListBooks.Sort(comparer);
        }

        /// <summary>
        /// Add book method.
        /// Book in list of books.
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <param name="publishingHouse"></param>
        /// <param name="theYearOfPublishing"></param>
        /// <param name="numberOfPages"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public int AddBook(string isbn, string author, string title, string publishingHouse, int theYearOfPublishing, int numberOfPages, decimal price)
        {
            var book = new Book
            {
                Id = this.ListBooks.Count + 1,
                ISBN = isbn,
                Author = author,
                Title = title,
                PublishingHouse = publishingHouse,
                TheYearOfPublishing = theYearOfPublishing,
                NumberOfPages = numberOfPages,
                Price = price,
            };
            ShowException(book);

            BookCheckAvailability(book);

            this.ListBooks.Add(book);

            return book.Id;
        }

        /// <summary>
        /// Remove book method
        /// Book delete from list of books
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool RemoveBook(Book book)
        {
            return this.ListBooks.Remove(book);
        }

        /// <summary>
        /// Method Find By ISBN
        /// </summary>
        /// <param name="itemISBN"></param>
        /// <returns></returns>
        public List<Book> FindByISBN(string itemISBN)
        {
            List<Book> listBookFindByISBN = new List<Book>();
            foreach (var item in this.ListBooks)
            {
                if (itemISBN.Equals(item.ISBN))
                {
                    listBookFindByISBN.Add(item);
                }
            }

            return listBookFindByISBN;
        }

        /// <summary>
        /// Method Find By Author
        /// </summary>
        /// <param name="authorName"></param>
        /// <returns></returns>
        public List<Book> FindByAuthor(string authorName)
        {
            List<Book> listBookFindByAuthor = new List<Book>();
            foreach (var item in this.ListBooks)
            {
                if (authorName.Equals(item.Author))
                {
                    listBookFindByAuthor.Add(item);
                }
            }

            return listBookFindByAuthor;
        }

        /// <summary>
        /// Method Find By Title
        /// </summary>
        /// <param name="itemTitle"></param>
        /// <returns></returns>
        public List<Book> FindByTitle(string itemTitle)
        {
            List<Book> listBookFindByTitle = new List<Book>();
            foreach (var item in this.ListBooks)
            {
                if (itemTitle.Equals(item.Title))
                {
                    listBookFindByTitle.Add(item);
                }
            }

            return listBookFindByTitle;
        }

        /// <summary>
        /// Method Find By Publishing House
        /// </summary>
        /// <param name="itemPublishingHouse"></param>
        /// <returns></returns>
        public List<Book> FindByPublishingHouse(string itemPublishingHouse)
        {
            List<Book> listBookFindByitemPublishingHouse = new List<Book>();
            foreach (var item in this.ListBooks)
            {
                if (itemPublishingHouse.Equals(item.PublishingHouse))
                {
                    listBookFindByitemPublishingHouse.Add(item);
                }
            }

            return listBookFindByitemPublishingHouse;
        }

        /// <summary>
        /// Method Find By The Year Of Publishing
        /// </summary>
        /// <param name="itemTheYearOfPublishing"></param>
        /// <returns></returns>
        public List<Book> FindByTheYearOfPublishing(string itemTheYearOfPublishing)
        {
            List<Book> listBookFindByTheYearOfPublishing = new List<Book>();
            foreach (var item in this.ListBooks)
            {
                if (itemTheYearOfPublishing.Equals(item.TheYearOfPublishing.ToString()))
                {
                    listBookFindByTheYearOfPublishing.Add(item);
                }
            }

            return listBookFindByTheYearOfPublishing;
        }

        /// <summary>
        /// Method Find By Number Of Pages
        /// </summary>
        /// <param name="itemNumberOfPages"></param>
        /// <returns></returns>
        public List<Book> FindByNumberOfPages(string itemNumberOfPages)
        {
            List<Book> listBookFindByNumberOfPages = new List<Book>();
            foreach (var item in this.ListBooks)
            {
                if (itemNumberOfPages.Equals(item.NumberOfPages.ToString()))
                {
                    listBookFindByNumberOfPages.Add(item);
                }
            }

            return listBookFindByNumberOfPages;
        }

        /// <summary>
        /// Method Find By Price
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <returns></returns>
        public List<Book> FindByPrice(string itemPrice)
        {
            List<Book> listBookFindByPrice = new List<Book>();
            foreach (var item in this.ListBooks)
            {
                if (itemPrice.Equals(item.Price.ToString("00.00", culture)))
                {
                    listBookFindByPrice.Add(item);
                }
            }

            return listBookFindByPrice;
        }

        /// <summary>
        /// Get array of Books
        /// </summary>
        /// <returns></returns>
        public Book[] GetBooks()
        {
            return this.ListBooks.ToArray();
        }

        /// <summary>
        /// Book Check Availability
        /// </summary>
        /// <param name="book"></param>
        private void BookCheckAvailability(Book book)
        {
            foreach (var item in this.ListBooks)
            {
                if (book.Equals(item))
                {
                    logger.Error("Such a book already exists.");
                    throw new Exception("Such a book already exists.");
                }
            }
        }

        /// <summary>
        /// Show Exception after adding a book
        /// </summary>
        /// <param name="item"></param>
        private void ShowException(Book item)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(item);
            if (!Validator.TryValidateObject(item, context, results, true))
            {
                logger.Error("Entered incorrect data.");
                throw new ArgumentException("You entered incorrect data.");
            }
        }
    }
}