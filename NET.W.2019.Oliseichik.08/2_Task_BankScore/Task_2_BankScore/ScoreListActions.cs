using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Task_2_BankScore
{
    /// <summary>
    /// Class of service list Score
    /// </summary>
    public class ScoreListActions
    {
        /// <summary>
        /// Score books
        /// </summary>
        public readonly List<Score> ScoreList = new List<Score>();

        /// <summary>
        /// Add score method 
        /// Score in list of scores
        /// </summary>
        /// <param name="numberScore"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="cartKind"></param>
        /// <returns></returns>
        public string AddScore(string numberScore, string firstname, string lastname, string cartKind)
        {
            var scoreBank = new Score
            {
                Number = numberScore,
                Firstname = firstname,
                Lastname = lastname,
                Bonus = 0,
                Amount = 0,
                KindOfCart = cartKind,
            };

            ShowException(scoreBank);

            ScoreCheckAvailability(scoreBank);

            ScoreList.Add(scoreBank);

            return scoreBank.Number;
        }

        /// <summary>
        /// Remove score method
        /// Score delete from list of scores
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool RemoveScore(Score item) 
        {
            return ScoreList.Remove(item);
        }

        /// <summary>
        /// Get array of Scores
        /// </summary>
        /// <returns></returns>
        public Score[] GetScores()
        {
            return ScoreList.ToArray();
        }

        /// <summary>
        /// Score Check Availability by number
        /// </summary>
        /// <param name="scores"></param>
        private void ScoreCheckAvailability(Score scores)
        {
            foreach (var item in ScoreList)
            {
                if (scores.Number.Equals(item.Number))
                {
                    throw new Exception("Such a book already exists.");
                }
            }
        }

        /// <summary>
        /// Show Exception after adding a score
        /// </summary>
        /// <param name="item"></param>
        private void ShowException(Score item)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(item);
            if (!Validator.TryValidateObject(item, context, results, true))
            {
                throw new ArgumentException("You entered incorrect data.");
            }
        }
    }
}
