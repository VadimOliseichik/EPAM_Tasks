using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace DAL.Interface.Interfaces
{
    public interface IStorage
    {
        void Upgrade(Score score);

        void Create(Score bankAccount);

        List<Score> ScoreGetAll();

        Score SearchAndGetById(int id);
    }
}
