using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_Book_WithLog
{
    /// <summary>
    /// Framework NLog.
    /// </summary>
    public class NLogger : ILogger
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Message level.
        /// </summary>
        /// <param name="message"></param>
        public void Trace(string message) => logger.Trace(message);

        /// <summary>
        /// Message level.
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message) => logger.Debug(message);

        /// <summary>
        /// Message level.
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message) => logger.Info(message);

        /// <summary>
        /// Message level.
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message) => logger.Warn(message);

        /// <summary>
        /// Message level.
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message) => logger.Error(message);

        /// <summary>
        /// Message level.
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(string message) => logger.Fatal(message);
    }
}
