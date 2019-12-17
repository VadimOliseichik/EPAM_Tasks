using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Task_3_GenericClassBinarySearchTree.Tests
{
    [TestFixture]
    public class BinaryTreeSearchTest
    {
        [Test]
        public void IntTest()
        {
            List<int> inOreder = new List<int> { 1, 2, 3, 6, 7 };

            List<int> postOrder = new List<int> { 1, 3, 6, 2, 7 };

            List<int> preOrder = new List<int> { 7, 2, 1, 6, 3 };

            BinaryTreeSearch<int> tree = new BinaryTreeSearch<int>();

            tree.AddItem(7);
            Assert.AreEqual(1, tree.GetCount());

            tree.AddItem(2);
            Assert.IsTrue(tree.Contains(2));

            tree.AddItem(9);
            Assert.AreEqual(3, tree.GetCount());

            tree.AddItem(6);
            Assert.AreEqual(4, tree.GetCount());

            tree.AddItem(1);
            Assert.AreEqual(5, tree.GetCount());

            tree.AddItem(3);
            Assert.AreEqual(6, tree.GetCount());

            tree.Delete(9);
            Assert.IsFalse(tree.Contains(9));
            Assert.AreEqual(5, tree.GetCount());

            Assert.AreEqual(inOreder, tree.InOrder().ToList());

            Assert.AreEqual(postOrder, tree.PostOrder().ToList());

            Assert.AreEqual(preOrder, tree.PreOrder().ToList());
        }

        [Test]
        public void StringTest()
        {
            List<string> inOreder = new List<string> { "дела", "как", "привет", "тебя", "у" };

            List<string> postOrder = new List<string> { "дела", "привет", "как", "у", "тебя" };

            List<string> preOrder = new List<string> { "тебя", "как", "дела", "привет", "у" };

            BinaryTreeSearch<string> tree = new BinaryTreeSearch<string>();

            tree.AddItem("тебя");
            Assert.AreEqual(1, tree.GetCount());

            tree.AddItem("как");
            Assert.IsTrue(tree.Contains("как"));

            tree.AddItem("тест");
            Assert.AreEqual(3, tree.GetCount());

            tree.AddItem("у");
            Assert.AreEqual(4, tree.GetCount());

            tree.AddItem("привет");
            Assert.AreEqual(5, tree.GetCount());

            tree.AddItem("дела");
            Assert.AreEqual(6, tree.GetCount());

            tree.Delete("тест");
            Assert.IsFalse(tree.Contains("тест"));
            Assert.AreEqual(5, tree.GetCount());

            Assert.AreEqual(inOreder, tree.InOrder().ToList());

            Assert.AreEqual(postOrder, tree.PostOrder().ToList());

            Assert.AreEqual(preOrder, tree.PreOrder().ToList());
        }

        [Test]
        public void BookTest()
        {
            Book book1 = new Book
            {
                Id = 1,
                ISBN = "111-1-11-1111-1111-1",
                Author = "Grisha",
                Title = "C#",
                PublishingHouse = "Epam",
                TheYearOfPublishing = 2018,
                NumberOfPages = 351,
                Price = 12
            };

            Book book2 = new Book
            {
                Id = 2,
                ISBN = "222-2-22-2222-2222-2",
                Author = "Vitao",
                Title = "C++",
                PublishingHouse = "Itransition",
                TheYearOfPublishing = 2015,
                NumberOfPages = 101,
                Price = 5
            };

            Book book3 = new Book
            {
                Id = 3,
                ISBN = "333-3-33-3333-3333-3",
                Author = "Vano",
                Title = "Ruby",
                PublishingHouse = "Epam",
                TheYearOfPublishing = 2008,
                NumberOfPages = 205,
                Price = 11
            };

            Book book4 = new Book
            {
                Id = 4,
                ISBN = "444-4-44-4444-4444-4",
                Author = "Vova",
                Title = "Python",
                PublishingHouse = "Epam",
                TheYearOfPublishing = 2014,
                NumberOfPages = 23,
                Price = 5
            };

            Book book5 = new Book
            {
                Id = 5,
                ISBN = "555-5-55-5555-5555-5",
                Author = "Sasha",
                Title = "C",
                PublishingHouse = "Epam",
                TheYearOfPublishing = 2003,
                NumberOfPages = 45,
                Price = 6
            };

            Book book6 = new Book
            {
                Id = 6,
                ISBN = "666-6-66-6666-6666-6",
                Author = "Stepan",
                Title = "Swift",
                PublishingHouse = "Epam",
                TheYearOfPublishing = 2007,
                NumberOfPages = 56,
                Price = 8
            };

            List<Book> inOreder = new List<Book> { book5, book1, book2, book4, book3 };

            List<Book> postOrder = new List<Book> { book1, book5, book2, book3, book4 };

            List<Book> preOrder = new List<Book> { book4, book2, book5, book1, book3 };

            BinaryTreeSearch<Book> tree = new BinaryTreeSearch<Book>();

            tree.AddItem(book4);
            Assert.AreEqual(1, tree.GetCount());

            tree.AddItem(book2);
            Assert.IsTrue(tree.Contains(book2));

            tree.AddItem(book6);
            Assert.AreEqual(3, tree.GetCount());

            tree.AddItem(book5);
            Assert.AreEqual(4, tree.GetCount());

            tree.AddItem(book3);
            Assert.AreEqual(5, tree.GetCount());

            tree.AddItem(book1);
            Assert.AreEqual(6, tree.GetCount());

            tree.Delete(book6);
            Assert.IsFalse(tree.Contains(book6));
            Assert.AreEqual(5, tree.GetCount());

            Assert.AreEqual(inOreder, tree.InOrder().ToList());

            Assert.AreEqual(postOrder, tree.PostOrder().ToList());

            Assert.AreEqual(preOrder, tree.PreOrder().ToList());
        }

        [Test]
        public void PointTest()
        {
            Point point1 = new Point
            {
                OperandOne = 1,
                OperandTwo = 3
            };

            Point point2 = new Point
            {
                OperandOne = 9,
                OperandTwo = 2
            };

            Point point3 = new Point
            {
                OperandOne = 0,
                OperandTwo = 15
            };

            Point point4 = new Point
            {
                OperandOne = 34,
                OperandTwo = 2
            };

            Point point5 = new Point
            {
                OperandOne = 3,
                OperandTwo = 5
            };

            Point point6 = new Point
            {
                OperandOne = 1,
                OperandTwo = 1
            };

            List<Point> inOreder = new List<Point> { point1, point5, point2, point3, point4 };

            List<Point> postOrder = new List<Point> { point5, point1, point3, point2, point4 };

            List<Point> preOrder = new List<Point> { point4, point2, point1, point5, point3 };

            BinaryTreeSearch<Point> tree = new BinaryTreeSearch<Point>(new ComparerPoint());

            tree.AddItem(point4);
            Assert.AreEqual(1, tree.GetCount());

            tree.AddItem(point2);
            Assert.IsTrue(tree.Contains(point2));

            tree.AddItem(point6);
            Assert.AreEqual(3, tree.GetCount());

            tree.AddItem(point5);
            Assert.AreEqual(4, tree.GetCount());

            tree.AddItem(point3);
            Assert.AreEqual(5, tree.GetCount());

            tree.AddItem(point1);
            Assert.AreEqual(6, tree.GetCount());

            tree.Delete(point6);
            Assert.IsFalse(tree.Contains(point6));
            Assert.AreEqual(5, tree.GetCount());

            Assert.AreEqual(inOreder, tree.InOrder().ToList());

            Assert.AreEqual(postOrder, tree.PostOrder().ToList());

            Assert.AreEqual(preOrder, tree.PreOrder().ToList());
        }
    }
}