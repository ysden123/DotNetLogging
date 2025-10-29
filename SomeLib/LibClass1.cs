using Serilog;

namespace SomeLib
{
    public class LibClass1
    {
        private static readonly ILogger _logger = Log.ForContext<LibClass1>();

        public static void Method1()
        {
            _logger.Information("SomeLib.Class1.Method1 called.");
        }
    }
}
