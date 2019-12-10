﻿using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Task_1_Book_WithLog
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
        /// For exit the application
        /// </summary>
        private static bool isRunning = true;

        /// <summary>
        /// Logger.
        /// </summary>
        private static readonly ILogger logger = new NLogger();

        /// <summary>
        /// BookListService class object
        /// </summary>
        private static BookListService bookListService = new BookListService();

        /// <summary>
        /// Array of help message arrays
        /// </summary>
        private static string[][] helpMessages = new string[][]
        {
            new string[] { "find", "find user", "The 'find' command find book and print them on the screen." },
            new string[] { "list", "prints the list screen", "The 'list' command prints the list screen." },
            new string[] { "sort", "prints the sort list screen", "The 'sort' command prints them sort list screen." },
            new string[] { "delete", "delete book", "The 'delete' command delete book." },
            new string[] { "create", "create new book", "The 'create' command create new book." },
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
            logger.Info("Начинаем запуск приложения");
            Console.WriteLine("===========Book application===========");
            Console.WriteLine(Program.HintMessage);
            Console.WriteLine();

            ReadFromFile();

            do
            {
                Console.Write("> ");
                var inputs = Regex.Replace(Console.ReadLine(), "[ ]+", " ").Trim().Split(' ', 2);
                var command = inputs[0].ToLower();

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(Program.HintMessage);
                    continue;
                }

                var parameters = inputs.Length > 1 ? inputs[1] : string.Empty;

                switch (command)
                {
                    case "help":
                        PrintHelp(parameters);
                        break;

                    case "exit":
                        Exit(parameters);
                        break;

                    case "list":
                        List(parameters);
                        break;

                    case "create":
                        Create(parameters);
                        WriteToFile();
                        break;

                    case "delete":
                        Delete(parameters);
                        WriteToFile();
                        break;

                    case "find":
                        FindBookByTag(parameters);
                        break;

                    case "sort":
                        SortBooksByTag(parameters);
                        WriteToFile();
                        break;

                    default:
                        Console.WriteLine($"There is no '{command}' command.");
                        Console.WriteLine();
                        break;
                }

            }
            while (isRunning);
        }

        /// <summary>
        /// Read From File method
        /// Read from the binary file
        /// </summary>
        private static void ReadFromFile()
        {
            logger.Debug("Открываем файл для считывания данных.");
            using (BinaryReader reader = new BinaryReader(File.Open("H:\\epam\\BinaryFile.txt", FileMode.Open)))
            {
                logger.Trace("Файл для считывания данных успешно открыт.");
                while (reader.PeekChar() > -1)
                {
                    var item = new Book
                    {
                        Id = reader.ReadInt32(),
                        ISBN = reader.ReadString(),
                        Author = reader.ReadString(),
                        Title = reader.ReadString(),
                        PublishingHouse = reader.ReadString(),
                        TheYearOfPublishing = reader.ReadInt32(),
                        NumberOfPages = reader.ReadInt32(),
                        Price = reader.ReadDecimal(),
                    };

                    bookListService.ListBooks.Add(item);
                }
                logger.Debug("Данные считаны из файла успешно.");
            }
        }

        /// <summary>
        /// Write To File method
        /// We write in binary
        /// </summary>
        private static void WriteToFile()
        {
            logger.Debug("Открываем файл для записи данных.");
            using BinaryWriter writer = new BinaryWriter(File.Open("H:\\epam\\BinaryFile.txt", FileMode.Create));
            logger.Trace("Файл для записи данных успешно открыт.");

            foreach (Book item in bookListService.ListBooks)
            {
                writer.Write(item.Id);
                writer.Write(item.ISBN);
                writer.Write(item.Author);
                writer.Write(item.Title);
                writer.Write(item.PublishingHouse);
                writer.Write(item.TheYearOfPublishing);
                writer.Write(item.NumberOfPages);
                writer.Write(item.Price);
            }

            logger.Debug("Данные записаны из файла успешно.");
        }

        /// <summary>
        /// Help command method
        /// Shows possible actions in the application.
        /// </summary>
        /// <param name="parameters"></param>
        private static void PrintHelp(string parameters)
        {
            logger.Info("Печатаем help list для пользователя.");
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
            logger.Info("Завершаем работу приложения.");
            Console.WriteLine("Exiting an application...");
            isRunning = false;
        }

        /// <summary>
        /// Create command method
        /// Adds a new book.
        /// </summary>
        /// <param name="parameters"></param>
        private static void Create(string parameters)
        {
            logger.Info("Создаём новую книгу.");
            logger.Debug("Ввод данных книги.");
            var (isbn, author, title, publishingHouse, theYearOfPublishing, numberOfPages, price) = Program.Input();
            logger.Trace("Ввод данных прошёл успешно успешно.");

            logger.Debug("Добавление данных книги.");
            int personId = Program.bookListService.AddBook(isbn, author, title, publishingHouse, theYearOfPublishing, numberOfPages, price);
            logger.Trace("Добавление книги прошло успешно.");

            Console.WriteLine($"Book #{personId} is created.");
        }

        /// <summary>
        /// Sort command method
        /// Sorts the list by the given parameter
        /// </summary>
        /// <param name="parameters"></param>
        private static void SortBooksByTag(string parameters)
        {
            logger.Info("Сортируем по заданному Tag.");
            CultureInfo culture = new CultureInfo("en-US");
            parameters = Regex.Replace(parameters, "[ ]+", string.Empty).Trim().ToLower(culture);

            switch (parameters)
            {
                case "number":
                    logger.Trace("Сортируем список книг по Number.");
                    bookListService.SortBooksByItem(new SortByNumber());
                    logger.Trace("Сортировка списока книг по Number прошла успешно.");
                    break;

                case "author":
                    logger.Trace("Сортируем список книг по Author.");
                    bookListService.SortBooksByItem(new SortByAuthor());
                    logger.Trace("Сортировка списока книг по Author прошла успешно.");
                    break;

                case "title":
                    logger.Trace("Сортируем список книг по Title.");
                    bookListService.SortBooksByItem(new SortByTitle());
                    logger.Trace("Сортировка списока книг по Title прошла успешно.");
                    break;

                case "year":
                    logger.Trace("Сортируем список книг по Year.");
                    bookListService.SortBooksByItem(new SortByYear());
                    logger.Trace("Сортировка списока книг по Year прошла успешно.");
                    break;

                case "price":
                    logger.Trace("Сортируем список книг по Price.");
                    bookListService.SortBooksByItem(new SortByPrice());
                    logger.Trace("Сортировка списока книг по Price прошла успешно.");
                    break;

                default:
                    logger.Debug("Введён неверный Tag для сортировки списка книг.");
                    Console.WriteLine($"There is no {parameters} criterion");
                    break;
            }
        }

        /// <summary>
        /// Delete command method
        /// Deletes the selected book.
        /// </summary>
        /// <param name="parameters"></param>
        private static void Delete(string parameters)
        {
            logger.Info("Удаляем книгу.");
            parameters = Regex.Replace(parameters, "[ ]+", string.Empty);
            bool checkFindId = true;
            Array copyOfBookList = Program.bookListService.GetBooks();
            CultureInfo culture = new CultureInfo("en-US");

            foreach (Book item in copyOfBookList)
            {
                if (string.Equals(item.Id.ToString(culture), parameters, StringComparison.Ordinal))
                {
                    if (Program.bookListService.RemoveBook(item))
                    {
                        checkFindId = false;
                        logger.Trace("Книга успешно удалена.");
                        Console.WriteLine($"Book #{item.Id} is deleted.");
                    }

                }
            }

            if (checkFindId)
            {
                logger.Error("Удаляемая книга не найдена.");
                throw new Exception("Book is not found.");
            }
        }

        /// <summary>
        /// List command method
        /// Shows a list of books.
        /// </summary>
        /// <param name="parameters"></param>
        private static void List(string parameters)
        {
            logger.Info("Выводим список книг.");
            string format = InputFormat();
            Array copyOfServiceList = Program.bookListService.GetBooks();
            foreach (Book item in copyOfServiceList)
            {
                Console.WriteLine(item.ToString(format));
            }
        }

        private static string InputFormat()
        {
            logger.Info("Вводим формат вывода информации.");
            Console.WriteLine("Enter the book information output format.");
            Console.Write("Format(field-field-field): ");
            string format = Regex.Replace(Console.ReadLine(), "[ ]+", string.Empty);
            return format;

        }

        /// <summary>
        /// Find command method
        /// Looking for books by a given parameter
        /// </summary>
        /// <param name="parameters"></param>
        private static void FindBookByTag(string parameters)
        {
            logger.Info("Ищем по заданному Tag.");
            CultureInfo culture = new CultureInfo("en-US");
            parameters = Regex.Replace(parameters, "[ ]+", " ").Trim().ToLower(culture);

            int firstSpace = parameters.IndexOf(' ', StringComparison.Ordinal);
            int firstQuotes = parameters.IndexOf('"', StringComparison.Ordinal);
            int lastQuotes = parameters.LastIndexOf('"');

            string paramSearch = firstSpace > -1 ? parameters.Substring(0, firstSpace) : string.Empty;
            string paramBetweenQuotes = string.Empty;

            if (firstSpace + 1 == firstQuotes && firstQuotes < lastQuotes)
            {
                InQuotes(in firstQuotes, in lastQuotes, parameters, out paramBetweenQuotes);
            }

            List<Book> listFindBook = new List<Book>();

            switch (paramSearch)
            {
                case "isbn":
                    logger.Trace("Ищем книгу по ISBN.");
                    listFindBook = bookListService.FindByISBN(paramBetweenQuotes.Trim());
                    break;

                case "author":
                    logger.Trace("Ищем книгу по Author.");
                    listFindBook = bookListService.FindByAuthor(paramBetweenQuotes.Trim());
                    break;

                case "title":
                    logger.Trace("Ищем книгу по Title.");
                    listFindBook = bookListService.FindByTitle(paramBetweenQuotes.Trim());
                    break;

                case "publishinghouse":
                    logger.Trace("Ищем книгу по House.");
                    listFindBook = bookListService.FindByPublishingHouse(paramBetweenQuotes.Trim());
                    break;

                case "theyearofpublishing":
                    logger.Trace("Ищем книгу по YearOfPublishing.");
                    listFindBook = bookListService.FindByTheYearOfPublishing(paramBetweenQuotes.Trim());
                    break;

                case "numberofpages":
                    logger.Trace("Ищем книгу по NumberOfPages.");
                    listFindBook = bookListService.FindByNumberOfPages(paramBetweenQuotes.Trim());
                    break;

                case "price":
                    logger.Trace("Ищем книгу по Price.");
                    listFindBook = bookListService.FindByPrice(paramBetweenQuotes.Trim());
                    break;

                default:
                    logger.Warn("Введён неверный Tag для сортировки списка книг.");
                    Console.WriteLine("This field in not found!");
                    break;
            }

            if (listFindBook.Count != 0)
            {
                foreach (Book item in listFindBook)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        /// <summary>
        /// We get the parameter to search
        /// </summary>
        /// <param name="firstQuotes"></param>
        /// <param name="lastQuotes"></param>
        /// <param name="parameters"></param>
        /// <param name="paramBetweenQuotes"></param>
        private static void InQuotes(in int firstQuotes, in int lastQuotes, string parameters, out string paramBetweenQuotes)
        {
            paramBetweenQuotes = string.Empty;
            for (int i = firstQuotes + 1; i < lastQuotes; i++)
            {
                paramBetweenQuotes += parameters[i];
            }
        }

        /// <summary>
        /// Data Entry and Validation
        /// </summary>
        /// <returns></returns>
        private static (string, string, string, string, int, int, decimal) Input()
        {
            CultureInfo culture = new CultureInfo("en-US");
            bool checkInput = false;
            string isbn = null;
            logger.Trace("Ввод ISBN.");
            Regex regularExpressionISBN = new Regex(@"^[\d]{3}[-][\d]{1}[-][\d]{4}[-][\d]{4}[-][\d]{1}$");
            do
            {
                Console.Write("ISBN of book(***-*-****-****-*): ");
                isbn = Regex.Replace(Console.ReadLine(), "[ ]+", " ").Trim();
            }
            while (!regularExpressionISBN.IsMatch(isbn));
            logger.Trace("Ввод ISBN прошёл успешно.");

            string author = null;
            logger.Trace("Ввод author.");
            Regex regularExpressionAuthorAndTitle = new Regex(@"^[\w\s\W]{2,60}$");
            do
            {
                Console.Write("Author of book: ");
                author = Regex.Replace(Console.ReadLine(), "[ ]+", " ").Trim();
            }
            while (!regularExpressionAuthorAndTitle.IsMatch(author));
            logger.Trace("Ввод author прошёл успешно.");

            string title = null;
            logger.Trace("Ввод title.");
            do
            {
                Console.Write("Title of book: ");
                title = Regex.Replace(Console.ReadLine(), "[ ]+", " ").Trim();
            }
            while (!regularExpressionAuthorAndTitle.IsMatch(title));
            logger.Trace("Ввод title прошёл успешно.");

            string publishingHouse = null;
            logger.Trace("Ввод publishing house.");
            Regex regularExpressionPublishingHouse = new Regex(@"^[\w\s\W]{2,90}$");
            do
            {
                Console.Write("Publishing house of book: ");
                publishingHouse = Regex.Replace(Console.ReadLine(), "[ ]+", " ").Trim();
            }
            while (!regularExpressionPublishingHouse.IsMatch(publishingHouse));
            logger.Trace("Ввод publishing house прошёл успешно.");

            int theYearOfPublishing = 0;
            logger.Trace("Ввод year of publishing.");
            do
            {
                Console.Write("The year of publishing: ");
                string theYearOfPublishingString = Regex.Replace(Console.ReadLine(), "[ ]+", string.Empty);
                checkInput = false;
                try
                {
                    theYearOfPublishing = Convert.ToInt32(theYearOfPublishingString, culture);
                    if (theYearOfPublishing < 1 || theYearOfPublishing > DateTime.Now.Year)
                    {
                        theYearOfPublishing = 0;
                        checkInput = true;
                    }
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
            while (checkInput);
            logger.Trace("Ввод year of publishing прошёл успешно.");

            int numberOfPages = 0;
            logger.Trace("Ввод number of pages.");
            do
            {
                Console.Write("Number of pages: ");
                string numberOfPagesString = Regex.Replace(Console.ReadLine(), "[ ]+", string.Empty);
                checkInput = false;
                try
                {
                    numberOfPages = Convert.ToInt32(numberOfPagesString, culture);
                    if (numberOfPages < 1 || numberOfPages > 50000)
                    {
                        numberOfPages = 0;
                        checkInput = true;
                    }
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
            while (checkInput);
            logger.Trace("Ввод number of pages прошёл успешно.");

            decimal price = 0.0M;
            logger.Trace("Ввод salary.");
            Regex regularExpressionSalary = new Regex(@"^[\d]{1,}[.][\d]{1,}$");
            do
            {
                Console.Write("Price (00.00)$: ");
                string priceString = Regex.Replace(Console.ReadLine(), "[ ]+", string.Empty);
                checkInput = false;
                if (regularExpressionSalary.IsMatch(priceString))
                {
                    try
                    {
                        price = Convert.ToDecimal(priceString, culture);
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
            logger.Trace("Ввод salary прошёл успешно.");

            return (isbn, author, title, publishingHouse, theYearOfPublishing, numberOfPages, price);
        }
    }
}
