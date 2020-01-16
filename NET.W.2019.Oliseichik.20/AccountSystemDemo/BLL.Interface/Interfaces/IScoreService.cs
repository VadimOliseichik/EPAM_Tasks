using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IScoreService
    {
        /// <summary>
        /// Opens the account.
        /// </summary>
        /// <param name="client">The user.</param>
        /// <param name="scoreType">The type of account.</param>
        /// <param name="id">The identifier.</param>
        void OpenScore(Client client, ScoreType scoreType, out int id);

        int OpenScore(Client client, ScoreType scoreType);

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void CloseScore(int id);

        /// <summary>
        /// Deposities the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        void TopUpAccount(int id, decimal value);

        /// <summary>
        /// Withdraws the value.
        /// </summary>
        /// <param name="id">The Identifier.</param>
        /// <param name="value">The value.</param>
        void DebitTheAccount(int id, decimal value);

        /// <summary>
        /// Gets info about score.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The string that represent score information.</returns>
        string ShowInformation(int id);

        List<Score> ScoreGetAll();
    }
}
