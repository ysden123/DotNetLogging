using Serilog;

namespace PSerilogWOInit
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
            _logger = Log.ForContext<Class1>();
            Console.WriteLine($"_logger: {_logger}");
        }

        public void Method1()
        {
            _logger.Information("==>Class1.Method1");
            _logger.Debug("Some debug output: {Val}", 123);
        }
    }
}
