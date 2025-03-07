using System.ComponentModel.DataAnnotations;

namespace Domain;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;
}
