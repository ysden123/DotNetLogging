using Serilog;

namespace PSerilogWOInit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            try
            {
                Console.WriteLine("Hello!");

                Log.Information("Entering the application");

                var class1 = new Class1();
                class1.Method1();

                Log.Error("Some test error log");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
