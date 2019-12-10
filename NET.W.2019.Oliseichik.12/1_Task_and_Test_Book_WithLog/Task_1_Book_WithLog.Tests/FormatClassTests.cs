using System;
using NUnit.Framework;
using System.Collections.Generic;
using Task_1_Book_WithLog;
using System.Text;

namespace Task_1_Book_WithLog.Tests
{
    public class FormatClassTests
    {
        [TestCase("222-2-2222-2222-2", "ISBN 13: 2222222222222")]
        public void FormatforObjectClassI(string testParameters, string result)
        {
            string actual = String.Format(new FormatClass(), "ISBN 13: {0:I}", testParameters);
            Assert.AreEqual(actual, result);
            Assert.Pass();
        }

        [TestCase("222-2-2222-2222-2", "ISBN 13: 222-2-2222-2222-2")]
        public void FormatforObjectClassH(string testParameters, string result)
        {
            string actual = String.Format(new FormatClass(), "ISBN 13: {0:H}", testParameters);
            Assert.AreEqual(actual, result);
            Assert.Pass();
        }

        [TestCase("222-2-2222-2222-2", "ISBN 13: 222-2-2222-2222-2")]
        public void FormatforObjectClassG(string testParameters, string result)
        {
            string actual = String.Format(new FormatClass(), "ISBN 13: {0:G}", testParameters);
            Assert.AreEqual(actual, result);
            Assert.Pass();
        }

        [TestCase("", "")]
        public void FormatforObjectClassNull(string testParameters, string result)
        {
            string actual = String.Format(new FormatClass(), "{0:H}", testParameters);
            Assert.AreEqual(actual, result);
            Assert.Pass();
        }
    }
}
