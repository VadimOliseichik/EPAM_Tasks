using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3_GenericClassBinarySearchTree.Tests
{
    public class Book : IComparable<Book>
    {
        /// <summary>
        /// Field Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Field ISBN
        /// Has a fixed size
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Field Author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Field Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Field PublishingHouse
        /// </summary>
        public string PublishingHouse { get; set; }

        /// <summary>
        /// Field TheYearOfPublishing
        /// </summary>
        public int TheYearOfPublishing { get; set; }

        /// <summary>
        /// Field NumberOfPages
        /// Value Boundaries Set
        /// </summary>
        public int NumberOfPages { get; set; }

        /// <summary>
        /// Field Price
        /// Cannot be empty
        /// </summary>
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