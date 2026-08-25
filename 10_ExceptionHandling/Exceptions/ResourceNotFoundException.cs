namespace CSharp.Mastery.ExceptionHandling.Exceptions;

public class ResourceNotFoundException : ApiException
{
    public ResourceNotFoundException(string resourceName, string resourceId) 
        : base($"Resource '{resourceName}' with ID '{resourceId}' was not found.", 404)
    {
    }
}
