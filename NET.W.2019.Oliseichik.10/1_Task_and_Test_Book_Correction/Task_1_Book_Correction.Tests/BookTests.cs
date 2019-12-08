using NUnit.Framework;
using System;
using Task_1_Book_Correction;

namespace Task_1_Book_Correction.Tests
{
    public class BookTests
    {
        Book book = new Book()
        {
            Id = 1,
            ISBN = "222-2-2222-2222-2",
            Author = "Vadim",
            Title = "C# .NET",
            PublishingHouse = "EPAM",
            TheYearOfPublishing = 2019,
            NumberOfPages = 201,
            Price = 15M,
        };

        [TestCase("", "#1, ISBN 13: 2222222222222, Vadim, C# .NET, EPAM, 2019, 201, 15.00$")]
        [TestCase("id-isbN-AUThor-Title", "#1, ISBN 13: 2222222222222, Vadim, C# .NET")]
        [TestCase("AUThor-ID", "Vadim, #1")]
        public void FormatToStringforObjectClass(string testParameters, string result)
        {
            string actual = book.ToString(testParameters);
            Assert.AreEqual(result, actual);
            Assert.Pass();
        }

        [TestCase(null)]
        public void TestBookThrows(string testParameters)
        {
            Assert.That(() => book.ToString(testParameters), Throws.TypeOf<ArgumentNullException>());
        }
    }
}