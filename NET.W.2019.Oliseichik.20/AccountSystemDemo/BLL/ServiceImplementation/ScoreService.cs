using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Fake.Repositories;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Repositories;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Service to work with bank accounts.
    /// </summary>
    public class ScoreService : IScoreService
    {
        private IStorage scores;
        private IGenerateScoreIdService generateIdService;

        public ScoreService(IStorage storage)
        {
            this.scores = storage;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreService"/> class.
        /// </summary>
        //public ScoreService()
        //{
        //    this.scores = new FakeStorage();
        //    this.generateIdService = new GenerateScoreId();
        //}

        public ScoreService(ScoreContext context)
        {
            this.scores = new FakeDB(context);
            this.generateIdService = new GenerateScoreId();
        }

        /// <summary>
        /// Opens the account.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="scoreType">The type of score.</param>
        /// <param name="id">The identifier.</param>
        public void OpenScore(Client client, ScoreType scoreType, out int id)
        {
            Score score;
            id = (this.generateIdService.ScoreIdGenerate(client.ToString() + " " + scoreType.ToString())).GetHashCode();

            switch ((int)scoreType)
            {
                case 0:
                    score = new BaseCart(client, scoreType, StatusScore.Open, 0, 0);
                    break;
                case 1:
                    score = new GoldCart(client, scoreType, StatusScore.Open, 0, 0);
                    break;
                case 2:
                    score = new PlatinumCart(client, scoreType, StatusScore.Open, 0, 0);
                    break;
                default:
                    score = new BaseCart(client, scoreType, StatusScore.Open, 0, 0);
                    break;
            }

            score.Status = StatusScore.Open;

            this.scores.Create(score);
        }

        public int OpenScore(Client client, ScoreType scoreType)
        {
            Score score;
            int id = (this.generateIdService.ScoreIdGenerate(client.ToString() + " " + scoreType.ToString())).GetHashCode();

            switch ((int)scoreType)
            {
                case 0:
                    score = new BaseCart(client, scoreType, StatusScore.Open, 0, 0);
                    break;
                case 1:
                    score = new GoldCart(client, scoreType, StatusScore.Open, 0, 0);
                    break;
                case 2:
                    score = new PlatinumCart(client, scoreType, StatusScore.Open, 0, 0);
                    break;
                default:
                    score = new BaseCart(client, scoreType, StatusScore.Open, 0, 0);
                    break;
            }

            score.Status = StatusScore.Open;

            this.scores.Create(score);

            return score.Id;
        }

        /// <summary>
        /// Closes the score.
        /// </summary>
        /// <param name="id">The id.</param>
        public void CloseScore(int id)
        {
            Score score = this.scores.SearchAndGetById(id);

            if (score.Status == StatusScore.Closed)
            {
                throw new ArgumentException("This account is already closed.", nameof(id));
            }

            score.Status = StatusScore.Closed;

            this.scores.Upgrade(score);
        }

        /// <summary>
        /// Gets all score.
        /// </summary>
        /// <returns>All score.</returns>
        public List<Score> ScoreGetAll()
        {
            return this.scores.ScoreGetAll();
        }

        /// <summary>
        /// Gets info about score.
        /// </summary>
        /// <param name="id">The indentifier.</param>
        /// <returns>The string that represent score info.</returns>
        public string ShowInformation(int id)
        {
            Score score = this.scores.SearchAndGetById(id);

            return score.ToString();
        }

        /// <summary>
        /// TopUp the item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="item">The value.</param>
        public void TopUpAccount(int id, decimal item)
        {
            Score score = this.scores.SearchAndGetById(id);

            score.TopUpAccount(item);

            this.scores.Upgrade(score);
        }

        /// <summary>
        /// Debit the item.
        /// </summary>
        /// <param name="id">The Identifier.</param>
        /// <param name="item">The value.</param>
        public void DebitTheAccount(int id, decimal item)
        {
            Score score = this.scores.SearchAndGetById(id);

            score.DebitTheAccount(item);

            this.scores.Upgrade(score);
        }
    }
}
