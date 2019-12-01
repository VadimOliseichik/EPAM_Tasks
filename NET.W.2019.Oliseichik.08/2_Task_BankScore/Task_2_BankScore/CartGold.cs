using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_BankScore
{
    /// <summary>
    /// class CartGold
    /// Implements methods of adding and debiting money for a card Gold
    /// </summary>
    public class CartGold : Cart
    {
        /// <summary>
        /// The implementation of the method of adding money to the card Gold
        /// </summary>
        /// <param name="ammount"></param>
        /// <returns></returns>
        public override int AddCash(decimal ammount)
        {
            if (ammount <= this.MinAmount)
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase10);
            }
            else if (ammount <= this.BeetwenAmount && ammount > this.MinAmount)
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase20);
            }
            else
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase30);
            }
        }

        /// <summary>
        /// Implementation of a method of debiting money for a card Gold
        /// </summary>
        /// <param name="ammount"></param>
        /// <returns></returns>
        public override int UnaddCash(decimal ammount)
        {
            if (ammount <= this.MinAmount)
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase00);
            }
            else if (ammount > this.MinAmount && ammount <= this.BeetwenAmount)
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase10);
            }
            else
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase20);
            }
        }
    }
}
