using CSharp.Mastery.ExceptionHandling.Services;
using CSharp.Mastery.ExceptionHandling.Middlewares;

namespace CSharp.Mastery.ExceptionHandling;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Advanced Exception Handling ===\n");

        var apiService = new ExternalApiService();
        var handler = new GlobalExceptionHandler();

        // 1. Success Scenario
        handler.ExecuteWithHandling(() => {
            var data = apiService.FetchUserData("123");
            Console.WriteLine($"Result: {data}");
        });

        // 2. Argument Null Scenario
        handler.ExecuteWithHandling(() => {
            var data = apiService.FetchUserData("");
            Console.WriteLine($"Result: {data}");
        });

        // 3. Resource Not Found Scenario (Custom Exception)
        handler.ExecuteWithHandling(() => {
            var data = apiService.FetchUserData("999");
            Console.WriteLine($"Result: {data}");
        });

        // 4. API Error Scenario
        handler.ExecuteWithHandling(() => {
            var data = apiService.FetchUserData("500");
            Console.WriteLine($"Result: {data}");
        });
        
        // 5. Unexpected Exception Scenario
        handler.ExecuteWithHandling(() => {
            Console.WriteLine("[App] Doing something risky...");
            int zero = 0;
            int result = 10 / zero; // DivideByZeroException
        });
    }
}
