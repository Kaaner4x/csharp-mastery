using System.Reflection;
using ReflectionAndAttributes.Attributes;

namespace ReflectionAndAttributes.Validation;

public static class Validator
{
    public static bool Validate(object obj, out List<string> errors)
    {
        errors = new List<string>();
        Type type = obj.GetType();
        
        // Nesnenin tüm property'lerini dön
        foreach (PropertyInfo prop in type.GetProperties())
        {
            var value = prop.GetValue(obj);
            
            // [Required] kontrolü
            var requiredAttr = prop.GetCustomAttribute<RequiredAttribute>();
            if (requiredAttr != null)
            {
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    errors.Add($"{prop.Name}: {requiredAttr.ErrorMessage}");
                }
            }

            // [MaxLength] kontrolü
            var maxLengthAttr = prop.GetCustomAttribute<MaxLengthAttribute>();
            if (maxLengthAttr != null && value is string strValue)
            {
                if (strValue.Length > maxLengthAttr.Length)
                {
                    errors.Add($"{prop.Name}: Maksimum {maxLengthAttr.Length} karakter olmalıdır.");
                }
            }
        }

        return errors.Count == 0;
    }
}
