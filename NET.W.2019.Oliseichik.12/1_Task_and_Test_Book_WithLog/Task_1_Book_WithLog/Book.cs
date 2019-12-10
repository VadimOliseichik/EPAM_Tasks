using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Task_1_Book_WithLog
{
    /// <summary>
    /// Class Book with fields ID,ISBN,Author,Title,PublishingHouse,TheYearOfPublishing,NumberOfPages,Price
    /// and override methods ToString,Equals,GetHashCode of Object class
    /// and interface methods Equals,CompareTo
    /// </summary>
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        /// <summary>
        /// Field Id
        /// Cannot be empty
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Field ISBN
        /// Cannot be empty
        /// Has a fixed size
        /// </summary>
        [Required]
        [StringLength(17, MinimumLength = 17)]
        public string ISBN { get; set; }

        /// <summary>
        /// Field Author
        /// Cannot be empty
        /// </summary>
        [Required]
        public string Author { get; set; }

        /// <summary>
        /// Field Title
        /// Cannot be empty
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Field PublishingHouse
        /// Cannot be empty
        /// </summary>
        [Required]
        public string PublishingHouse { get; set; }

        /// <summary>
        /// Field TheYearOfPublishing
        /// Cannot be empty
        /// </summary>
        [Required]
        public int TheYearOfPublishing { get; set; }

        /// <summary>
        /// Field NumberOfPages
        /// Cannot be empty
        /// Value Boundaries Set
        /// </summary>
        [Required]
        [Range(1, 50000)]
        public int NumberOfPages { get; set; }

        /// <summary>
        /// Field Price
        /// Cannot be empty
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        /// <summary>
        /// Override method Equals of Object class
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Overriding the class object method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToString(string.Empty);
        }

        /// <summary>
        /// ToString method for a given format.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            if (format == null)
            {
                throw new ArgumentNullException();
            }

            CultureInfo culture = new CultureInfo("en-US");
            string[] arrayField = format.ToLower().Trim().Split("-");
            string testStr = string.Empty;

            if ((arrayField.Length == 1 && format == string.Empty) || format.Equals("all"))
            {
                return "#" + this.Id + ", " + string.Format(new FormatClass(), "ISBN 13: {0:I}", this.ISBN) + ", " + this.Author + ", " + this.Title +
                ", " + this.PublishingHouse + ", " + this.TheYearOfPublishing.ToString() +
                ", " + this.NumberOfPages.ToString() + ", " + this.Price.ToString("00.00$", culture);
            }
            else
            {
                foreach (var field in arrayField)
                {
                    if (field.Equals("id"))
                    {
                        testStr += $"#{this.Id}, ";
                    }

                    if (field.Equals("isbn"))
                    {
                        testStr += string.Format(new FormatClass(), "ISBN 13: {0:I}, ", this.ISBN);
                    }

                    if (field.Equals("author"))
                    {
                        testStr += $"{this.Author}, ";
                    }

                    if (field.Equals("title"))
                    {
                        testStr += $"{this.Title}, ";
                    }

                    if (field.Equals("pubhous"))
                    {
                        testStr += $"{this.PublishingHouse}, ";
                    }

                    if (field.Equals("year"))
                    {
                        testStr += $"{this.TheYearOfPublishing}, ";
                    }

                    if (field.Equals("numberpage"))
                    {
                        testStr += $"{this.NumberOfPages}, ";
                    }

                    if (field.Equals("price"))
                    {
                        testStr += $"{this.Price.ToString("00.00$", culture)}, ";
                    }
                }

                testStr = testStr.Trim();
                if (testStr[testStr.Length - 1] == ',')
                {
                    testStr = testStr.Substring(0, testStr.Length - 1);
                }
            }

            return testStr;
        }

        /// <summary>
        /// Override method GetHashCode of Object class
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode() + this.ISBN.GetHashCode() + this.Price.GetHashCode() + this.NumberOfPages.GetHashCode() + this.TheYearOfPublishing.GetHashCode();
        }

        /// <summary>
        /// Implementation Equals Method of the Interface
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(Book obj)
        {
            Book objt = (Book)obj;
            if (this.ISBN.Equals(objt.ISBN) && this.Author.Equals(objt.Author) && this.PublishingHouse.Equals(objt.PublishingHouse) &&
                this.Title.Equals(objt.Title) && this.TheYearOfPublishing == objt.TheYearOfPublishing && this.NumberOfPages == objt.NumberOfPages)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Implementation CompareTo Method of the IComparable Interface
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Book obj)
        {
            if (obj != null)
            {
                return this.Title.CompareTo(obj.Title);
            }
            else
            {
                throw new Exception("Невозможно сравнить два объекта");
            }
        }
    }
}
