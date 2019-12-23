using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class GenerateScoreId : IGenerateScoreIdService
    {
        /// <summary>
        /// Generates score id.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A <see cref="System.String"/> that used as id.</returns>
        public string ScoreIdGenerate(string key)
        {
            return Math.Abs(key.GetHashCode()).ToString();
        }
    }
}
