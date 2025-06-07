using NLog;

namespace PNLog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            LogLevel logLevel;
#if DEBUG
            logLevel = LogLevel.Debug;
#else
            logLevel= LogLevel.Info;
#endif

            NLog.LogManager.Setup().LoadConfiguration(builder =>
            {
                builder.ForLogger().FilterMinLevel(logLevel).WriteToConsole();
                builder.ForLogger().FilterMinLevel(logLevel).WriteToFile(fileName: "logs/pnlog.log");
            });

            NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

            _logger.Info("Info log");

            var class1 = new Class1();
            class1.Method1();
        }
    }
}
