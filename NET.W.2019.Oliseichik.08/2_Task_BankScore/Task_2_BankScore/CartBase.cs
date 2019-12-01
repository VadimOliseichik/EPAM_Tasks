using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_BankScore
{
    /// <summary>
    /// Class CartBase
    /// Implements methods of adding and debiting money for a card Base
    /// </summary>
    public class CartBase : Cart
    {
        /// <summary>
        /// The implementation of the method of adding money to the card Base
        /// </summary>
        /// <param name="ammount"></param>
        /// <returns></returns>
        public override int AddCash(decimal ammount)
        {
            if (ammount <= this.MinAmount)
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase00);
            }
            else if (ammount <= this.MaxAmount && ammount > this.MinAmount)
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase10);
            }
            else
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase20);
            }
        }

        /// <summary>
        /// Implementation of a method of debiting money for a card Base
        /// </summary>
        /// <param name="ammount"></param>
        /// <returns></returns>
        public override int UnaddCash(decimal ammount)
        {
            if (ammount < this.MinAmount)
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase00);
            }
            else
            {
                return Convert.ToInt32(ammount * this.PercentfThePurchase10);
            }
        }
    }
}
