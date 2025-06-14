using Serilog;
namespace PSerilog
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .Enrich.WithThreadId()
               //.Enrich.With(new ThreadIdEnricher())
               .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} [{ThreadId}] {Message:lj}{NewLine}{Exception}")
               .WriteTo.File("logs/PSerilog.log",
               rollingInterval: RollingInterval.Day,
               outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} [{ThreadId}] {Message:lj}{NewLine}{Exception}")
           .CreateLogger();
#else
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Error()
               .Enrich.WithThreadId()
               //.Enrich.With(new ThreadIdEnricher())
               .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} [{ThreadId}] {Message:lj}{NewLine}{Exception}")
               .WriteTo.File("logs/PSerilog.log",
               rollingInterval: RollingInterval.Day,
               outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} [{ThreadId}] {Message:lj}{NewLine}{Exception}")
           .CreateLogger();
#endif
            Console.WriteLine("Hello!");

            Log.Information("Entering the application");

            var class1 = new Class1();
            class1.Method1();

            Log.Error("Some test error log");
        }
    }
}
