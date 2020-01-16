using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class DTO_Score
    {
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
    }
}
