using ReflectionAndAttributes.Attributes;

namespace ReflectionAndAttributes.Models;

[Table("Users")]
public class User
{
    // Id için column belirtilmezse property adını kullanacağız
    public int Id { get; set; }

    [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
    [MaxLength(50)]
    [Column("UserName")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email boş geçilemez!")]
    [Column("UserEmail")]
    public string Email { get; set; } = string.Empty;
}
