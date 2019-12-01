using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task_2_BankScore
{
    /// <summary>
    /// Abstract class Cart
    /// </summary>
    public abstract class Cart
    {
        /// <summary>
        /// Variables for setting bonus conditions
        /// </summary>
        internal readonly decimal PercentfThePurchase50 = 0.5M;
        internal readonly decimal PercentfThePurchase40 = 0.4M;
        internal readonly decimal PercentfThePurchase30 = 0.3M;
        internal readonly decimal PercentfThePurchase20 = 0.2M;
        internal readonly decimal PercentfThePurchase10 = 0.1M;
        internal readonly decimal PercentfThePurchase00 = 0.0M;
        internal readonly decimal MinAmount = 100;
        internal readonly decimal BeetwenAmount = 500;
        internal readonly decimal MaxAmount = 1000;

        /// <summary>
        /// Method of adding money
        /// </summary>
        /// <param name="ammount"></param>
        /// <returns></returns>
        public abstract int AddCash(decimal ammount);

        /// <summary>
        /// Money reading method
        /// </summary>
        /// <param name="ammount"></param>
        /// <returns></returns>
        public abstract int UnaddCash(decimal ammount);
    }
}
