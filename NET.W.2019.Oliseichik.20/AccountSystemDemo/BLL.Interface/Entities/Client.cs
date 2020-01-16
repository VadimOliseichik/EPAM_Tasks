using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Instance of a user.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last naem.</param>
        public Client(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; set; }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        /// <value>
        /// First name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        /// <value>
        /// Last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Return a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return (this.FirstName + this.LastName).GetHashCode();
        }

        /// <summary>
        /// Returns <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
