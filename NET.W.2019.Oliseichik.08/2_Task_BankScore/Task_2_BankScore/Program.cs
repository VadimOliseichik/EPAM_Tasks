using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;

namespace Task_2_BankScore
{
    /// <summary>
    /// Main class Program
    /// </summary>
    public class Program
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
        private const int ExplanationHelpIndex = 2;

        /// <summary>
        /// An array of tuples in which a specific command corresponds to a specific method
        /// </summary>
        private static Tuple<string, Action<string>>[] commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("list", List),
            new Tuple<string, Action<string>>("create", Create),
            new Tuple<string, Action<string>>("close", Close),
            new Tuple<string, Action<string>>("use", Use),
            new Tuple<string, Action<string>>("help", PrintHelp),
            new Tuple<string, Action<string>>("exit", Exit),
        };

        /// <summary>
        /// For exit the application
        /// </summary>
        private static bool isRunning = true;

        /// <summary>
        /// ScoreListActions class object
        /// </summary>
        private static ScoreListActions score = new ScoreListActions();

        /// <summary>
        /// Array of help message arrays
        /// </summary>
        private static string[][] helpMessages = new string[][]
        {
            new string[] { "list", "prints the list screen", "The 'list' command prints the list screen." },
            new string[] { "close", "close score", "The 'close' command close score." },
            new string[] { "create", "create new score", "The 'create' command create new score. You can specify the type of cart(Base,Gold,Platinum)." },
            new string[] { "use", "use score", "The 'use' command use score." },
            new string[] { "help", "prints the help screen", "The 'help' command prints the help screen." },
            new string[] { "exit", "exits the application", "The 'exit' command exits the application." },
        };

        /// <summary>
        /// Point of entry
        /// The main method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t========Scores of bank========");
            Console.WriteLine(Program.HintMessage);
            Console.WriteLine();

            ReadFromFile();

            do
            {
                Console.Write("> ");
                var inputs = Console.ReadLine().Split(' ', 2);
                const int CommandIndex = 0;
                var command = inputs[CommandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(Program.HintMessage);
                    continue;
                }

                var index = Array.FindIndex(commands, 0, commands.Length, i => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    const int ParametersIndex = 1;
                    var parameters = inputs.Length > 1 ? inputs[ParametersIndex] : string.Empty;
                    commands[index].Item2(parameters);
                }
                else
                {
                    Console.WriteLine($"There is no '{command}' command.");
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
            while (isRunning);
        }

        /// <summary>
        /// Write To File method
        /// We write in binary
        /// </summary>
        public static void WriteInFile()
        {
            using BinaryWriter writer = new BinaryWriter(File.Open("H:\\epam\\BinaryFileTWO.txt", FileMode.Create));

            foreach (Score item in score.ScoreList)
            {
                writer.Write(item.Number);
                writer.Write(item.Firstname);
                writer.Write(item.Lastname);
                writer.Write(item.KindOfCart);
                writer.Write(item.Bonus);
                writer.Write(item.Amount);
            }
        }

        /// <summary>
        /// Read From File method
        /// Read from the binary file
        /// </summary>
        public static void ReadFromFile()
        {
            using (BinaryReader reader = new BinaryReader(File.Open("H:\\epam\\BinaryFileTWO.txt", FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    var item = new Score
                    {
                        Number = reader.ReadString(),
                        Firstname = reader.ReadString(),
                        Lastname = reader.ReadString(),
                        KindOfCart = reader.ReadString(),
                        Bonus = reader.ReadInt32(),
                        Amount = reader.ReadDecimal(),
                    };

                    score.ScoreList.Add(item);
                }
            }
        }

        /// <summary>
        /// Help command method
        /// Shows possible actions in the application.
        /// </summary>
        /// <param name="parameters"></param>
        private static void PrintHelp(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                var index = Array.FindIndex(helpMessages, 0, helpMessages.Length, i => string.Equals(i[Program.CommandHelpIndex], parameters, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    Console.WriteLine(helpMessages[index][Program.ExplanationHelpIndex]);
                }
                else
                {
                    Console.WriteLine($"There is no explanation for '{parameters}' command.");
                }
            }
            else
            {
                Console.WriteLine("Available commands:");

                foreach (var helpMessage in helpMessages)
                {
                    Console.WriteLine("\t{0}\t- {1}", helpMessage[Program.CommandHelpIndex], helpMessage[Program.DescriptionHelpIndex]);
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Exit command method
        /// Exit Application
        /// </summary>
        /// <param name="parameters"></param>
        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            isRunning = false;
        }

        /// <summary>
        /// Create command method
        /// Adds a new score.
        /// </summary>
        /// <param name="parameters"></param>
        private static void Create(string parameters)
        {
            parameters = Regex.Replace(parameters, "[ ]+", string.Empty).ToLower();

            string obj;
            switch (parameters) 
            {
                case "gold":
                    obj = "gold";
                    break;

                case "platinum":
                    obj = "platinum";
                    break;

                default:
                    obj = "base";
                    break;
            }

            var (numberScore, firstname, lastname) = Program.Input();

            string numberStr = Program.score.AddScore(numberScore, firstname, lastname, obj);

            WriteInFile();

            Console.WriteLine($"Score {numberStr} is created.");
        }

        /// <summary>
        /// Close command method
        /// Close the selected score.
        /// </summary>
        /// <param name="parameters"></param>
        private static void Close(string parameters) 
        {
            CultureInfo culture = new CultureInfo("en-US");

            parameters = Regex.Replace(parameters, "[ ]+", string.Empty).ToLower(culture);

            bool checkFindId = true;
            Array copyOfBookList = Program.score.GetScores();

            foreach (Score item in copyOfBookList)
            {
                if (item.Number.Equals(parameters.Trim()))
                {
                    if (Program.score.RemoveScore(item))
                    {
                        checkFindId = false;
                        WriteInFile();
                        Console.WriteLine($"Score {item.Number} is closed.");
                        break;
                    }
                }
            }

            if (checkFindId)
            {
                Console.WriteLine("Score is not found.");
            }
        }

        /// <summary>
        /// List command method
        /// Shows a list of scores.
        /// </summary>
        /// <param name="parameters"></param>
        private static void List(string parameters)
        {
            Array copyOfServiceList = Program.score.GetScores();
            foreach (Score item in copyOfServiceList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        /// <summary>
        /// Use of selected score
        /// </summary>
        /// <param name="parameters"></param>
        private static void Use(string parameters) 
        {
            CultureInfo culture = new CultureInfo("en-US");
            parameters = Regex.Replace(parameters, "[ ]+", string.Empty).ToLower(culture);

            bool chekFind = true;
            foreach (var item in Program.score.GetScores()) 
            {
                if (item.Number.Equals(parameters.Trim())) 
                {
                    ScoreService.MyMain(item);
                    chekFind = false;
                    break;
                }
            }

            if (chekFind) 
            {
                Console.WriteLine("Score is not found.");
            }

            WriteInFile();
        }

        /// <summary>
        /// Data Entry and Validation
        /// </summary>
        /// <returns></returns>
        private static (string, string, string) Input()
        {
            CultureInfo culture = new CultureInfo("en-US");

            string numberScore = null;
            Regex regularExpressionNumberScore = new Regex(@"^[\d]{5}[.][\d]{3}[.][\d]{1}[.][\d]{4}[.][\d]{7}$");
            do
            {
                Console.Write("Number of core(*****.***.*.****.*******): ");
                numberScore = Regex.Replace(Console.ReadLine(), "[ ]+", string.Empty);
            }
            while (!regularExpressionNumberScore.IsMatch(numberScore));

            string firstname = null;
            Regex regularExpressionNameAndSurname = new Regex(@"^[\w\s\W]{2,20}$");
            do
            {
                Console.Write("Name: ");
                firstname = Regex.Replace(Console.ReadLine(), "[ ]+", " ").Trim();
            }
            while (!regularExpressionNameAndSurname.IsMatch(firstname));

            string lastname = null;
            do
            {
                Console.Write("Surname: ");
                lastname = Regex.Replace(Console.ReadLine(), "[ ]+", " ").Trim();
            }
            while (!regularExpressionNameAndSurname.IsMatch(lastname));

            return (numberScore, firstname, lastname);
        }
    }
}
