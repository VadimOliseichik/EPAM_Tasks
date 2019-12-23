using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ServiceImplementation;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using NUnit.Framework;
using Moq;

namespace BLL.Tests
{
    [TestFixture]
    public class Test
    {
        public void EuclideanAlgorithmMethod_numberOneandnumberTwo_returned10()
        {

            string id = string.Empty;

            Mock<IScoreService> mock = new Mock<IScoreService>();

            mock.Setup(a => a.OpenScore(new Client("Vadim", "Oliseichik"), ScoreType.Base)).Returns((string s) => s);
            IScoreService scoreService = new ScoreService();
            scoreService.OpenScore(new Client("Vadim", "Oliseichik"), ScoreType.Base).GetType();


            Assert.AreEqual(true, scoreService.OpenScore(new Client("Vadim", "Oliseichik"), ScoreType.Base).GetType());
            Assert.Pass();
        }
    }
}
