using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Instance of bank account.
    /// </summary>
    public abstract class Score
    {
        protected int balancePrice;
        protected int depositPrice;

        /// <summary>
        /// Initializes a new instance of the <see cref="Score"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="scoreType">The score type.</param>
        /// <param name="status">The status.</param>
        /// <param name="balance">The balance.</param>
        /// <param name="bonus">The bonus.</param>
        protected Score(Client client, ScoreType scoreType, StatusScore status, decimal balance, int bonus)
        {
            this.client = client;
            this.ScoreType = scoreType;
            this.Status = status;
            this.balance = balance;
            this.bonusPoints = bonus;
        }

        /// <summary>
        /// Gets or sets bonus points.
        /// </summary>
        /// <value>
        /// Bonus points.
        /// </value>
        public int bonusPoints { get; set; }

        /// <summary>
        /// Gets or sets client.
        /// </summary>
        /// <value>
        /// Client.
        /// </value>
        public Client client { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets balance.
        /// </summary>
        /// <value>
        /// Balance.
        /// </value>
        public decimal balance { get; set; }

        /// <summary>
        /// Gets or sets ot sets the status.
        /// </summary>
        /// <value>
        /// Ot sets the status.
        /// </value>
        public StatusScore Status { get; set; }

        /// <summary>
        /// Gets or sets score type.
        /// </summary>
        /// <value>
        /// Account type.
        /// </value>
        public ScoreType ScoreType { get; set; }

        /// <summary>
        /// Deposite balance with value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void TopUpAccount(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("You cannot deposite your balance with a value equal to zero or less.", nameof(value));
            }

            this.bonusPoints += this.CountBonusPoints(value);
            this.balance += value;
        }

        /// <summary>
        /// Witdraw balance with value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void DebitTheAccount(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("You can't withdraw with a value equal to zero or less.", nameof(value));
            }

            if (!this.BalanceChecking(this.balance - value))
            {
                throw new InvalidOperationException($"You can't withdraw {value}, because your actual balanc is {this.balance}");
            }

            this.bonusPoints -= this.CountBonusPoints(value);
            this.balance -= value;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return this.Id.ToString() + " " + this.Status.ToString() + " " + this.client.ToString() + " " + this.balance.ToString() + " " + bonusPoints.ToString();
        }

        /// <summary>
        /// Counts the bonus.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Count of bonus.</returns>
        protected int CountBonusPoints(decimal value)
        {
            return (int)(this.balance * (1 / (decimal)this.balancePrice) + value * (1 / (decimal)this.depositPrice));
        }

        /// <summary>
        /// Determines whether a balance transaction is possible or not.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True or false.</returns>
        protected abstract bool BalanceChecking(decimal value);
    }
}
