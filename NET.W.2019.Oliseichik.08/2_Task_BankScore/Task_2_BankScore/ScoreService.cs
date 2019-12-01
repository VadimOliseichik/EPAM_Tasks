using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_2_BankScore
{
    /// <summary>
    /// Class of service Score
    /// </summary>
    public class ScoreService
    {
        /// <summary>
        /// Hint message
        /// </summary>
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";

        /// <summary>
        /// Command Help Index
        /// </summary>
        private const int CommandHelpIndex = 0;

        /// <summary>
        /// Description Help Index
        /// </summary>
        private const int DescriptionHelpIndex = 1;

        /// <summary>
        /// Culture
        /// </summary>
        private static CultureInfo culture = new CultureInfo("en-US");

        private static Cart cartochka;

        /// <summary>
        /// An array of tuples in which a specific command corresponds to a specific method
        /// </summary>
        private static Tuple<string, Action<Score>>[] commands = new Tuple<string, Action<Score>>[]
        {
            new Tuple<string, Action<Score>>("show", Show),
            new Tuple<string, Action<Score>>("help", PrintHelp),
            new Tuple<string, Action<Score>>("topup", TopUpAccount),
            new Tuple<string, Action<Score>>("debit", DebitTheAccount),
            new Tuple<string, Action<Score>>("exit", ExitFromScore),
        };

        /// <summary>
        /// For exit the score
        /// </summary>
        private static bool isRunningScore = true;

        /// <summary>
        /// Array of help message arrays
        /// </summary>
        private static string[][] helpMessages = new string[][]
        {
            new string[] { "show", "prints the score screen", "The 'show' command prints the score screen." },
            new string[] { "help", "prints the help screen", "The 'help' command prints the help screen." },
            new string[] { "topup", "increases the score", "The 'help' command increases the score." },
            new string[] { "debit", "reduces the score", "The 'help' command reduces the score." },
            new string[] { "exit", "exits the application", "The 'exit' command exits the application." },
        };

        /// <summary>
        /// The entry point for working with the selected score
        /// </summary>
        /// <param name="bankScore"></param>
        public static void MyMain(Score bankScore) 
        {
            Console.WriteLine($"\n\n\t\t\t\t\tHello, {bankScore.Firstname} {bankScore.Lastname}");
            Console.WriteLine($"\t\t\t\tYou use score {bankScore.Number}");
            Console.WriteLine(ScoreService.HintMessage);

            switch (bankScore.KindOfCart)
            {
                case "gold":
                    cartochka = new CartGold();
                    break;

                case "platinum":
                    cartochka = new CartPlatinum();
                    break;

                default:
                    cartochka = new CartBase();
                    break;
            }

            do
            {
                Console.Write("\n> ");
                var inputs = Console.ReadLine().Split(' ', 1);
                const int CommandIndex = 0;
                var command = inputs[CommandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(ScoreService.HintMessage);
                    continue;
                }

                var index = Array.FindIndex(commands, 0, commands.Length, i => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    commands[index].Item2(bankScore);
                }
                else
                {
                    Console.WriteLine($"There is no '{command}' command.");
                    Console.WriteLine();
                }
            }
            while (isRunningScore);
        }

        /// <summary>
        /// Help command method
        /// Shows possible actions in the score.
        /// </summary>
        /// <param name="sc"></param>
        private static void PrintHelp(Score sc)
        {
            Console.WriteLine("Available commands:");

            foreach (var helpMessage in helpMessages)
            {
                Console.WriteLine("\t{0}\t- {1}", helpMessage[ScoreService.CommandHelpIndex], helpMessage[ScoreService.DescriptionHelpIndex]);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Adding money and bonuses to the score
        /// </summary>
        /// <param name="sc"></param>
        private static void TopUpAccount(Score sc) 
        {
            decimal amount = Enter();
            sc.Amount += amount;
            sc.Bonus += cartochka.AddCash(amount);
            Program.WriteInFile();
            Console.WriteLine("The operation was successful.");
        }

        /// <summary>
        /// Write off money and bonuses to the score
        /// </summary>
        /// <param name="sc"></param>
        private static void DebitTheAccount(Score sc) 
        {
            decimal amount = Enter();
            if (amount < sc.Amount)
            {
                sc.Amount -= amount;
                sc.Bonus -= cartochka.UnaddCash(amount);
                if (sc.Bonus < 0) 
                {
                    sc.Bonus = 0; 
                }

                Program.WriteInFile();

                Console.WriteLine("The operation was successful.");
            }
            else 
            {
                Console.WriteLine("Insufficient funds.");
            }
        }

        /// <summary>
        /// Exit from a specific score
        /// </summary>
        /// <param name="sc"></param>
        private static void ExitFromScore(Score sc)
        {
            Console.WriteLine("Exiting from score.");
            isRunningScore = false;
        }

        /// <summary>
        /// Show score information
        /// </summary>
        /// <param name="sc"></param>
        private static void Show(Score sc) 
        {
            Console.WriteLine($"{sc.ToString()}:\n\tKind of cart - {sc.KindOfCart}\n\tAmount = {sc.Amount.ToString("00.00$", culture)}\n\tBonus = {sc.Bonus}");
        }

        /// <summary>
        /// Amount Entry and Validation
        /// </summary>
        /// <returns></returns>
        private static decimal Enter() 
        {
            decimal amount = 0.0M;
            bool checkInput = false;
            Regex regularExpressionSalary = new Regex(@"^[\d]{1,}[.][\d]{1,}$");
            do
            {
                Console.Write("Amount (00.00)$: ");
                string salaryString = Regex.Replace(Console.ReadLine(), "[ ]+", string.Empty);
                checkInput = false;
                if (regularExpressionSalary.IsMatch(salaryString))
                {
                    try
                    {
                        amount = Convert.ToDecimal(salaryString, culture);
                    }
                    catch (OverflowException)
                    {
                        checkInput = true;
                    }
                    catch (FormatException)
                    {
                        checkInput = true;
                    }
                }
                else
                {
                    checkInput = true;
                }
            }
            while (checkInput);

            return amount;
        }
    }
}
