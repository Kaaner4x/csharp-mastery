namespace ReflectionAndAttributes.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class RequiredAttribute : Attribute
{
    public string ErrorMessage { get; set; } = "Bu alan zorunludur.";
}
