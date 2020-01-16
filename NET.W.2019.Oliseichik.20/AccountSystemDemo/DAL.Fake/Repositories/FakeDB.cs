using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Fake.Repositories
{
    public class FakeDB : IStorage
    {
        private readonly ScoreContext db;

        public FakeDB(ScoreContext context)
        {
            db = context;
        }

        public Score SearchAndGetById(int id)
        {
            return db.Scores.Find(id);
        }

        public void Create(Score bankAccount)
        {
            db.Scores.Add(bankAccount);
            db.SaveChanges();
        }

        public void Upgrade(Score score)
        {
            //_context.Update(score);
            db.SaveChanges();
        }

        public List<Score> ScoreGetAll()
        {
            return db.Scores.ToList();
        }
    }
}
