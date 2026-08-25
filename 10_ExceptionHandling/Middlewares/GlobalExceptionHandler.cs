using CSharp.Mastery.ExceptionHandling.Exceptions;

namespace CSharp.Mastery.ExceptionHandling.Middlewares;

// Simulating a Global Exception Handler (similar to ASP.NET Core Middleware)
public class GlobalExceptionHandler
{
    public void ExecuteWithHandling(Action action)
    {
        try
        {
            action();
        }
        catch (ResourceNotFoundException ex)
        {
            // Specific catch blocks first
            Console.WriteLine($"[404 NOT FOUND] {ex.Message}");
        }
        catch (ApiException ex)
        {
            // Base custom exception
            Console.WriteLine($"[API ERROR {ex.StatusCode}] {ex.Message}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"[VALIDATION ERROR] {ex.ParamName} is missing. {ex.Message}");
        }
        catch (Exception ex)
        {
            // Generic catch block last
            Console.WriteLine($"[CRITICAL SYSTEM ERROR] An unexpected error occurred: {ex.Message}");
        }
        finally
        {
            // Always executes, regardless of exception
            Console.WriteLine("[FINALLY] Resource cleanup / logging complete.\n");
        }
    }
}
