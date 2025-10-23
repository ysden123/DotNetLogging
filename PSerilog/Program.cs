using Serilog;
using System.Reflection;
namespace PSerilog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName= "logs/app.log";
            Assembly? assembly = Assembly.GetExecutingAssembly();
            if (assembly != null)
            {
                string? assemblyName = assembly.GetName().Name;
                if (assemblyName != null)
                {
                    var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), assemblyName);
                    fileName = Path.Combine(folder, "logs", "app.log");
                }
            }
#if DEBUG
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .Enrich.WithThreadId()
               //.Enrich.With(new ThreadIdEnricher())
               .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} [{ThreadId}] {Message:lj}{NewLine}{Exception}")
               .WriteTo.File(fileName,
               rollingInterval: RollingInterval.Month,
               outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {SourceContext} [{ThreadId}] {Message:lj}{NewLine}{Exception}")
           .CreateLogger();
#else
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Error()
               .Enrich.WithThreadId()
               //.Enrich.With(new ThreadIdEnricher())
               .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} [{ThreadId}] {Message:lj}{NewLine}{Exception}")
               .WriteTo.File(fileName,
               rollingInterval: RollingInterval.Month,
               outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {SourceContext} [{ThreadId}] {Message:lj}{NewLine}{Exception}")
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
