using Serilog;
using Serilog.Events;
namespace PSerilog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogEventLevel minLevel;
#if DEBUG
            Console.WriteLine("DEBUG is defined");
            minLevel = LogEventLevel.Debug;
#else
            Console.WriteLine("No DEBUG is defined");
            minLevel = LogEventLevel.Error;
#endif
            // Create loggers Console and File. These loggers will be used globally.
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}",
                restrictedToMinimumLevel: minLevel)
            .WriteTo.File("logs/Logging.log",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}",
                restrictedToMinimumLevel: minLevel)
            .CreateLogger();

            Console.WriteLine("Hello!");

            Log.Information("Entering the application");

            var class1 = new Class1();
            class1.Method1();

            Log.Error("Some test error log");
        }
    }
}
