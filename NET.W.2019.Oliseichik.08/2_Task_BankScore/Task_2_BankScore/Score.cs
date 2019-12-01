using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace Task_2_BankScore
{
    /// <summary>
    /// Class Score with fields Number,First name,Last name,Bonus,Amount,KindOfCart
    /// and override method ToString of Object class
    /// </summary>
    public class Score
    {
        /// <summary>
        /// Field Number
        /// Cannot be empty
        /// Has a fixed size
        /// </summary>
        [Required]
        [StringLength(24, MinimumLength = 24)]
        public string Number { get; set; }

        /// <summary>
        /// Field First name
        /// Cannot be empty
        /// </summary>
        [Required]
        public string Firstname { get; set; }

        /// <summary>
        /// Field Last name
        /// Cannot be empty
        /// </summary>
        [Required]
        public string Lastname { get; set; }

        /// <summary>
        /// Field Bonus
        /// Cannot be empty
        /// </summary>
        [Required]
        public int Bonus { get; set; }

        /// <summary>
        /// Field Amount
        /// Cannot be empty
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Field KindOfCart
        /// Cannot be empty
        /// </summary>
        [Required]
        public string KindOfCart { get; set; }

        /// <summary>
        /// Override method ToString of Object class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Score #" + this.Number + ", " + this.Firstname + ", " + this.Lastname;
        }
    }
}
