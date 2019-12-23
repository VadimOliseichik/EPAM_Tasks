using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    public class FakeStorage : IStorage
    {
        private readonly List<Score> list;

        public FakeStorage()
        {
            this.list = new List<Score>();
        }

        public Score SearchAndGetById(string id)
        {
            return this.list[this.list.FindIndex(c => c.Id == id)];
        }

        public void Create(Score bankAccount)
        {
            this.list.Add(bankAccount);
        }

        public void Upgrade(Score score)
        {
            int indexOfScoreUpgrade = this.list.FindIndex(c => c.Id == score.Id);

            this.list.RemoveAt(indexOfScoreUpgrade);

            this.list.Insert(indexOfScoreUpgrade, score);
        }

        public List<Score> ScoreGetAll()
        {
            return this.list;
        }
    }
}
