using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Instance of Platinum Account.
    /// </summary>
    public class PlatinumCart : Score
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumCart"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="scoreType">The account type.</param>
        /// <param name="status">The status.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="bonus">The bonus.</param>
        public PlatinumCart(Client client, ScoreType scoreType, StatusScore status, decimal balance, int bonus)
            : base(client, scoreType, status, balance, bonus)
        {
            this.depositPrice = 10;
            this.balancePrice = this.depositPrice * 2;
            this.ScoreType = scoreType;
            this.Status = status;
            this.balance = balance;
            this.bonusPoints = bonus;
        }

        /// <summary>
        /// Determines whether a balance transaction is possible or not.
        /// </summary>
        /// <param name="item">The value.</param>
        /// <returns>True or false.</returns>
        protected override bool BalanceChecking(decimal item)
        {
            return item >= 0;
        }
    }
}
