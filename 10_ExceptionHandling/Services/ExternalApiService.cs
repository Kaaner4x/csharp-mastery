using CSharp.Mastery.ExceptionHandling.Exceptions;

namespace CSharp.Mastery.ExceptionHandling.Services;

public class ExternalApiService
{
    public string FetchUserData(string userId)
    {
        Console.WriteLine($"[API Service] Fetching data for user: {userId}");

        // Simulating different scenarios
        if (string.IsNullOrWhiteSpace(userId))
        {
            // Standard framework exception
            throw new ArgumentNullException(nameof(userId), "User ID cannot be empty.");
        }

        if (userId == "999")
        {
            // Simulating a 404 Not Found from an external system
            throw new ResourceNotFoundException("User", userId);
        }

        if (userId == "500")
        {
            // Simulating a server crash
            throw new ApiException("Internal Server Error from remote API.", 500);
        }

        return $"{{\"id\": \"{userId}\", \"name\": \"John Doe\"}}";
    }
}
