using BLL.Interface.Entities;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BinaryScoreRepository : IStorage
    {
        /// <summary>
        /// Path to the binary file.
        /// </summary>
        private readonly string filePath;


        private readonly List<Score> list = new List<Score>();

        public BinaryScoreRepository(string path)
        {
            this.filePath = path ?? throw new ArgumentNullException();
        }


        public Score SearchAndGetById(int id)
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
            BinaryFormatter formatter = new BinaryFormatter();

            List<DTO_Score> dtoAccounts;

            using (FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    return new List<Score>();
                }

                dtoAccounts = ((IEnumerable<DTO_Score>)formatter.Deserialize(fs)).ToList();
            }

            List<Score> accounts = new List<Score>();

            foreach (var acc in dtoAccounts)
            {
                accounts.Add(acc.ConvertToBankAccount());
            }

            return accounts;
        }

        public void SaveAccounts(IEnumerable<Score> accounts)
        {
            List<DTO_Score> dtoAccounts = new List<DTO_Score>();

            foreach (var acc in accounts)
            {
                dtoAccounts.Add(acc.ConvertToDTO());
            }

            BinaryFormatter formatter = new BinaryFormatter();

            using FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            formatter.Serialize(fs, dtoAccounts);
        }
    }
}
