using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BLL.Testss
{
    public class ScoreServiceTest
    {
        private static IScoreService scoreService;

        private static Mock<IStorage> mock;

        [Test]
        public void OpenScoreTest()
        {
            SetupMock();
            string id = scoreService.OpenScore(new Client("Vadim", "Oliseichik"), ScoreType.Base);

            string[] a = scoreService.ShowInformation(id).Split(' ', 2);

            Assert.AreEqual("Open Vadim Oliseichik 0 0", a[1]);
            Assert.Pass();
        }

        [Test]
        public void TopUpAccountTest()
        {
            SetupMock();
            string id = scoreService.OpenScore(new Client("Vadim", "Oliseichik"), ScoreType.Base);

            scoreService.TopUpAccount(id, 1000);

            string[] a = scoreService.ShowInformation(id).Split(' ', 2);

            Assert.AreEqual("Open Vadim Oliseichik 1000 5", a[1]);
            Assert.Pass();
        }

        [Test]
        public void DebitTheAccountTest()
        {
            SetupMock();
            string id = scoreService.OpenScore(new Client("Vania", "Library"), ScoreType.Base);

            scoreService.TopUpAccount(id, 1000);

            scoreService.DebitTheAccount(id, 100);

            string[] a = scoreService.ShowInformation(id).Split(' ', 2);

            Assert.AreEqual("Open Vania Library 900 2", a[1]);
            Assert.Pass();
        }

        [Test]
        public void CloseScoreTest()
        {
            SetupMock();
            string id = scoreService.OpenScore(new Client("Artem", "Library"), ScoreType.Base);

            scoreService.TopUpAccount(id, 1000);

            scoreService.DebitTheAccount(id, 100);

            scoreService.CloseScore(id);

            string[] a = scoreService.ShowInformation(id).Split(' ', 2);

            Assert.AreEqual("Closed Artem Library 900 2", a[1]);
            Assert.Pass();
        }

        private static void SetupMock()
        {
            mock = new Mock<IStorage>();
            mock.Setup(a => a.ScoreGetAll()).Returns(
                new List<Score>
                {
                    new BaseCart("1", new Client("Vadim", "Oliseichik"), ScoreType.Base, StatusScore.Open, 0, 0),
                    new BaseCart("2", new Client("Vania", "Library"), ScoreType.Base, StatusScore.Open, 0, 0),
                    new BaseCart("3", new Client("Artem", "Library"), ScoreType.Base, StatusScore.Open, 0, 0),
                });
            scoreService = new ScoreService();
        }
    }
}