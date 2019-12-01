using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_BankScore
{
    /// <summary>
    /// Class CartPlatinum
    /// Implements methods of adding and debiting money for a card Platinum
    /// </summary>
    public class CartPlatinum : Cart
    {
        /// <summary>
        /// The implementation of the method of adding money to the card Platinum
        /// </summary>
        /// <param name="ammount"></param>
        /// <returns></returns>
        public override int AddCash(decimal ammount)
        {
            if (ammount <= this.MinAmount)
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase20);
            }
            else if (ammount <= this.BeetwenAmount && ammount > this.MinAmount)
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase30);
            }
            else if (ammount <= this.MaxAmount && ammount > this.BeetwenAmount)
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase40);
            }
            else
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase50);
            }
        }

        /// <summary>
        /// Implementation of a method of debiting money for a card Platinum
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
                return Convert.ToInt32(ammount * this.PercentfThePurchase20);
            }
            else if (ammount > this.BeetwenAmount && ammount <= this.MaxAmount)
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase30);
            }
            else
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase30);
            }
        }
    }
}
