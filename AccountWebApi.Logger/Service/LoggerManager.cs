using AccountWebApi.Logger.Contract;
using NLog;

namespace AccountWebApi.Logger.Service
{
    /// <summary>
    /// This class defines the logging operations.
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Constructor for LoggerManager.
        /// </summary>
        public LoggerManager()
        {
        }

        /// <summary>
        /// Method to write debug logs.
        /// </summary>
        /// <param name="message">Requires a string argument.</param>
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Method to write error logs.
        /// </summary>
        /// <param name="message">Requires a string argument.</param>
        public void LogError(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Method to write Info logs.
        /// </summary>
        /// <param name="message">Requires a string argument.</param>
        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Method to write warning logs.
        /// </summary>
        /// <param name="message">Requires a string argument.</param>
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
