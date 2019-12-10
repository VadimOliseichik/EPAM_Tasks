using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_Book_WithLog
{
    /// <summary>
    /// Interface ILogger for the use of various frameworks for logging.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// The most detailed information about what is happening with the target code section, in steps.
        /// </summary>
        /// <param name="message">Message arrived.</param>
        void Trace(string message);

        /// <summary>
        /// Information for debugging.
        /// </summary>
        /// <param name="message">Message arrived.</param>
        void Debug(string message);

        /// <summary>
        /// More general informational messages about the current operation of the application,
        /// what happens to the system in the process of its use.
        /// </summary>
        /// <param name="message">Message arrived.</param>
        void Info(string message);

        /// <summary>
        /// Messages about strange or suspicious operation of the application.
        /// This is not a serious mistake, but you should pay attention to this behavior of the system.
        /// </summary>
        /// <param name="message">Message arrived.</param>
        void Warn(string message);

        /// <summary>
        /// Application error messages.
        /// </summary>
        /// <param name="message">Message arrived.</param>
        void Error(string message);

        /// <summary>
        /// Messages about very serious system errors.
        /// </summary>
        /// <param name="message">Message arrived.</param>
        void Fatal(string message);
    }
}
