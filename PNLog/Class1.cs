using NLog;

namespace PNLog
{
    internal class Class1
    {
        /// <summary>
        /// The logger for the class.
        /// </summary>
        private readonly ILogger _logger;

        public Class1()
        {
            // Create a logger for a specific class.
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public void Method1()
        {
            _logger.Info("==>Class1.Method1");
            _logger.Debug("Some debug output: {Val}", 123);
            _logger.Info("Some debug output: {Val}", 123);
        }
    }
}
