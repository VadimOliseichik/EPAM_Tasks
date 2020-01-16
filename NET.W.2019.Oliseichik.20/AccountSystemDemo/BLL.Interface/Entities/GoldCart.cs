using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Instacne of Gold Account.
    /// </summary>
    public class GoldCart : Score
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoldCart"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="scoreType">The account type.</param>
        /// <param name="status">The status.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="bonus">The bonus.</param>
        public GoldCart(Client client, ScoreType scoreType, StatusScore status, decimal balance, int bonus)
            : base(client, scoreType, status, balance, bonus)
        {
            this.balance = balance;
            this.ScoreType = scoreType;
            this.depositPrice = 100;
            this.Status = status;
            this.balancePrice = this.depositPrice * 2;
            this.bonusPoints = bonus;
        }

        /// <summary>
        /// Determines whether a balance transaction is possible or not.
        /// </summary>
        /// <param name="item">The value/</param>
        /// <returns>True or false.</returns>
        protected override bool BalanceChecking(decimal item)
        {
            return item >= 0;
        }
    }
}
